using DataProcessor.FileLocations;

namespace DataProcessor.Components.FileArchivers.Archive;

public interface IFileArchiver 
{
    public void ArchiveFiles(IFileLocations fileLocations);
}

public class SimpleFileArchiver: IFileArchiver 
{
    public void ArchiveFiles(IFileLocations fileLocations) 
    {
        // Simple implementation, assuming version number is updated in original file
        // may want to add some checking of existing file names in archive location
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

    private enum FileFormat { csv, excel, unknown }

    private FileFormat GetFileFormat(string fileName)
    {
        if (fileName.EndsWith(".csv"))
        {
            return FileFormat.csv;
        }
        else if (fileName.EndsWith(".xlsx"))
        {
            return FileFormat.excel;
        }
        else 
        {
            return FileFormat.unknown;
        }
    }

    private enum FileType { starting, processing }

    private string ModifyFileName(string fileName, FileType fileType)
    {

        FileFormat format = GetFileFormat(fileName);
        
        return fileType switch
        {
            FileType.starting => "ORIGINAL",
            FileType.processing => "SENT"
        }
    }
}