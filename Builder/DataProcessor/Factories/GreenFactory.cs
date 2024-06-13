using Archiver;
using DataProcessor.Builder.Interface;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.DocumentPipeline.Interface;
using DataProcessor.Enums;
using Processor;
using Reader;
using Sender;
using Writer;

namespace DataProcessor.Factories
{
    public class GreenFactory
    {
        private IDocumentPipelineBuilder GreenProductBuilder = new FullDocumentPipelineBuilder();

        public IDocumentPipeline FactoryMethod()
        {
            FullDocumentPipeline GreenPipeline = (FullDocumentPipeline)GreenProductBuilder.SetColour(Colour.green)
                                                                  .BuildDataReader(new ExcelDataReader())
                                                                  .BuildDataProcessor(new RemoveCancelled())
                                                                  .BuildDataWriter(new ExcelWriter())
                                                                  .BuildFileSender(new SFTPFileSender())
                                                                  .BuildFileArchiver(new SimpleFileArchiver())
                                                                  .Build();

            // Now return, fully built, to main
            return GreenPipeline;
        }
    }
}
