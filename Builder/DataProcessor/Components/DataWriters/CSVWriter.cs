using Microsoft.Data.Analysis;

namespace Writer;
public class CSVWriter: IDataWriter
{
    private string? _csvFilePath;
    private string? _csvArchivePath;

    // Must write data for the processed doc to send
    public void WriteData(DataFrame data)
    {
        // To implement
    }
}