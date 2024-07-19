using DataProcessor.Enums;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class MadeUpCoFiles : FileGroup
{
    public override FileDestination DestinationLocation { get; set; }

    public MadeUpCoFiles(Report report) : base(Company.MadeUpCo, report)
    {

        // Processing & Writing
        ProcessingPathFile.ChangeFileExtension(".xlsx");
        ArchiveSentPathFile.ChangeFileExtension(".xlsx");

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "SFTP", sendDestination: "example@255.255.0.1");

    }


}
