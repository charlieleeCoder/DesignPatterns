using DataProcessor.Enums;

namespace DataProcessor.Strategies;

public abstract class BaseStrategy
{
    public Colour Colour { get; set; } = default!; // Non-nullable
    public Type Reader { get; set; } = default!;
    public Type Processor { get; set; } = default!;
    public Type Writer { get; set; } = default!;
    public Type Sender { get; set; } = default!;
    public Type Archiver { get; set; } = default!;

}
