using System;

public class EmailDataSender: IDataSender
{
    public void SendData(string filePath, string endLocation)
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
