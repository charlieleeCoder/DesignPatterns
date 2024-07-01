using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotGenericCoFiles : BaseFileLocations
{

    public NotGenericCoFiles(Report report) : base(Company.NotGenericCo, report)
    {
        // Reading
        StartingFileExtension = ".csv";

        // Processing & Writing
        ProcessingFileExtension = ".csv";

        // Sending
        DestinationLocation = $"www.{CompanyName}.com/upload_files/";

        // Archiving
        ArchiveOriginalFileExtension = StartingFileExtension;
        ArchiveSentFileExtension = ProcessingFileExtension;
    }

}