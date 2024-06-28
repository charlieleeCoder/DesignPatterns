using DataProcessor.Enums;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.Strategies;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;

namespace DataProcessor.Factories;

public interface IFactory
{
    public Company Company { get; set; }
    public IDocumentPipeline FactoryMethod();
}

public class Factory : IFactory
{

    private IDocumentPipelineBuilder Builder = new DocumentPipelineBuilder();

    public Company Company { get; set; }

    public IDocumentPipeline FactoryMethod()
    {
        BaseStrategy Strategy = Company switch
        {
            Company.MuffinsMuffins  => new ProcessedCSVSentByEmail(),
            Company.NotRealLtd      => new UnprocessedExcelSentViaSFTP(),
            Company.MadeUpCo        => new ProcessedCSVConvertedtoExcelSentViaSFTP(),
            Company.NotGenericCo    => new UnprocessedCSVSentByWebDriver(),
            _                       => throw new NotImplementedException()
        };

        IDocumentPipeline Pipeline = Builder.SetCompany(Company)
                                    .BuildDataReader((IDataReader)Activator.CreateInstance(Strategy.Reader)!)
                                    .BuildDataProcessor((IDataProcessor)Activator.CreateInstance(Strategy.Processor)!)
                                    .BuildDataWriter((IDataWriter)Activator.CreateInstance(Strategy.Writer)!)
                                    .BuildFileSender((IFileSender)Activator.CreateInstance(Strategy.Sender)!)
                                    .BuildFileArchiver((IFileArchiver)Activator.CreateInstance(Strategy.Archiver)!)
                                    .Build();

        // now return, fully built, to main
        return Pipeline;
    }
}
