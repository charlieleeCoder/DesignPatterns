using DataProcessor.Enums;

namespace DataProcessor.Components.FileLocations;

public interface IFileLocations
{
    Company Company             { get; set; }
    string CompanyName          { get; set; }
    string StartingFileLocation { get; set; }
    string DestinationLocation  { get; set; }
    string ArchiveFileLocation  { get; set; }
}
