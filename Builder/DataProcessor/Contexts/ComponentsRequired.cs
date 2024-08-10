using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileIdentifiers;

namespace DataProcessor.Contexts;

public interface IComponentList
{
    public IFileLocationVerifier Verifier { get; set; }
    public IDataReader? Reader { get; set; }
    public IDataProcessor? Processor { get; set; }
    public IDataWriter? Writer { get; set; }
    public IFileSender Sender { get; set; } 
    public IFileArchiver Archiver { get; set; } 
}

public abstract class BaseComponentsRequired : IComponentList
{
    public virtual IFileLocationVerifier Verifier   { get; set; } = default!;
    public virtual IDataReader? Reader              { get; set; }
    public virtual IDataProcessor? Processor        { get; set; } 
    public virtual IDataWriter? Writer              { get; set; }
    public virtual IFileSender Sender               { get; set; } = default!;
    public virtual IFileArchiver Archiver           { get; set; } = default!;
}

public class UnprocessedCSVSentByEmail : BaseComponentsRequired
{
    public UnprocessedCSVSentByEmail()
    {
        Verifier    = new FileLocationVerifier();
        Reader      = new CSVDataReader();
        Processor   = new UnProcessed();
        Writer      = new CSVWriter();
        Sender      = new EmailFileSender();
        Archiver    = new SimpleFileArchiver();
    }
}

public class UnprocessedCSVSentByWebDriver : BaseComponentsRequired
{
    public UnprocessedCSVSentByWebDriver()
    {
        Verifier    = new FileLocationVerifier();
        Reader      = new CSVDataReader();
        Processor   = new RemoveBlocked();
        Writer      = new CSVWriter();
        Sender      = new WebPortalFileSender();
        Archiver    = new SimpleFileArchiver();
    }
}

public class ProcessedExcelSentViaSFTP : BaseComponentsRequired
{
    public ProcessedExcelSentViaSFTP()
    {
        Verifier    = new FileLocationVerifier();
        Reader      = new ExcelDataReader();
        Processor   = new RemoveBlocked();
        Writer      = new ExcelWriter();
        Sender      = new SFTPFileSender();
        Archiver    = new SimpleFileArchiver();
    }
}

public class ProcessedCSVConvertedtoExcelSentViaSFTP : BaseComponentsRequired
{
    public ProcessedCSVConvertedtoExcelSentViaSFTP()
    {
        Verifier    = new FileLocationVerifier();
        Reader      = new CSVDataReader();
        Processor   = new RemoveBlocked();
        Writer      = new ExcelWriter();
        Sender      = new SFTPFileSender();
        Archiver    = new SimpleFileArchiver();
    }
}
