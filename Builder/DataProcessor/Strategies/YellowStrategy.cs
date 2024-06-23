using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public class YellowStrategy : BaseStrategy
{
    public new Colour Colour = Colour.yellow;
    public new Type Reader = typeof(CSVDataReader);
    public new Type Processor = typeof(RemoveCancelled);
    public new Type Writer = typeof(CSVWriter);
    public new Type Sender = typeof(SFTPFileSender);
    public new Type Archiver = typeof(SimpleFileArchiver);
}
