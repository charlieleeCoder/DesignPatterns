using DataProcessor.Enums;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DataProcessor.DocumentPipeline.Interface;

public interface IDocumentPipeline {

    // Required properties
    public Colour Colour                   {get; set;}     
    public IDataReader? DataReader         {get; set;}
    public IDataProcessor? DataProcessor   {get; set;}
    public IDataWriter? DataWriter         {get; set;}
    public IFileSender? FileSender         {get; set;}
    public IFileArchiver? FileArchiver     {get; set;}

    // Required methods
    public void ReadData();
    public void ProcessData();
    public void WriteData();
    public void SendFile();
    public void ArchiveFiles();
}