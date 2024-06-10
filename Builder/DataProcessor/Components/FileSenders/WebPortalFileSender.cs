namespace Sender;
public class WebPortalFileSender: IFileSender
{
    public void SendFile(string filePath, string endLocation)
    {
        // Create HTTP connection

        // Run selenium webdriver

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
