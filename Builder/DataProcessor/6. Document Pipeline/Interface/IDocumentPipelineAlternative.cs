using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DocumentPipeline;
public interface IDocumentPipelineAlternative {

    // Required properties
    public string? _colour                  {get; set;}     
    public IDataReader? _dataReader         {get; set;}
    public IDataProcessor? _dataProcessor   {get; set;}
    public IDataWriter? _dataWriter         {get; set;}
    public IFileSender? _fileSender         {get; set;}
    public IFileArchiver? _fileArchiver     {get; set;}

    // Required methods
    public void GetData();
    public void ProcessData();
    public void WriteData();
    public void SendFile();
    public void ArchiveFiles();
}