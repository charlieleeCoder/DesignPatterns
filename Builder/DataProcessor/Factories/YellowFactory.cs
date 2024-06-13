using Archiver;
using DataProcessor.Builder.Interface;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline.Interface;
using DataProcessor.DocumentPipeline;
using DataProcessor.Enums;
using Processor;
using Reader;
using Sender;
using Writer;

namespace DataProcessor.Factories
{
    public class YellowFactory
    {
        private IDocumentPipelineBuilder YellowProductBuilder = new FullDocumentPipelineBuilder();

        public IDocumentPipeline FactoryMethod()
        {
            FullDocumentPipeline RedPipeline = (FullDocumentPipeline)YellowProductBuilder.SetColour(Colour.yellow)
                                                      .BuildDataReader(new CSVDataReader())
                                                      .BuildDataProcessor(new RemoveCancelled())
                                                      .BuildDataWriter(new CSVWriter())
                                                      .BuildFileSender(new SFTPFileSender())
                                                      .BuildFileArchiver(new SimpleFileArchiver())
                                                      .Build();

            // Now return, fully built, to main
            return RedPipeline;
        }
    }
}
