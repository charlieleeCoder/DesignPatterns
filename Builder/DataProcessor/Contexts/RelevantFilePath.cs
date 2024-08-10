using DataProcessor.Enums;
using DataProcessor.FileLocations.CompanyImplementations;
using DataProcessor.FileLocations.FileGroup;

namespace DataProcessor.Strategies;

public interface IFilePathContext
{
    public IFileGroup ReturnFileLocations(Company company, Report report);
}

public class RelevantFilePath : IFilePathContext
{

    public IFileGroup ReturnFileLocations(Company company, Report report)
    {
        // Get file path
        IFileGroup filePaths = company switch
        {
            Company.MuffinsMuffins  => new MuffinsMuffinsFiles(report),
            Company.NotRealLtd      => new NotRealLtdFiles(report),
            Company.MadeUpCo        => new MadeUpCoFiles(report),
            Company.NotGenericCo    => new NotGenericCoFiles(report),
            _                       => throw new NotImplementedException()
        };

        return filePaths;
    }
}
