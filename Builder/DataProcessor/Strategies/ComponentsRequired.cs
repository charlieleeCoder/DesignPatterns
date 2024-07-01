using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;

namespace DataProcessor.ComponentsRequired;

public abstract class BaseComponentsRequired
{
    public IDataReader Reader          { get; protected set; } = default!;
    public IDataProcessor Processor    { get; protected set; } = default!;
    public IDataWriter Writer          { get; protected set; } = default!;
    public IFileSender Sender          { get; protected set; } = default!;
    public IFileArchiver Archiver      { get; protected set; } = default!;
}

public class UnprocessedCSVSentByEmail : BaseComponentsRequired
{
    public UnprocessedCSVSentByEmail()
    {
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
        Reader      = new CSVDataReader();
        Processor   = new RemoveBlocked();
        Writer      = new ExcelWriter();
        Sender      = new SFTPFileSender();
        Archiver    = new SimpleFileArchiver();
    }
}