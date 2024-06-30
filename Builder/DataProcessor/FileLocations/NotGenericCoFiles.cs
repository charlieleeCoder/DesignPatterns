using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotGenericCoFiles : BaseFileLocations
{

    public NotGenericCoFiles(Company company, Report report) : base(company, report)
    {

        DestinationLocation = $"www.{CompanyName}.com/upload_files/";

    }

}