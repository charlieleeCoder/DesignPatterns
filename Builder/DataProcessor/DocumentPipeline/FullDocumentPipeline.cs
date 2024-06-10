// Microsoft's Pandas df equivalent
using Microsoft.Data.Analysis;
using DataProcessor.Enums;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DataProcessor.DocumentPipeline.Interface;

namespace DataProcessor.DocumentPipeline;
public class FullDocumentPipeline: IDocumentPipeline {

    // Implement interface
    public Colour Colour                   {get; set;}
    public IDataReader? DataReader         {get; set;}
    public IDataProcessor? DataProcessor   {get; set;}
    public IDataWriter? DataWriter         {get; set;}
    public IFileSender? FileSender         {get; set;}
    public IFileArchiver? FileArchiver     {get; set;}

    // Record keeping
    private DataFrame? _unprocessedData;
	private DataFrame? _processedData;

    // File path variables
    private string? _startPath;
    private string? _sendDestination;
	private string? _archivePath;

    // Set method to read initial file
	public void ReadData()
	{
		// Ensure data reader has been set
        if (DataReader is null)
		{
			throw new NullReferenceException("No data reader has been sent.");
		}
		// Store raw unprocessed data
		_unprocessedData = DataReader.ReadData(_startPath);
	}

	// Set data processing
	public void ProcessData()
	{
        // Ensure data processor has been set
        if (DataProcessor is null)
        {
            throw new NullReferenceException("No data processor has been sent.");
        }
        // Store processed data
        _processedData = DataProcessor.ProcessData(_unprocessedData!);
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
        FileArchiver.ArchiveFiles(_archivePath!);
	}
}