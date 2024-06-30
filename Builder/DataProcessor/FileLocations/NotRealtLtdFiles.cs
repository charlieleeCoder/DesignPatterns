using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotRealLtdFiles : BaseFileLocations
{

    public NotRealLtdFiles(Company company, Report report) : base(company, report)
    {

        DestinationLocation = $"sftp example@255.255.0.5";

    }

}
