using Archiver;
using DocumentPipeline;
using Processor;
using Reader;
using Sender;
using Writer;

namespace DataPipelineBuilder;
public interface IDataBuilderWithGradualMethods
{
    public void SetColour(string colour);
    public void BuildDataReader(IDataReader dataReader);
    public void BuildDataProcessor(IDataProcessor dataProcessor);
    public void BuildDataWriter(IDataWriter dataWriter);
    public void BuildFileSender(IFileSender fileSender);
    public void BuildFileArchiver(IFileArchiver fileArchiver);
    public IDocumentPipelineAlternative Build();
}
