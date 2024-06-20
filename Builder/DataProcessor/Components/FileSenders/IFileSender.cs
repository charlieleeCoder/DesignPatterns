namespace DataProcessor.Components.FileSenders;
public interface IFileSender
{
    // Must implement a method to send data
    void SendFile(string filePath, string endLocation);

}
