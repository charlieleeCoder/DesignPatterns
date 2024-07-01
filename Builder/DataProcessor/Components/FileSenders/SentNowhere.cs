using DataProcessor.FileLocations;

namespace DataProcessor.Components.FileSenders;
public class SentNowhere : IFileSender
{
    // Must implement a method to send data
    public void SendFile(IFileLocations fileLocations)
    {
        // pass
    }

}
