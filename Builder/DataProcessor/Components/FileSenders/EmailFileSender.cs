using DataProcessor.FileLocations;

namespace DataProcessor.Components.FileSenders;
public class EmailFileSender: IFileSender
{
    public void SendFile(IFileLocations fileLocations)
    {
        // Select file
        if (!File.Exists(fileLocations.ProcessingPathFileExtension))
        {
            throw new ArgumentException($"File does not exist at {fileLocations.ProcessingPathFileExtension}");
        }
        

    }
}
