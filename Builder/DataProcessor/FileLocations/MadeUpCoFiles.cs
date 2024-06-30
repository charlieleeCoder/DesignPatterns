using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MadeUpCoFiles : BaseFileLocations
{

    public MadeUpCoFiles(Company company, Report report) : base(company, report)
    {

        StartingFileExtension = ".csv";

        // Processing & Writing
        ProcessingFileLocation = $".\\{CompanyName}\\{ReportName}\\Processing\\";
        ProcessingFileName = "";

        // Sending
        DestinationLocation = "sftp example@255.255.0.1";

        // Archiving
        ArchiveFileLocation = $".\\{CompanyName}\\{ReportName}\\Archive\\";

    }

}
