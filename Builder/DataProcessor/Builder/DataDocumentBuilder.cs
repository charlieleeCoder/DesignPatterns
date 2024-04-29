using System;

public class DataDocumentBuilder
{
	IDataReader? _dataReader { get; set; }
	IDataProcessor? _dataProcessor { get; set; }
	IDataWriter? _dataWriter { get; set; }
	IDataSender? _dataSender { get; set; }

	public void Build()
	{
        // To implement
        // return null;
	}
}
