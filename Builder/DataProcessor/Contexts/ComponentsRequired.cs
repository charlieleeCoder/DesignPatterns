using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileIdentifiers;

namespace DataProcessor.ComponentsRequired;

public abstract class BaseComponentsRequired
{
    public virtual IFileLocationVerifier Verifier   { get; protected set; } = default!;
    public virtual IDataReader Reader               { get; protected set; } = default!;
    public virtual IDataProcessor Processor         { get; protected set; } = default!;
    public virtual IDataWriter Writer               { get; protected set; } = default!;
    public virtual IFileSender Sender               { get; protected set; } = default!;
    public virtual IFileArchiver Archiver           { get; protected set; } = default!;
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