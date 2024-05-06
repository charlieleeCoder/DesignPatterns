using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DocumentPipeline;

namespace DataPipelineBuilder;
public class BlueDataBuilderWithMethods: IDataBuilderWithMethods
{
	// Relevant strategies for Blue implementation
	private IDataReader? _dataReader;
	private IDataProcessor? _dataProcessor;
	private IDataWriter? _dataWriter;
	private IFileSender? _fileSender;
	private IFileArchiver? _fileArchiver;

	// Overarching approach param
	private static string _colour = "Blue";

	// Set method to read initial file
	public void BuildDataGetter()
	{
		_dataReader = new ExcelDataReader();
	}

	// Set processing method
	public void BuildDataProcessor()
	{
		_dataProcessor = new RemoveCancelled();
	}

	// Set writer
	public void BuildDataWriter()
	{
		_dataWriter = new ExcelWriter();
	}

	// Set send method
	public void BuildFileSender(){
		_fileSender = new EmailFileSender();
	}

	// Set archiver
	public void BuildFileArchiver(){
		_fileArchiver = new SimpleFileArchiver();
	}

	// Main call
	public IDocumentPipeline Build(){

		BuildDataGetter();
		BuildDataProcessor();
		BuildDataWriter();
		BuildFileSender();
		BuildFileArchiver();

		if (   _colour != null 
			&& _dataReader != null
			&& _dataProcessor != null
			&& _dataWriter != null
			&& _fileSender != null
			&& _fileArchiver != null) {
			
			return new FullDocumentPipeline (

				colour: _colour,
				dataReader: _dataReader,
				dataProcessor: _dataProcessor,
				dataWriter: _dataWriter,
				fileSender: _fileSender,
				fileArchiver: _fileArchiver

			);
		}

		else {
			throw new ArgumentNullException("Null argument... unable to build all components.");
		}
	}
}
