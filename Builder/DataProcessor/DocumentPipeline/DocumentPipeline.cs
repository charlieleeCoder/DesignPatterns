// Microsoft's Pandas df equivalent
using Microsoft.Data.Analysis;
using DataProcessor.Enums;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;

namespace DataProcessor.DocumentPipeline;

public interface IDocumentPipeline
{

    // Required properties
    public Colour? Colour                   { get; set; }
    public IDataReader? DataReader          { get; set; }
    public IDataProcessor? DataProcessor    { get; set; }
    public IDataWriter? DataWriter          { get; set; }
    public IFileSender? FileSender          { get; set; }
    public IFileArchiver? FileArchiver      { get; set; }

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
    public Colour? Colour                  { get; set; }
    public IDataReader? DataReader         { get; set; }
    public IDataProcessor? DataProcessor   { get; set; }
    public IDataWriter? DataWriter         { get; set; }
    public IFileSender? FileSender         { get; set; }
    public IFileArchiver? FileArchiver     { get; set; }

    // Record keeping
    private DataFrame? _unprocessedData;
	private DataFrame? _processedData;
    private DataFrame? _currentData;

    // File path variables
    public string? _startPath              { get; set; }
    public string? _sendDestination        { get; set; }
    public string? _archivePath            { get; set; }

    // Set method to read initial file
    public void ReadData()
	{
		// Ensure data reader has been set
        if (DataReader is null)
		{
			throw new NullReferenceException("No data reader has been sent.");
		}
        // And args given
        if (_startPath is null)
        {
            throw new NullReferenceException("No start filepath has been given.");
        }
		// Store raw unprocessed data
		_unprocessedData = DataReader.ReadData(_startPath);
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
        DataWriter.WriteData(_processedData!);
	}

	// Call send method
	public void SendFile()
    {
        // Ensure file sender has been set
        if (FileSender is null)
        {
            throw new NullReferenceException("No file sender has been sent.");
        }
		FileSender.SendFile(_startPath!, _sendDestination!);
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
        if (_startPath is null || _archivePath is null)
        {
            throw new ArgumentException("We require filepaths to archive correct documents.");
        }
        FileArchiver.ArchiveFiles(_startPath, _archivePath);
	}
}