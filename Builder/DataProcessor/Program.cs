namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt for a colour arg
            Console.WriteLine("Give me a colour.");

            // Must be a better way to ignore the null warning without changing to nullable type?
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Program requires input...");
            }

            // Set up colourValiation
            var colourValidator = new ColourValidation()
            {
                Colour = input
            };

            // We now have a validated colour
            string validColour = colourValidator.Colour;
        }
    }
}
