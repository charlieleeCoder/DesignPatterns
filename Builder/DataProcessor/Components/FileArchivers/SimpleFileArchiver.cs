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
            if ( File.Exists(originalFilePath) && !File.Exists(originalArchivePath) ) 
            {
                File.Move(originalFilePath, originalArchivePath);
                Console.WriteLine("Original files moved successfully!");
            } 
            
            else if ( !File.Exists(originalFilePath) )
            {
                throw new IOException("The original document is missing.");
            }
            
            else if (File.Exists(originalArchivePath))
            {
                throw new IOException($"There is a version mismatch and {originalFilePath} cannot be archived to {originalArchivePath}, as that file already exists.");
            }

            if ( File.Exists(processedFilePath) && !File.Exists(processedArchivePath) )
            {
                File.Move(processedFilePath, processedArchivePath);
                Console.WriteLine("Files moved successfully!");
            }

            else if (!File.Exists(processedFilePath))
            {
                throw new IOException("The processed document is missing.");
            }

            else if (File.Exists(processedArchivePath))
            {
                throw new IOException($"There is a version mismatch and {processedFilePath} cannot be archived to {processedArchivePath}, as that file already exists.");
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
}