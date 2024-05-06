using DocumentPipeline;

namespace DataPipelineBuilder;
public interface IDataBuilderWithMethods
{
    protected void BuildDataGetter();
    protected void BuildDataProcessor();
    protected void BuildDataWriter();
    protected void BuildFileSender();
    protected void BuildFileArchiver();
    public IDocumentPipeline Build();
}
