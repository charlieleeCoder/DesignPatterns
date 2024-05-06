using System;

public class SFTPDataSender: IDataSender
{
	public void SendData(string filePath, string endLocation)
	{
		// Create SFTP connection

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
