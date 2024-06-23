using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public abstract class BaseStrategy
{
    public Colour? Colour;
    public Type? Reader;
    public Type? Processor;
    public Type? Writer;
    public Type? Sender;
    public Type? Archiver;
}
