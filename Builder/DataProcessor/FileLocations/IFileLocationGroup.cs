using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileLocationGroup
{

    // Meta info
    public Company Company                          { get; set; }
    public string CompanyName                       { get; set; }
    public Report Report                            { get; set; }
    public string ReportName                        { get; set; }

    // Folder & Filename & Extension

    // Root
    public string Root                              { get; protected set; }
    public string FileName                          { get; protected set; }
    public string StartExtension                    { get; protected set; }
    public string EndExtension                      { get; protected set; }

    // Reading
    public string StartPathFile                     { get; protected set; }

    // Porcessing
    public string ProcessingPathFile                { get; protected set; }

    // Sending
    public string DestinationLocation               { get; protected set; }

    // Archiving
    public string ArchiveSentPathFile               { get; protected set; }
    public string ArchiveOriginalPathFile           { get; protected set; }

}
