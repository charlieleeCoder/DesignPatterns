using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MadeUpCoFiles : BaseFileGroup
{
    public override FileDestination DestinationLocation { get; set; }

    public MadeUpCoFiles(Report report) : base(Company.MadeUpCo, report)
    {

        // Processing & Writing
        ProcessingPathFile.FileExtension = ".xlsx";
        ArchiveSentPathFile.FileExtension = ".xlsx";

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "SFTP",sendDestination: "example@255.255.0.1");

    }


}
