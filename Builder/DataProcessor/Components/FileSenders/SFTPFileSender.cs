namespace Sender;
public class SFTPFileSender: IFileSender
{
	public void SendFile(string filePath, string endLocation)
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
