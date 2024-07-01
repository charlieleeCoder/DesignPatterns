using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileLocations
{
    public override string StartingFileExtension        { get; set; }
    public override string ProcessingFileExtension      { get; set; }
    public override string DestinationLocation          { get; set; }
    public override string ArchiveSentFileExtension     { get; set; }
    public override string ArchiveOriginalFileExtension { get; set; }

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