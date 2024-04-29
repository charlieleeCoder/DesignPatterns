using System;

public class WebPortalDataSender
{
    public void SendData(string filePath)
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
