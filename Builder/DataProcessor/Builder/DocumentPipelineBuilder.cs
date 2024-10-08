﻿using DataProcessor.Enums;
using DataProcessor.Components.DataReaders;
using DataProcessor.Components.DataProcessors;
using DataProcessor.Components.DataWriters;
using DataProcessor.Components.FileSenders;
using DataProcessor.Components.FileArchivers;
using DataProcessor.DocumentPipeline;
using DataProcessor.Components.FileIdentifiers;
using DataProcessor.FileLocations.FileGroup;

namespace DataProcessor.Builder;

// Interface
public interface IDocumentPipelineBuilder
{
    public IDocumentPipelineBuilder SetCompany(Company company);
    public IDocumentPipelineBuilder SetFileLocations(IFileGroup fileLocations);
    public IDocumentPipelineBuilder BuildFileVerifier(IFileLocationVerifier fileVerifier);
    public IDocumentPipelineBuilder BuildDataReader(IDataReader dataReader);
    public IDocumentPipelineBuilder BuildDataProcessor(IDataProcessor dataProcessor);
    public IDocumentPipelineBuilder BuildDataWriter(IDataWriter dataWriter);
    public IDocumentPipelineBuilder BuildFileSender(IFileSender fileSender);
    public IDocumentPipelineBuilder BuildFileArchiver(IFileArchiver fileArchiver);
    public IDocumentPipeline Build();
    public void Reset();
}

// Implement
public class DocumentPipelineBuilder : IDocumentPipelineBuilder
{
    // Relevant strategies for Blue implementation
    private IDocumentPipeline _documentPipeline = new DocumentPipeline.DocumentPipeline();

    // Overarching approach param
    public IDocumentPipelineBuilder SetCompany(Company company)
    {
        _documentPipeline.Company = company;
        return this;
    }

    // Overarching approach param
    public IDocumentPipelineBuilder SetFileLocations(IFileGroup fileLocations)
    {
        _documentPipeline.FileLocations = fileLocations;
        return this;
    }

    // Verify the version number and date are as we expect
    public IDocumentPipelineBuilder BuildFileVerifier(IFileLocationVerifier fileVerifier)
    {
        _documentPipeline.FileVerifier = fileVerifier;
        return this;
    }

    // Set method to read initial file
    public IDocumentPipelineBuilder BuildDataReader(IDataReader dataReader)
    {
        _documentPipeline.DataReader = dataReader;
        return this;
    }

    // Set processing method
    public IDocumentPipelineBuilder BuildDataProcessor(IDataProcessor dataProcessor)
    {
        _documentPipeline.DataProcessor = dataProcessor;
        return this;
    }

    // Set writer
    public IDocumentPipelineBuilder BuildDataWriter(IDataWriter dataWriter)
    {
        _documentPipeline.DataWriter = dataWriter;
        return this;
    }

    // Set send method
    public IDocumentPipelineBuilder BuildFileSender(IFileSender fileSender)
    {
        _documentPipeline.FileSender = fileSender;
        return this;
    }

    // Set archiver
    public IDocumentPipelineBuilder BuildFileArchiver(IFileArchiver fileArchiver)
    {
        _documentPipeline.FileArchiver = fileArchiver;
        return this;
    }

    // Main call
    public IDocumentPipeline Build()
    {
        if (_documentPipeline == null)
        {
            throw new NullReferenceException("No document pipeline exists.");
        }
        
        // Asign temp var
        IDocumentPipeline _temp = _documentPipeline;

        // Create a new ref
        Reset();

        // Test
        Console.WriteLine(_temp);

        // Return local variable
        return _temp!;
    }

    public void Reset()
    {
        _documentPipeline = new DocumentPipeline.DocumentPipeline();
    }
}
