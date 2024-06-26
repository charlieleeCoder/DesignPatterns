﻿using DataProcessor.Enums;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.ComponentsRequired;
using DataProcessor.FileLocations;
using DataProcessor.Strategies;

namespace DataProcessor.Factory;

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
        BaseComponentsRequired Strategy = Company switch
        {
            Company.MuffinsMuffins  => new UnprocessedCSVSentByEmail(),
            Company.NotRealLtd      => new ProcessedExcelSentViaSFTP(),
            Company.MadeUpCo        => new ProcessedCSVConvertedtoExcelSentViaSFTP(),
            Company.NotGenericCo    => new UnprocessedCSVSentByWebDriver(),
            _                       => throw new NotImplementedException()
        };

        Console.WriteLine(Strategy.ToString());

        // Relevant filepaths
        IFilePathContext FilePathContext = new FilePathContext();
        IFileLocations FilePaths = FilePathContext.ReturnFileLocations(Company, Report);

        Console.WriteLine(Company);
        Console.WriteLine(Report);

        // Create pipeline
        IDocumentPipeline Pipeline = Builder.SetCompany(Company)
                                    .SetFileLocations(FilePaths)
                                    .BuildDataReader(Strategy.Reader)
                                    .BuildDataProcessor(Strategy.Processor)
                                    .BuildDataWriter(Strategy.Writer)
                                    //.BuildFileSender((IFileSender)Activator.CreateInstance(Strategy.Sender)!)
                                    //.BuildFileArchiver((IFileArchiver)Activator.CreateInstance(Strategy.Archiver)!)
                                    .Build();

        // Now return, fully-built, to main
        return Pipeline;
    }
}
