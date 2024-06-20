using DataProcessor.Builder.Interface;
using DataProcessor.Builder;
using DataProcessor.Enums;
using DataProcessor.DocumentPipeline;
using DataProcessor.DocumentPipeline.Interface;
using DataProcessor.Factories.Interface;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;

namespace DataProcessor.Factories
{
    public class BlueFactory : IFactory
    {
        
        private IDocumentPipelineBuilder BlueProductBuilder = new FullDocumentPipelineBuilder();

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
}
