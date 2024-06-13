using Archiver;
using DataProcessor.Builder.Interface;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.DocumentPipeline.Interface;
using DataProcessor.Enums;
using Processor;
using Reader;
using Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;

namespace DataProcessor.Factories
{
    public class RedFactory
    {
        private IDocumentPipelineBuilder RedProductBuilder = new FullDocumentPipelineBuilder();

        public IDocumentPipeline FactoryMethod()
        {
            FullDocumentPipeline RedPipeline = (FullDocumentPipeline)RedProductBuilder.SetColour(Colour.red)
                                                      .BuildDataReader(new ExcelDataReader())
                                                      .BuildDataProcessor(new RemoveCancelled())
                                                      .BuildDataWriter(new ExcelWriter())
                                                      .BuildFileSender(new EmailFileSender())
                                                      .BuildFileArchiver(new SimpleFileArchiver())
                                                      .Build();

            // Now return, fully built, to main
            return RedPipeline;
        }
    }
}
