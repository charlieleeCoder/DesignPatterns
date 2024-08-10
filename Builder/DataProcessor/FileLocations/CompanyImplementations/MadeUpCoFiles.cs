using DataProcessor.Enums;
using DataProcessor.FileLocations.FileGroup;
using DataProcessor.FileLocations.FileGroup.FileGroupComponents;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class MadeUpCoFiles : BaseFileGroup
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
