using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileLocations
{

    public MuffinsMuffinsFiles(Company company, Report report) : base(company, report)
    {

        Company = Company.MuffinsMuffins;
        DestinationLocation = $"madeupemail@{CompanyName}.com";
    }

}