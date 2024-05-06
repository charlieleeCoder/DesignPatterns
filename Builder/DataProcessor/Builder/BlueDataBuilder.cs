using System;

public class BlueDataBuilder: IDataBuilder
{
	// Relevant strategies for Red implmentation
	private IDataReader _dataReader = new ExcelDataReader();
	private IDataProcessor _dataProcessor = new RemoveCancelled();
	private IDataWriter _dataWriter = new ExcelWriter();
	private IDataSender _dataSender = new EmailDataSender();
	private IDataArchiver _dataArchiver = new SimpleDataArchiver();

	// Return values from functions
	private Data? _data;
	private Data? _processedData;

	// File path params
	private static string _colour = "Blue";
	private string _startPath = $"../Colours/{_colour}/UnprocessedFiles";
	private string _archivePath = $"../Colours/{_colour}/SentFiles";
	private string _endLocation = $"../Colours/{_colour}/UnprocessedFiles";

	// Set method to read initial file
	public void GetData()
	{
		_data = _dataReader.GetData();
	}

	// Set data processing
	public void ProcessData()
	{
		// Store and return
		_processedData = _dataProcessor.ProcessData(_data!);
	}

	// Set writer
	public void WriteData()
	{
		_dataWriter.WriteData(_processedData!);
	}

	// Set send method
	public void SendData(){
		_dataSender.SendData(_startPath, _endLocation);
	}

	// Set archiver
	public void ArchiveFiles(){

		// TODO: Implement
		Console.WriteLine(_archivePath);
	}
}
