using System;

public class EmailDataSender
{
    public void SendData(string filePath)
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
