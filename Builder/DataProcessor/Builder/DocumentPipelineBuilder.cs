﻿using DataProcessor.Enums;
using Reader;
using Processor;
using Writer;
using Sender;
using Archiver;
using DataProcessor.DocumentPipeline;
using DataProcessor.DocumentPipeline.Interface;
using DataProcessor.Builder.Interface;

namespace DataProcessor.Builder;
public class FullDocumentPipelineBuilder : IDocumentPipelineBuilder
{
    // Relevant strategies for Blue implementation
    private IDocumentPipeline _documentPipeline = new FullDocumentPipeline();

    // Overarching approach param
    public IDocumentPipelineBuilder SetColour(Colour colour)
    {
        _documentPipeline.Colour = colour;
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
        // Asign temp var
        IDocumentPipeline _temp = _documentPipeline;

        // Create a new ref
        Reset();

        // Return local variable
        return _temp!;
    }

    public void Reset()
    {
        _documentPipeline = new FullDocumentPipeline();
    }
}