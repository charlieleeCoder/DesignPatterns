using DataProcessor.FileLocations;
using System.Text.RegularExpressions;

namespace DataProcessor.Components.FileArchivers;

public interface IFileArchiver 
{
    public void ArchiveFiles(string originalFilePath, string originalArchivePath, string processedFilePath, string processedArchivePath);
}

public class SimpleFileArchiver: IFileArchiver 
{
    public void ArchiveFiles(string originalFilePath, string originalArchivePath, string processedFilePath, string processedArchivePath) 
    {
        // Simple implementation, assuming version number is updated in original file
        try
        {
            if (    File.Exists(originalFilePath) 
                && !File.Exists(originalArchivePath)  ) 
            {
                File.Move(originalFilePath, originalArchivePath);
                Console.WriteLine("Files moved successfully!");
            } 
            
            else if ( !File.Exists(originalFilePath) )
            {
                throw new IOException("One of the required documents is missing.");
            }
            
            else if (File.Exists(originalArchivePath))
            {
                string version = IncrementVersionNumber(originalArchivePath).ToString();
            }

            if ( File.Exists(processedFilePath)
             && !File.Exists(processedArchivePath))
            {
                File.Move(processedFilePath, processedArchivePath);
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