using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DocumentPipeline;

namespace DataPipelineBuilder;
public class BlueDataBuilder: IDataBuilder
{
	// Relevant strategies for Blue implementation
	private IDataReader _dataReader = new ExcelDataReader();
	private IDataProcessor _dataProcessor = new RemoveCancelled();
	private IDataWriter _dataWriter = new ExcelWriter();
	private IFileSender _fileSender  = new EmailFileSender();
	private IFileArchiver _fileArchiver = new SimpleFileArchiver();

	// Overarching approach param
	private static string _colour = "Blue";

	// Main call
	public IDocumentPipeline Build(){

		return new FullDocumentPipeline (

			colour: _colour,
			dataReader: _dataReader,
			dataProcessor: _dataProcessor,
			dataWriter: _dataWriter,
			fileSender: _fileSender,
			fileArchiver: _fileArchiver

			);
	}
}
