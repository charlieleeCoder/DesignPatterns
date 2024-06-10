using DataValidation;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DataProcessor.Archive;
public class FullDocumentPipeline : IDocumentPipeline
{

    // Implement interface
    public string _colour { get; init; }
    public IDataReader _dataReader { get; init; }
    public IDataProcessor _dataProcessor { get; init; }
    public IDataWriter _dataWriter { get; init; }
    public IFileSender _fileSender { get; init; }
    public IFileArchiver _fileArchiver { get; init; }

    // Record keeping
    private Data? _data;
    private Data? _processedData;

    // File path variables
    private string? _startPath;
    private string? _sendDestination;
    private string? _archivePath;

    // Assign values in constructor
    public DocumentPipeline(

        string colour,
        IDataReader dataReader,
        IDataProcessor dataProcessor,
        IDataWriter dataWriter,
        IFileSender fileSender,
        IFileArchiver fileArchiver

    )
    {
        _colour = colour;
        _dataReader = dataReader;
        _dataProcessor = dataProcessor;
        _dataWriter = dataWriter;
        _fileSender = fileSender;
        _fileArchiver = fileArchiver;
    }

    // Set method to read initial file
    public void GetData()
    {
        _data = _dataReader.GetData();
    }

    // Set data processing
    public void ProcessData()
    {
        // Store and return
        _processedData = _dataProcessor.ProcessData(_data!);
    }

    // Call writer
    public void WriteData()
    {
        _dataWriter.WriteData(_processedData!);
    }

    // Call send method
    public void SendFile()
    {
        _fileSender.SendFile(_startPath!, _sendDestination!);
    }

    // Call archiver
    public void ArchiveFiles()
    {
        _fileArchiver.ArchiveFiles(_archivePath!);
    }
}