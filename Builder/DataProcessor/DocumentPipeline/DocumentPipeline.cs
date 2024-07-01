// Microsoft's Pandas df equivalent
using Microsoft.Data.Analysis;
using DataProcessor.Enums;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;
using DataProcessor.FileLocations;

namespace DataProcessor.DocumentPipeline;

public interface IDocumentPipeline
{

    // Required properties
    public Company? Company                 { get; set; }
    public IDataReader? DataReader          { get; set; }
    public IDataProcessor? DataProcessor    { get; set; }
    public IDataWriter? DataWriter          { get; set; }
    public IFileSender? FileSender          { get; set; }
    public IFileArchiver? FileArchiver      { get; set; }
    public IFileLocations? FileLocations    { get; set; }

    // Required methods
    public void ReadData();
    public void ProcessData();
    public void WriteData();
    public void SendFile();
    public void ArchiveFiles();
}

public class DocumentPipeline : IDocumentPipeline
{

    // Implement interface
    public Company? Company                { get; set; }
    public IFileLocations? FileLocations   { get; set; }
    public IDataReader? DataReader         { get; set; }
    public IDataProcessor? DataProcessor   { get; set; }
    public IDataWriter? DataWriter         { get; set; }
    public IFileSender? FileSender         { get; set; }
    public IFileArchiver? FileArchiver     { get; set; }

    // Record keeping
    private DataFrame? _unprocessedData;
	private DataFrame? _processedData;
    private DataFrame? _currentData;

    // Set method to read initial file
    public void ReadData()
	{
		// Ensure data reader has been set
        if (DataReader is null)
		{
			throw new NullReferenceException("No data reader has been sent.");
		}
        // And args given
        if (FileLocations is null)
        {
            throw new NullReferenceException("No start filepath has been given.");
        }
		// Store raw unprocessed data
		_unprocessedData = DataReader.ReadData(FileLocations.StartingFileLocation);
        _currentData = _unprocessedData;
	}

	// Set data processing
	public void ProcessData()
	{
        // Ensure data processor has been set
        if (DataProcessor is null)
        {
            throw new NullReferenceException("No data processor has been sent.");
        }
        if (_unprocessedData is null)
        {
            throw new NullReferenceException("No unprocessed data to process.");
        }
        // Store processed data
        _processedData = DataProcessor.ProcessData(_unprocessedData);
        _currentData = _processedData;

    }

    // Call writer
	public void WriteData()
	{
        // Ensure data writer has been set
        if (DataWriter is null)
        {
            throw new NullReferenceException("No data writer has been sent.");
        }
        if (_currentData is null)
        {
            throw new NullReferenceException("No data has been read or processed to write.");
        }
        if (FileLocations is null)
        {
            throw new NullReferenceException("No file location set to write to.");
        }
        DataWriter.WriteData(_currentData, FileLocations.ProcessingFileLocation);
	}

	// Call send method
	public void SendFile()
    {
        // Ensure file sender has been set
        if (FileSender is null)
        {
            throw new NullReferenceException("No file sender has been sent.");
        }
        if (FileLocations is null)
        {
            throw new NullReferenceException("Missing file path required to send file.");
        }
        FileSender.SendFile(FileLocations.StartingFileLocation, FileLocations.DestinationLocation);
    }

	// Call archiver
	public void ArchiveFiles()
    {
        // Ensure file archiver has been set
        if (FileArchiver is null)
        {
            throw new NullReferenceException("No file archiver has been sent.");
        }
        // And we have required params
        if (FileLocations is null)
        {
            throw new ArgumentException("We require filepaths to archive correct documents.");
        }
        FileArchiver.ArchiveFiles(FileLocations);
	}
}