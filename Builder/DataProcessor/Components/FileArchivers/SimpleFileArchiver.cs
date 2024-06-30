using DataProcessor.FileLocations;

namespace DataProcessor.Components.FileArchivers;

public interface IFileArchiver 
{
    public void ArchiveFiles(IFileLocations fileLocations);
}

public class SimpleFileArchiver: IFileArchiver 
{
    public void ArchiveFiles(IFileLocations fileLocations) 
    {
        // Simple implementation, assuming version number is updated in original file
        try
        {
            File.Move(fileLocations.StartingFileLocation, fileLocations.ArchiveFileLocation);
            Console.WriteLine("File moved successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error moving file: {ex.Message}");
        }
    }
}