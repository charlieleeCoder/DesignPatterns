using DataValidation;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DocumentPipeline;
public class FullDocumentPipelineAlternative: IDocumentPipelineAlternative {

    // Implement interface
    public string? _colour                  {get; set;}
    public IDataReader? _dataReader         {get; set;}
    public IDataProcessor? _dataProcessor   {get; set;}
    public IDataWriter? _dataWriter         {get; set;}
    public IFileSender? _fileSender         {get; set;}
    public IFileArchiver? _fileArchiver     {get; set;}

    // Record keeping
    private Data? _data;
	private Data? _processedData;

    // File path variables
    private string? _startPath;
    private string? _sendDestination;
	private string? _archivePath;

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

    // Call writer
	public void WriteData()
	{
		_dataWriter.WriteData(_processedData!);
	}

	// Call send method
	public void SendFile(){
		_fileSender.SendFile(_startPath!, _sendDestination!);
	}

	// Call archiver
	public void ArchiveFiles(){
        _fileArchiver.ArchiveFiles(_archivePath!);
	}
}