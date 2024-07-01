using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotRealLtdFiles : BaseFileLocations
{

    public NotRealLtdFiles(Report report) : base(Company.NotRealLtd, report)
    {
        // Reading
        StartingFileExtension = ".xlsx";

        // Processing & Writing
        ProcessingFileExtension = ".xlsx";

        // Sending
        DestinationLocation = $"sftp example@255.255.0.5";
        
        // Archiving
        ArchiveOriginalFileExtension = StartingFileExtension;
        ArchiveSentFileExtension = ProcessingFileExtension;
    }

}
