using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileLocations
{
    public override string StartingFileExtension        { get; set; }
    public override string ProcessingFileExtension      { get; set; }
    public override string DestinationLocation          { get; set; }
    public override string ArchiveSentFileExtension     { get; set; }
    public override string ArchiveOriginalFileExtension { get; set; }
    public override string StartPathFileExtension       { get; set; }
    public override string ProcessingPathFileExtension  { get; set; }
    public override string ArchiveOriginalPathFileExtension { get; set; }
    public override string ArchiveSentPathFileExtension { get; set; }


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

        // Fully-qualified paths
        StartPathFileExtension = $"{this.StartingFileLocation}{this.StartingFileName}{this.StartingFileExtension}";
        ProcessingPathFileExtension = $"{this.ProcessingFileLocation}{this.ProcessingFileName}{this.ProcessingFileExtension}";
        ArchiveOriginalPathFileExtension = $"{this.ArchiveFileLocation}{this.ArchiveOriginalFileName}{this.ArchiveOriginalFileExtension}";
        ArchiveSentPathFileExtension = $"{this.ArchiveFileLocation}{this.ArchiveSentFileName}{this.ArchiveSentFileExtension}";
    }

}