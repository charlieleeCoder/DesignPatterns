using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataWriters;
public class CSVWriter: IDataWriter
{
    // Must write data for the processed doc to send
    public void WriteData(DataFrame data, IFileLocations fileLocations)
    {
        // Fully qualified path
        string FullProcessingFilePathNameAndExtension = $"{fileLocations.ProcessingFileLocation}{fileLocations.ProcessingFileName}{fileLocations.ProcessingFileExtension}";

        // Save to a csv
        DataFrame.SaveCsv(data, FullProcessingFilePathNameAndExtension, separator: ',', header: true);
    }
}