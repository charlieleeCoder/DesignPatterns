using DataProcessor.FileLocations;
namespace DataProcessor.Components.FileIdentifiers;

public interface IFileLocationVerifier
{
    public abstract IFileGroup GetCorrectFileLocations(IFileGroup expectedFileLocations);
}

public class FileLocationVerifier : IFileLocationVerifier
{
    public IFileGroup GetCorrectFileLocations(IFileGroup expectedFileLocations) 
    {
        return expectedFileLocations;
    }
}
