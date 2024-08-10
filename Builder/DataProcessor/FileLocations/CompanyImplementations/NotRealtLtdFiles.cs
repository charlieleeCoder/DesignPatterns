using DataProcessor.Enums;
using DataProcessor.FileLocations.FileGroup;
using DataProcessor.FileLocations.FileGroup.FileGroupComponents;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class NotRealLtdFiles : BaseFileGroup
{
    public override FileDestination DestinationLocation { get; set; }

    public NotRealLtdFiles(Report report) : base(Company.NotRealLtd, report)
    {

        // Reading
        StartPathFile.ChangeFileExtension(".xlsx");

        // Processing
        ProcessingPathFile.ChangeFileExtension(".xlsx");

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "SFTP", sendDestination: "sftp example@255.255.0.5");

        // Archiving
        ArchiveSentPathFile.ChangeFileExtension(".xlsx");
        ArchiveOriginalPathFile.ChangeFileExtension(".xlsx");

    }

}
