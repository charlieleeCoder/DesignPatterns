using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataWriters;
public class CSVWriter: IDataWriter
{
    // Must write data for the processed doc to send
    public void WriteData(DataFrame data, string writeLocation)
    {
        // Save to a csv
        DataFrame.SaveCsv(data, writeLocation, separator: ',', header: true);
    }
}