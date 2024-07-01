using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MadeUpCoFiles : BaseFileLocations
{

    public MadeUpCoFiles(Report report) : base(Company.MadeUpCo, report)
    {
        // Reading
        StartingFileExtension = ".csv";

        // Processing & Writing
        ProcessingFileExtension = ".xlsx";

        // Sending
        DestinationLocation = "sftp example@255.255.0.1";

        // Arhive
        ArchiveOriginalFileExtension = StartingFileExtension;
        ArchiveSentFileExtension = ProcessingFileExtension;

    }

}
