// Microsoft's Pandas df equivalent
using Microsoft.Data.Analysis;
using DataProcessor.Enums;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileIdentifiers;
using DataProcessor.FileLocations.FileGroup;

namespace DataProcessor.DocumentPipeline;

public interface IDocumentPipeline
{

    // Required properties
    public abstract Company? Company                 { get; set; }
    public abstract IFileGroup? FileLocations        { get; set; }
    public abstract IFileLocationVerifier? FileVerifier { get; set; }
    public abstract IDataReader? DataReader          { get; set; }
    public abstract IDataProcessor? DataProcessor    { get; set; }
    public abstract IDataWriter? DataWriter          { get; set; }
    public abstract IFileSender? FileSender          { get; set; }
    public abstract IFileArchiver? FileArchiver      { get; set; }

    // Required methods
    public abstract void VerifyFiles();
    public abstract void ReadData();
    public abstract void ProcessData();
    public abstract void WriteData();
    public abstract void SendFile();
    public abstract void ArchiveFiles();
}

public class DocumentPipeline : IDocumentPipeline
{

    // Implement interface
    public Company? Company                { get; set; }
    public IFileGroup? FileLocations       { get; set; }
    public IFileLocationVerifier? FileVerifier { get; set; }
    public IDataReader? DataReader         { get; set; }
    public IDataProcessor? DataProcessor   { get; set; }
    public IDataWriter? DataWriter         { get; set; }
    public IFileSender? FileSender         { get; set; }
    public IFileArchiver? FileArchiver     { get; set; }

    // Record keeping
    private DataFrame? _unprocessedData;
	private DataFrame? _processedData;
    private DataFrame? _currentData;

    // TODO: Implement file verifier
    public void VerifyFiles()
    {
        if (FileLocations is null)
        {
            throw new NullReferenceException("No file locations have been set.");
        }
        if (FileVerifier is null)
        {
            throw new NullReferenceException("No file verifier have been set."); 
        }

        // if the date or version number is different than expected, return this
        FileLocations = FileVerifier.GetCorrectFileLocations(FileLocations);
    }

    // Set method to read initial file
    public void ReadData()
	{
		// Ensure data reader has been set
        if (DataReader is null)
		{
			throw new NullReferenceException("No data reader has been set.");
		}
        // And args given
        if (FileLocations is null)
        {
            throw new NullReferenceException("No start filepath has been given.");
        }
		// Store raw unprocessed data
		_unprocessedData = DataReader.ReadData(startLocation: FileLocations.StartPathFile.GetFileLocation());
        _currentData = _unprocessedData;
	}

	// Set data processing
	public void ProcessData()
	{
        // Ensure data processor has been set
        if (DataProcessor is null)
        {
            throw new NullReferenceException("No data processor has been set.");
        }
        if (_unprocessedData is null)
        {
            throw new NullReferenceException("No unprocessed data to process.");
        }
        // Store processed data
        _processedData = DataProcessor.ProcessData(data: _unprocessedData);
        _currentData = _processedData;

    }

    // Call writer
	public void WriteData()
	{
        // Ensure data writer has been set
        if (DataWriter is null)
        {
            throw new NullReferenceException("No data writer has been set.");
        }
        if (_currentData is null)
        {
            throw new NullReferenceException("No data has been read or processed to write.");
        }
        if (FileLocations is null)
        {
            throw new NullReferenceException("No file location set to write to.");
        }
        DataWriter.WriteData(data: _currentData, writeLocation: FileLocations.ProcessingPathFile.GetFileLocation());
	}

	// Call send method
	public void SendFile()
    {
        // Ensure file sender has been set
        if (FileSender is null)
        {
            throw new NullReferenceException("No file sender has been set.");
        }
        if (FileLocations is null)
        {
            throw new NullReferenceException("Missing file path required to send file.");
        }
        FileSender.SendFile(fileToSend: FileLocations.ProcessingPathFile.GetFileLocation(), destinationLocation: FileLocations.DestinationLocation.SendDestination);
    }

	// Call archiver
	public void ArchiveFiles()
    {
        // Ensure file archiver has been set
        if (FileArchiver is null)
        {
            throw new NullReferenceException("No file archiver has been set.");
        }
        // And we have required params
        if (FileLocations is null)
        {
            throw new ArgumentException("We require filepaths to archive correct documents.");
        }
        FileArchiver.ArchiveFiles(
                                    originalFilePath: FileLocations.StartPathFile.GetFileLocation(), 
                                    originalArchivePath: FileLocations.ArchiveOriginalPathFile.GetFileLocation(), 
                                    processedFilePath: FileLocations.ProcessingPathFile.GetFileLocation(),
                                    processedArchivePath: FileLocations.ArchiveSentPathFile.GetFileLocation()
                                   );
	}
}