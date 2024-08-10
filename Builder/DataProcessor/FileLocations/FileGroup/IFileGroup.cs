using DataProcessor.Enums;
using DataProcessor.FileLocations.FileGroup.FileGroupComponents;

namespace DataProcessor.FileLocations.FileGroup;

public interface IFileGroup
{

    // Meta info
    public abstract Company Company { get; set; }
    public abstract string CompanyName { get; set; }
    public abstract Report Report { get; set; }
    public abstract string ReportName { get; set; }

    // Folder & Filename & Extension

    // Reading
    public abstract FileLocation StartPathFile { get; set; }

    // Processing
    public abstract FileLocation ProcessingPathFile { get; set; }

    // Sending
    public abstract FileDestination DestinationLocation { get; set; }

    // Archiving
    public abstract FileLocation ArchiveSentPathFile { get; set; }
    public abstract FileLocation ArchiveOriginalPathFile { get; set; }

}