using DataProcessor.Enums;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DataProcessor.DocumentPipeline.Interface;

namespace DataProcessor.Builder.Interface;
public interface IDocumentPipelineBuilder
{
    public IDocumentPipelineBuilder SetColour(Colour colour);
    public IDocumentPipelineBuilder BuildDataReader(IDataReader dataReader);
    public IDocumentPipelineBuilder BuildDataProcessor(IDataProcessor dataProcessor);
    public IDocumentPipelineBuilder BuildDataWriter(IDataWriter dataWriter);
    public IDocumentPipelineBuilder BuildFileSender(IFileSender fileSender);
    public IDocumentPipelineBuilder BuildFileArchiver(IFileArchiver fileArchiver);
    public IDocumentPipeline Build();
    public void Reset();
}
