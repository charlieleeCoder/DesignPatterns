using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileLocations
{
    
    // Meta info
    public Company Company                      { get; set; }
    public string CompanyName                   { get; set; }
    public Report Report                        { get; set; }
    public string ReportName                    { get; set; }

    // Start Folder & Filename
    public string StartingFileLocation          { get; set; }
    public string StartingFileName              { get; set; }
    public string? StartingFileExtension        { get; set; }

    // Processing & Writing
    public string ProcessingFileLocation        { get; set; }
    public string ProcessingFileName            { get; set; }
    public string? ProcessingFileExtension      { get; set; }

    // Sending
    public string? DestinationLocation          { get; set; }

    // Archiving
    public string  ArchiveFileLocation          { get; set; }
    public string  ArchiveSentFileName          { get; set; }
    public string? ArchiveSentFileExtension     { get; set; }
    public string  ArchiveOriginalFileName      { get; set; }
    public string? ArchiveOriginalFileExtension { get; set; }

}
