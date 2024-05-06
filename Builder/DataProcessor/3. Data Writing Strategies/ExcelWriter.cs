public class ExcelWriter: IDataWriter
{
    // 
    private string? _ExcelFilePath;
    private string? _ExcelArchivePath;

    // Must write data for the processed doc to send
    public void WriteData(Data data){
        // To implement
    }

    // Return file locations for processed and original docs
    public string ReturnArchivedFilePath(){
        return _ExcelArchivePath!;
    }
    public string ReturnProcessedFilePath(){
        return _ExcelFilePath!;
    }
}