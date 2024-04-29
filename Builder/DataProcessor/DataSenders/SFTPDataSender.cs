using System;

public class SFTPDataSender
{
	public void SendData(string filePath)
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
