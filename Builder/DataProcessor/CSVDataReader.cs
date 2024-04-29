using System;

public class CSVDataReader: IDataReader
{
	public void ReadData(string FilePath)
	{
		// To implement
	}
	public Data GetData()
	{
		return new Data() { Rows = ["one","two"] };
	}
}
