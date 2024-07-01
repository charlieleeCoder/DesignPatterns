using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public abstract class BaseFileLocations : IFileLocations
{

    // Meta info
    public Company Company                          { get; set; } 
    public string CompanyName                       { get; set; }
    public Report Report                            { get; set; }
    public string ReportName                        { get; set; }

    // Root
    public string RootFolder                        { get; set; }

    // Start Folder & Filename
    public string StartingFileLocation              { get; set; }
    public string StartingFileName                  { get; set; }
    public abstract string StartingFileExtension    { get; set; }

    // Processing & Writing
    public string ProcessingFileLocation            { get; set; }
    public string ProcessingFileName                { get; set; }
    public abstract string ProcessingFileExtension  { get; set; }

    // Sending
    public abstract string DestinationLocation      { get; set; }

    // Archiving
    public string ArchiveFileLocation               { get; set; }
    public string ArchiveSentFileName               { get; set; }
    public abstract string ArchiveSentFileExtension { get; set; }
    public string ArchiveOriginalFileName           { get; set; }
    public abstract string ArchiveOriginalFileExtension { get; set; }


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
        StartingFileName = $"{CompanyName} {ReportName} 01-07-24 v1";

        // Processing & Writing
        ProcessingFileLocation = $"{RootFolder}\\{CompanyName}\\{ReportName}\\Processing\\";
        ProcessingFileName = $"{ReportName} - PROCESSING";

        // Archiving
        ArchiveFileLocation = $"{RootFolder}\\{CompanyName}\\{ReportName}\\Archive\\";
        ArchiveSentFileName = $"{ReportName} - SENT";
        ArchiveOriginalFileName = $"{ReportName} - ORIGINAL";
    }

}
