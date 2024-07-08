using DataProcessor.FileLocations;

namespace DataProcessor.Components.FileSenders;
public class SFTPFileSender: IFileSender
{
	public void SendFile(string fileToSend, string destinationLocation)
	{
		// Create SFTP connection

		//// Select file
		//if (File.Exists(fileLocations.ProcessingFileLocation))
		//{

		//}
		//else
		//{
		//	throw new ArgumentException($"File does not exist at {fileLocations.ProcessingFileLocation}");
		//}
	}
}
