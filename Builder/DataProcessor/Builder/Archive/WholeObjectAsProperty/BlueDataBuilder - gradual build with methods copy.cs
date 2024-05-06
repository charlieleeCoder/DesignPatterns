using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DocumentPipeline;

namespace DataPipelineBuilder;
public class BlueDataBuilderWithGradualMethods: IDataBuilderWithGradualMethods
{
	// Relevant strategies for Blue implementation
	private IDocumentPipelineAlternative _documentPipeline = new FullDocumentPipelineAlternative();

	// Overarching approach param
	public void SetColour(string colour)
	{
		_documentPipeline._colour = colour;
	}

	// Set method to read initial file
	public void BuildDataReader(IDataReader dataReader)
	{
		_documentPipeline._dataReader = dataReader;
	}

	// Set processing method
	public void BuildDataProcessor(IDataProcessor dataProcessor)
	{
		_documentPipeline._dataProcessor = dataProcessor;
	}

	// Set writer
	public void BuildDataWriter(IDataWriter dataWriter)
	{
		_documentPipeline._dataWriter = dataWriter;
	}

	// Set send method
	public void BuildFileSender(IFileSender fileSender){
		_documentPipeline._fileSender = fileSender;
	}

	// Set archiver
	public void BuildFileArchiver(IFileArchiver fileArchiver){
		_documentPipeline._fileArchiver = fileArchiver;
	}

	// Main call
	public IDocumentPipelineAlternative Build(){

		SetColour(colour: "blue");
		BuildDataReader(dataReader: new ExcelDataReader());
		BuildDataProcessor(dataProcessor: new RemoveCancelled());
		BuildDataWriter(dataWriter: new ExcelWriter());
		BuildFileSender(fileSender: new EmailFileSender());
		BuildFileArchiver(fileArchiver: new SimpleFileArchiver());

		return _documentPipeline!;
	}
}
