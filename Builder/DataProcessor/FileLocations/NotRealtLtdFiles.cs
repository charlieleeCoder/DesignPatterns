using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotRealLtdFiles : BaseFileGroup
{
    public override FileDestination DestinationLocation      { get; set; }

    public NotRealLtdFiles(Report report) : base(Company.NotRealLtd, report)
    {

        // Reading
        StartPathFile.FileExtension = ".xlsx";

        // Processing
        ProcessingPathFile.FileExtension = ".xlsx";

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "SFTP", sendDestination: "sftp example@255.255.0.5");

        // Archiving
        ArchiveSentPathFile.FileExtension = ".xlsx";
        ArchiveOriginalPathFile.FileExtension = ".xlsx";

    }

}
