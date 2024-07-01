using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileLocations
{
    
    // Meta info
    public Company Company                      { get; protected set; }
    public string CompanyName                   { get; protected set; }
    public Report Report                        { get; protected set; }
    public string ReportName                    { get; protected set; }

    // Root
    public string RootFolder                    { get; protected set; }

    // Start Folder & Filename
    public string StartingFileLocation          { get; protected set; }
    public string StartingFileName              { get; protected set; }
    public string StartingFileExtension         { get; protected set; }

    // Processing & Writing
    public string ProcessingFileLocation        { get; protected set; }
    public string ProcessingFileName            { get; protected set; }
    public string ProcessingFileExtension       { get; protected set; }

    // Sending
    public string DestinationLocation           { get; protected set; }

    // Archiving
    public string ArchiveFileLocation           { get; protected set; }
    public string ArchiveSentFileName           { get; protected set; }
    public string ArchiveSentFileExtension      { get; protected set; }
    public string ArchiveOriginalFileName       { get; protected set; }
    public string ArchiveOriginalFileExtension  { get; protected set; }

}
