public class CSVWriter: IDataWriter
{
    // 
    private string? _csvFilePath;
    private string? _csvArchivePath;

    // Must write data for the processed doc to send
    public void WriteData(Data data)
    {
        // To implement
    }

    // Return file locations for processed and original docs
    public string ReturnArchivedFilePath()
    {
        return _csvArchivePath!;
    }
    public string ReturnProcessedFilePath()
    {
        return _csvFilePath!;
    }
}