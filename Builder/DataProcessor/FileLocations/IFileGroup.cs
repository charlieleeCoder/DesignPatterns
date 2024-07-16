using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileGroup
{

    // Meta info
    public Company Company                          { get; set; }
    public string CompanyName                       { get; set; }
    public Report Report                            { get; set; }
    public string ReportName                        { get; set; }

    // Folder & Filename & Extension

    // Reading
    public FileLocation StartPathFile               { get; set; }

    // Processing
    public FileLocation ProcessingPathFile          { get; set; }

    // Sending
    public FileDestination DestinationLocation      { get; set; }

    // Archiving
    public FileLocation ArchiveSentPathFile         { get; set; }
    public FileLocation ArchiveOriginalPathFile     { get; set; }

}
