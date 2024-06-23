using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public class BlueStrategy : BaseStrategy
{
    public new Colour Colour = Colour.blue;
    public new Type Reader = typeof(CSVDataReader);
    public new Type Processor = typeof(RemoveCancelled);
    public new Type Writer = typeof(CSVWriter);
    public new Type Sender = typeof(WebPortalFileSender);
    public new Type Archiver = typeof(SimpleFileArchiver);
}
