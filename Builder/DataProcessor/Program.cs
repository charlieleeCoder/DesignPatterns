using DataValidation;
using DataPipelineBuilder;
using DocumentPipeline;

namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt for a colour arg
            Console.WriteLine("Give me a colour: ");

            // Must be a better way to ignore the null warning
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Program requires input...");
            }

            // Set up colourValiation
            var colourValidator = new ValidatedColour()
            {
                Colour = input
            };

            // We now have a validated colour
            string validColour = colourValidator.Colour;

            // Now return builder
            SelectBuilder builderContext = new(validColour);
            IDataBuilder concreteBuilder = builderContext.ReturnBuilder();
            IDocumentPipeline documentPipeline = concreteBuilder.Build();

            // Call composed methods
            documentPipeline.GetData();
            documentPipeline.ProcessData();
            documentPipeline.WriteData();
            documentPipeline.SendFile();
            documentPipeline.ArchiveFiles();
            
        }
    }
}
