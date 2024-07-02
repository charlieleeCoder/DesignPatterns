using DataProcessor.FileLocations;
using System.Text.RegularExpressions;

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
            if (    File.Exists(fileLocations.StartPathFileExtension) 
                && !File.Exists(fileLocations.ArchiveOriginalPathFileExtension)  ) 
            {
                File.Move(fileLocations.StartPathFileExtension, fileLocations.ArchiveOriginalPathFileExtension);
                Console.WriteLine("Files moved successfully!");
            } 
            
            else if ( !File.Exists(fileLocations.StartPathFileExtension) )
            {
                throw new IOException("One of the required documents is missing.");
            }
            
            else if (File.Exists(fileLocations.ArchiveOriginalPathFileExtension))
            {
                string version = IncrementVersionNumber(fileLocations.ArchiveOriginalFileName).ToString();
            }

            if ( File.Exists(fileLocations.ProcessingPathFileExtension)
             && !File.Exists(fileLocations.ArchiveSentPathFileExtension))
            {
                File.Move(fileLocations.ProcessingPathFileExtension, fileLocations.ArchiveSentPathFileExtension);
                Console.WriteLine("Files moved successfully!");
            }


        }
        catch (IOException ex)
        {
            throw new IOException($"Error moving file: {ex.Message}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error moving file: {ex.Message}.");
        }
    }

    private static int IncrementVersionNumber(string FileNameWithVersionNumberAtEnd)
    {
        try
        {
            int CurrentVersion = (int)FileNameWithVersionNumberAtEnd[-1];
            return CurrentVersion + 1;
        }
        catch
        {
            throw new ArgumentException("Unable to parse version number.");
        }   
    }
}