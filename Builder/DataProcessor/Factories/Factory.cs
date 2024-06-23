using DataProcessor.Enums;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;

namespace DataProcessor.Factories;

public interface IFactory
{
    public IDocumentPipeline FactoryMethod();
}

public class Factory : IFactory
{
    
    private IDocumentPipelineBuilder BlueProductBuilder = new DocumentPipelineBuilder();

    public IDocumentPipeline FactoryMethod()
    {
        FullDocumentPipeline BluePipeline = BlueProductBuilder.SetColour(Colour.blue)
                                                            .BuildDataReader(new CSVDataReader())
                                                            .BuildDataProcessor(new RemoveCancelled())
                                                            .BuildDataWriter(new CSVWriter())
                                                            .BuildFileSender(new WebPortalFileSender())
                                                            .BuildFileArchiver(new SimpleFileArchiver())
                                                            .Build();

        // Now return, fully built, to main
        return BluePipeline;
    }
}
