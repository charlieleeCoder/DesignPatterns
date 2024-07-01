﻿using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileArchivers;
using DataProcessor.Components.FileSenders;
using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public abstract class BaseStrategy
{
    public Type Reader      { get; set; } = default!;
    public Type Processor   { get; set; } = default!;
    public Type Writer      { get; set; } = default!;
    public Type Sender      { get; set; } = default!;
    public Type Archiver    { get; set; } = default!;
}

public class ProcessedCSVSentByEmail: BaseStrategy
{
    public new Type Reader      { get; set; } = typeof(CSVDataReader);
    public new Type Processor   { get; set; } = typeof(RemoveCancelled);
    public new Type Writer      { get; set; } = typeof(CSVWriter);
    public new Type Sender      { get; set; } = typeof(EmailFileSender);
    public new Type Archiver    { get; set; } = typeof(SimpleFileArchiver);
}

public class UnprocessedCSVSentByWebDriver : BaseStrategy
{
    public new Type Reader      { get; set; } = typeof(CSVDataReader);
    public new Type Processor   { get; set; } = typeof(RemoveCancelled);
    public new Type Writer      { get; set; } = typeof(CSVWriter);
    public new Type Sender      { get; set; } = typeof(WebPortalFileSender);
    public new Type Archiver    { get; set; } = typeof(SimpleFileArchiver);
}

public class UnprocessedExcelSentViaSFTP: BaseStrategy
{
    public new Type Reader      { get; set; } = typeof(ExcelDataReader);
    public new Type Processor   { get; set; } = typeof(UnProcessed);
    public new Type Writer      { get; set; } = typeof(ExcelWriter);
    public new Type Sender      { get; set; } = typeof(SFTPFileSender);
    public new Type Archiver    { get; set; } = typeof(SimpleFileArchiver);
}

public class ProcessedCSVConvertedtoExcelSentViaSFTP : BaseStrategy
{
    public new Type Reader      { get; set; } = typeof(CSVDataReader);
    public new Type Processor   { get; set; } = typeof(RemoveCancelled);
    public new Type Writer      { get; set; } = typeof(ExcelWriter);
    public new Type Sender      { get; set; } = typeof(SFTPFileSender);
    public new Type Archiver    { get; set; } = typeof(SimpleFileArchiver);
}
}