using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public abstract class BaseFileLocations : IFileLocations
{

    // Meta info
    public Company Company                      { get; set; } 
    public string CompanyName                   { get; set; }
    public Report Report                        { get; set; }
    public string ReportName                    { get; set; }

    // Root
    public string RootFolder                    { get; set; }

    // Start Folder & Filename
    public string StartingFileLocation          { get; set; }
    public string StartingFileName              { get; set; }
    public string StartingFileExtension         { get; set; } = string.Empty;

    // Processing & Writing
    public string ProcessingFileLocation        { get; set; }
    public string ProcessingFileName            { get; set; }
    public string ProcessingFileExtension       { get; set; } = string.Empty;

    // Sending
    public string DestinationLocation           { get; set; } = string.Empty;

    // Archiving
    public string ArchiveFileLocation           { get; set; }
    public string ArchiveSentFileName           { get; set; }
    public string ArchiveSentFileExtension      { get; set; } = string.Empty;
    public string ArchiveOriginalFileName       { get; set; }
    public string ArchiveOriginalFileExtension  { get; set; } = string.Empty;


    public BaseFileLocations(Company company, Report report)
    {
        // Meta
        Company = company;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        Report = report;
        ReportName = ReportsDictionary.ReportsLookup[Report];

        // Root
        RootFolder = "C:\\FakeData";

        // Starting
        StartingFileLocation = $"{RootFolder}\\{CompanyName}\\{ReportName}\\OriginalOutput\\";

        // Live
        // StartingFileName = $"{ReportName} {DateTime.Now:dd-MM-yy} v1";

        // Testing
        StartingFileName = $"{ReportName} 01-07-24 v1";

        // Processing & Writing
        ProcessingFileLocation = $"{RootFolder}\\{CompanyName}\\{ReportName}\\Processing\\";
        ProcessingFileName = $"{ReportName} - PROCESSING";

        // Archiving
        ArchiveFileLocation = $"{RootFolder}\\{CompanyName}\\{ReportName}\\Archive\\";
        ArchiveSentFileName = $"{ReportName} - SENT";
        ArchiveOriginalFileName = $"{ReportName} - ORIGINAL";
    }

}
