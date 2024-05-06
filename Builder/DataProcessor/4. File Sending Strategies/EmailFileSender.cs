namespace Sender;
public class EmailFileSender: IFileSender
{
    public void SendFile(string filePath, string endLocation)
    {
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
