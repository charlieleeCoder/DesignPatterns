using DataProcessor.Enums;

namespace DataProcessor.Components.FileLocations;

public class MuffinsMuffins : IFileLocations
{

    public Company Company { get; set; }
    public string CompanyName { get; set; }
    public string StartingFileLocation { get; set; }
    public string DestinationLocation { get; set; }
    public string ArchiveFileLocation { get; set; }

    public MuffinsMuffins()
    {

        Company = DataProcessor.Enums.Company.MuffinsMuffins;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        StartingFileLocation = $".\\{CompanyName}";
        DestinationLocation = $"madeupemail@{CompanyName}.com";
        ArchiveFileLocation = $".\\Archive\\{CompanyName}";

    }

}