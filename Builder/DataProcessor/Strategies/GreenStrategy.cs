using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public class GreenStrategy : BaseStrategy
{
    public new Colour Colour = Colour.green;
    public new Type Reader = typeof(ExcelDataReader);
    public new Type Processor = typeof(RemoveCancelled);
    public new Type Writer = typeof(ExcelWriter);
    public new Type Sender = typeof(SFTPFileSender);
    public new Type Archiver = typeof(SimpleFileArchiver);
}
