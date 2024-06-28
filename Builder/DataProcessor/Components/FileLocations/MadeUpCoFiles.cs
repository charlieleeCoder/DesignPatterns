using DataProcessor.Enums;

namespace DataProcessor.Components.FileLocations;

public class MadeUpCoFiles : IFileLocations
{

    public Company Company { get; set; }
    public string CompanyName { get; set; }
    public string StartingFileLocation { get; set; }
    public string DestinationLocation { get; set; }
    public string ArchiveFileLocation { get; set; }

    public MadeUpCoFiles() 
    {

        Company = DataProcessor.Enums.Company.MadeUpCo;
        CompanyName = CompanyDictionary.CompanyLookup[Company];
        StartingFileLocation = $".\\{CompanyName}";
        DestinationLocation = "sftp example@255.255.0.1";
        ArchiveFileLocation = $".\\Archive\\{CompanyName}";

    }

}
