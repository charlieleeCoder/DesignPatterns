using System.Diagnostics;

namespace Archiver;

public class SimpleFileArchiver: IFileArchiver 
{
    public void ArchiveFiles(string startFilePath, string archiveFilePath) 
    {
        // Simple implementation, assuming version number is updated in original file
        // may want to add some checking of existing file names in archive location
        try
        {
            File.Move(startFilePath, archiveFilePath);
            Console.WriteLine("File moved successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error moving file: {ex.Message}");
        }
    }
}