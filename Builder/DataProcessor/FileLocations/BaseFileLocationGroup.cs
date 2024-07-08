using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public abstract class BaseFileLocationGroup : IFileLocationGroup
{

    // Meta info
    public Company Company                                  { get; set; } 
    public string CompanyName                               { get; set; }
    public Report Report                                    { get; set; }
    public string ReportName                                { get; set; }

    // Folder & Filename & Extension
    public virtual string Root                              { get; set; }
    public virtual string FileName                          { get; set; }

    // Extensions
    public virtual string StartExtension                    { get; set; }
    public virtual string EndExtension                      { get; set; }

    public virtual string StartPathFile                     { get; set; }
    public virtual string ProcessingPathFile                { get; set; }

    // Sending
    public abstract string DestinationLocation              { get; set; }

    // Archiving
    public virtual string ArchiveSentPathFile               { get; set; }
    public virtual string ArchiveOriginalPathFile           { get; set; }


    public BaseFileLocationGroup(Company company, Report report)
    {
        // Meta
        Company = company;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        Report = report;
        ReportName = ReportsDictionary.ReportsLookup[Report];

        // Root
        Root = "C:\\FakeData";

        // File
        // FileName = $"{CompanyName} {ReportName} {DateTime.Now:dd-MM-yy} v1"; // Live
        FileName = $"{CompanyName} {ReportName} 01-07-24 v1"; // Testing 

        // Default filetype
        StartExtension = ".csv";
        EndExtension = ".csv";

        // Starting
        StartPathFile = $"{Root}\\{CompanyName}\\{ReportName}\\OriginalOutput\\{FileName}";

        // Processing & Writing
        ProcessingPathFile = $"{Root}\\{CompanyName}\\{ReportName}\\Processing\\{FileName} - PROCESSING";

        // Archiving
        ArchiveOriginalPathFile = $"{Root}\\{CompanyName}\\{ReportName}\\Archive\\{FileName} - ORIGINAL";
        ArchiveSentPathFile = $"{Root}\\{CompanyName}\\{ReportName}\\Archive\\{FileName} - SENT";
    }

}
