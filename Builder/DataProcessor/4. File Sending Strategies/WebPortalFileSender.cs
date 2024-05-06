namespace Sender;
public class WebPortalFileSender: IFileSender
{
    public void SendFile(string filePath, string endLocation)
    {
        // Create http connection

        // Select file
        if (File.Exists(filePath))
        {

        }
        else
        {
            throw new ArgumentException($"File does not exist at {filePath}");
        }
    }
}
