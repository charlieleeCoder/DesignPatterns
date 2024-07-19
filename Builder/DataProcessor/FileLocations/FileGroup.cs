using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public interface IFileGroup
{

    // Meta info
    public abstract Company Company                         { get; set; }
    public abstract string CompanyName                      { get; set; }
    public abstract Report Report                           { get; set; }
    public abstract string ReportName                       { get; set; }

    // Folder & Filename & Extension

    // Reading
    public abstract FileLocation StartPathFile              { get; set; }

    // Processing
    public abstract FileLocation ProcessingPathFile         { get; set; }

    // Sending
    public abstract FileDestination DestinationLocation     { get; set; }

    // Archiving
    public abstract FileLocation ArchiveSentPathFile        { get; set; }
    public abstract FileLocation ArchiveOriginalPathFile    { get; set; }

}

public abstract class FileGroup : IFileGroup
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


    public FileGroup(Company company, Report report)
    {
        // Meta
        Company = company;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        Report = report;
        ReportName = ReportsDictionary.ReportsLookup[Report];

        // Base file name, potentially to be overwritten
        FileName = $"{CompanyName} {ReportName}";

        // Original document
        StartPathFile = new FileLocation(
                                            filePath:$"C:\\FakeData\\{CompanyName}\\{ReportName}\\OriginalOutput\\",
                                            fileName: FileName,
                                            formattedFileDate: $"{DateTime.Now:dd-mm-yy}",
                                            fileVersionText: "v",
                                            versionNumber: 1,
                                            appendedStatus: "",
                                            fileExtension:".csv" // Most common, so use as default
                                         );

        // Processing & Writing
        ProcessingPathFile = new FileLocation(
                                                otherInstanceToCopy: StartPathFile, 
                                                modifiedFilePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Processing\\", 
                                                modifiedStatus: " - PROCESSING"
                                              );


        // Archiving
        ArchiveOriginalPathFile = new FileLocation(
                                                otherInstanceToCopy: StartPathFile,
                                                modifiedFilePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Archive\\",
                                                modifiedStatus: " - ORIGINAL"
                                               );

        ArchiveSentPathFile = new FileLocation(
                                                otherInstanceToCopy: StartPathFile,
                                                modifiedFilePath: $"C:\\FakeData\\{CompanyName}\\{ReportName}\\Archive\\",
                                                modifiedStatus: " - SENT"
                                               );
    }

}
