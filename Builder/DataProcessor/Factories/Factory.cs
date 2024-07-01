using DataProcessor.Enums;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.ComponentStrategies;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;
using DataProcessor.FileLocations;
using DataProcessor.Strategies;

namespace DataProcessor.Factories;

public interface IFactory
{
    public Company Company { get; set; }
    public Report Report { get; set; }
    public IDocumentPipeline ReturnDocumentPipeline();
}

public class Factory : IFactory
{

    private IDocumentPipelineBuilder Builder = new DocumentPipelineBuilder();

    // Need setting
    public Company Company  { get; set; }
    public Report Report    { get; set; }

    // Constructor
    public Factory(Company company, Report report)
    {
        Company = company;
        Report = report;
    }

    // Factory Method
    public IDocumentPipeline ReturnDocumentPipeline()
    {
        
        // Get strategy
        BaseComponentStrategy Strategy = Company switch
        {
            Company.MuffinsMuffins  => new ProcessedCSVSentByEmail(),
            Company.NotRealLtd      => new UnprocessedExcelSentViaSFTP(),
            Company.MadeUpCo        => new ProcessedCSVConvertedtoExcelSentViaSFTP(),
            Company.NotGenericCo    => new UnprocessedCSVSentByWebDriver(),
            _                       => throw new NotImplementedException()
        };

        // Relevant filepaths
        IFilePathContext FilePathContext = new FilePathContext();
        IFileLocations FilePaths = FilePathContext.ReturnFileLocations(Company, Report);

        // Create pipeline
        IDocumentPipeline Pipeline = Builder.SetCompany(Company)
                                    .SetFileLocations(FilePaths)
                                    .BuildDataReader((IDataReader)Activator.CreateInstance(Strategy.Reader)!)
                                    .BuildDataProcessor((IDataProcessor)Activator.CreateInstance(Strategy.Processor)!)
                                    .BuildDataWriter((IDataWriter)Activator.CreateInstance(Strategy.Writer)!)
                                    .BuildFileSender((IFileSender)Activator.CreateInstance(Strategy.Sender)!)
                                    .BuildFileArchiver((IFileArchiver)Activator.CreateInstance(Strategy.Archiver)!)
                                    .Build();

        // Now return, fully-built, to main
        return Pipeline;
    }
}
