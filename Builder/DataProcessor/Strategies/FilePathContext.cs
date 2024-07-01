using DataProcessor.Enums;
namespace DataProcessor.FileLocations;

public interface IFilePathContext
{
    public IFileLocations ReturnFileLocations(Report report, Company company);
}

public class FilePathContext : IFilePathContext
{

    public IFileLocations ReturnFileLocations(Report report, Company company)
    {
        // Get file path
        IFileLocations filePaths = company switch
        {
            Company.MuffinsMuffins      => new MuffinsMuffinsFiles(report),
            Company.NotRealLtd          => new NotRealLtdFiles(report),
            Company.MadeUpCo            => new MadeUpCoFiles(report),
            Company.NotGenericCo        => new NotGenericCoFiles(report),
            _                           => throw new NotImplementedException()
        };

        return filePaths;
    }
}
