using System;

public class WebPortalDataSender: IDataSender
{
    public void SendData(string filePath, string endLocation)
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
