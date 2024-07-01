using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotGenericCoFiles : BaseFileLocations
{
    public override string StartingFileExtension        { get; set; }
    public override string ProcessingFileExtension      { get; set; }
    public override string DestinationLocation          { get; set; }
    public override string ArchiveSentFileExtension     { get; set; }
    public override string ArchiveOriginalFileExtension { get; set; }

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