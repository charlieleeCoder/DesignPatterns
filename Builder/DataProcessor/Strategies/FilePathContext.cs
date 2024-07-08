using DataProcessor.Enums;
using DataProcessor.FileLocations;

namespace DataProcessor.Strategies;

public interface IFilePathContext
{
    public IFileLocationGroup ReturnFileLocations(Company company, Report report);
}

public class FilePathContext : IFilePathContext
{

    public IFileLocationGroup ReturnFileLocations(Company company, Report report)
    {
        // Get file path
        IFileLocationGroup filePaths = company switch
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
