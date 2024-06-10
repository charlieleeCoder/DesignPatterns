using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DataProcessor.Archive;
public interface IDocumentPipeline
{

    // Required properties
    protected string _colour { get; init; }
    protected IDataReader _dataReader { get; init; }
    protected IDataProcessor _dataProcessor { get; init; }
    protected IDataWriter _dataWriter { get; init; }
    protected IFileSender _fileSender { get; init; }
    protected IFileArchiver _fileArchiver { get; init; }

    // Required methods
    public void GetData();
    public void ProcessData();
    public void WriteData();
    public void SendFile();
    public void ArchiveFiles();
}