using DataProcessor.Enums;
using System;

namespace DataProcessor.FileLocations;

public abstract class BaseFileGroup : IFileGroup
{

    // Meta info
    public Company Company                                  { get; set; } 
    public string CompanyName                               { get; set; }
    public Report Report                                    { get; set; }
    public string ReportName                                { get; set; }
    public string FileName                                  { get; set; }    

    // Reading
    public virtual FileLocation StartPathFile               { get; set; }

    // Processing
    public virtual FileLocation ProcessingPathFile          { get; set; }

    // Sending
    public abstract FileDestination DestinationLocation     { get; set; }

    // Archiving
    public virtual FileLocation ArchiveSentPathFile         { get; set; }
    public virtual FileLocation ArchiveOriginalPathFile     { get; set; }


    public BaseFileGroup(Company company, Report report)
    {
        // Meta
        Company = company;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        Report = report;
        ReportName = ReportsDictionary.ReportsLookup[Report];

        // Live
        // FileName = $"{CompanyName} {ReportName} {DateTime.Now:dd-mm-yy} v1";

        // Testing
        FileName = $"{CompanyName} {ReportName} 01-07-24 v1";


        StartPathFile = new FileLocation(
                                            filePath:$"C:\\FakeData\\{CompanyName}\\{ReportName}\\",
                                            fileName: FileName,
                                            fileExtension:".csv" // Most common, so use as default
                                         );

        // Processing & Writing
        ProcessingPathFile = new FileLocation(
                                                filePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Processing\\",
                                                fileName: $"{FileName} - PROCESSING",
                                                fileExtension: ".csv"
                                               );

        // Archiving
        ArchiveOriginalPathFile = new FileLocation(
                                                filePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Archive\\",
                                                fileName: $"{FileName} - ORIGINAL",
                                                fileExtension: ".csv"
                                               );

        ArchiveSentPathFile = new FileLocation(
                                                filePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Archive\\",
                                                fileName: $"{FileName} - SENT",
                                                fileExtension: ".csv"
                                               );
    }

}
