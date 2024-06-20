using System.Diagnostics;
using System;
using System.IO;

namespace DataProcessor.Components.FileArchivers;

public interface IFileArchiver 
{
    public void ArchiveFiles(string startFilePath, string archiveFilePath);
}

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