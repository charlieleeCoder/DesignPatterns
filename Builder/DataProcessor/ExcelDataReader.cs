using System;
using Excel = Microsoft.Office.Interop.Excel;

public class ExcelDataReader: IDataReader
{
	public void ReadData(string FilePath)
	{
        // TODO: implement
        
    }
	public Data GetData()
	{
        // TODO: implement
        return new Data() { Rows = ["one","two"] };
	}
}
