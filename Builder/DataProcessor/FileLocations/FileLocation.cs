namespace DataProcessor.FileLocations;

public interface IFileLocation
{
    public string GetFileLocation();
}


public class FileLocation(string filePath, string fileName, string fileExtension) : IFileLocation
{
    public string FilePath      { get; set; } = filePath;
    public string FileName      { get; set; } = fileName;
    public string FileExtension { get; set; } = fileExtension;

    public string GetFileLocation()
    {
        return $"{FilePath}{FileName}{FileExtension}";
    }
}
