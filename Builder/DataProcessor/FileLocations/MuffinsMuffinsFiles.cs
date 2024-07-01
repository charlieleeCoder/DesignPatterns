using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileLocations
{

    public MuffinsMuffinsFiles(Report report) : base(Company.MuffinsMuffins, report)
    {
        // Reading
        StartingFileExtension = ".csv";

        // Processing & Writing
        ProcessingFileExtension = ".csv";

        // Sending
        DestinationLocation = $"madeupemail@{CompanyName}.com";

        // Archiving
        ArchiveOriginalFileExtension = StartingFileExtension;
        ArchiveSentFileExtension = ProcessingFileExtension;
    }

}