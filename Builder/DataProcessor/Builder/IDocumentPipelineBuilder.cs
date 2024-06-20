using DataProcessor.Enums;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProccessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;
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
