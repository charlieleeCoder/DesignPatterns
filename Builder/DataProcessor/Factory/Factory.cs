using DataProcessor.Enums;
using DataProcessor.Builder;
using DataProcessor.DocumentPipeline;
using DataProcessor.ComponentsRequired;
using DataProcessor.Strategies;
using DataProcessor.FileLocations.FileGroup;

namespace DataProcessor.Factory;

public interface IFactory
{
    public Company Company { get; set; }
    public Report Report { get; set; }
    public IDocumentPipeline ReturnDocumentPipeline();
}

public class Factory(Company company, Report report) : IFactory
{
    // Could other forms of pipeline builder exist in the future?
    private readonly IDocumentPipelineBuilder Builder = new DocumentPipelineBuilder();

    // Set from constructor
    public Company Company  { get; set; } = company;
    public Report Report    { get; set; } = report;

    // Factory Method
    public IDocumentPipeline ReturnDocumentPipeline()
    {

        // Get strategy
        IComponentList components = ComponentSelector.ReturnComponentsList(Company);
        Console.WriteLine(components.ToString());

        // Relevant filepaths
        IFilePathContext FilePathContext = new RelevantFilePath();
        IFileGroup FilePaths = FilePathContext.ReturnFileLocations(Company, Report);

        Console.WriteLine(Company);
        Console.WriteLine(Report);

        // Create pipeline
        IDocumentPipeline Pipeline = Builder.SetCompany(Company)
                                    .SetFileLocations(FilePaths)
                                    .BuildFileVerifier(components.Verifier)
                                    .BuildDataReader(components.Reader!)
                                    .BuildDataProcessor(components.Processor!)
                                    .BuildDataWriter(components.Writer!)
                                    .BuildFileSender(components.Sender)
                                    .BuildFileArchiver(components.Archiver)
                                    .Build();

        // Now return, fully-built, to main
        return Pipeline;
    }
}
