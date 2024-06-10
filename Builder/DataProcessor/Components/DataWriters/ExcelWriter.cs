using Microsoft.Data.Analysis;

namespace Writer;
public class ExcelWriter: IDataWriter
{
    // 
    private string? _ExcelFilePath;
    private string? _ExcelArchivePath;

    // Must write data for the processed doc to send
    public void WriteData(DataFrame data){
        // To implement
    }
}