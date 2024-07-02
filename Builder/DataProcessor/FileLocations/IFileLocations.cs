using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileLocations
{

    // Meta info
    public Company Company                          { get; set; }
    public string CompanyName                       { get; set; }
    public Report Report                            { get; set; }
    public string ReportName                        { get; set; }

    // Root
    public string RootFolder                        { get; set; }

    // Folder & Filename & Extension

    // Reading
    public string StartPathFileExtension            { get; protected set; }

    // Porcessing
    public string ProcessingPathFileExtension       { get; protected set; }

    // Sending
    public string DestinationLocation               { get; protected set; }

    // Archiving
    public string ArchiveSentPathFileExtension      { get; protected set; }
    public string ArchiveOriginalPathFileExtension  { get; protected set; }

}
