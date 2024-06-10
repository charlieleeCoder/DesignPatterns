namespace DataProcessor.Archive.DataValidation;
public class ValidatedColour
{
    // Define valid colours
    public enum ValidColour
    {
        red,
        green,
        blue,
        yellow
    }

    private ValidColour _colour;
    public string Colour
    {

        get
        {
            return _colour.ToString().ToLower();
        }

        set
        {
            // If the Colour is valid, assign to _colour
            if (Enum.TryParse(value, true, out _colour))
            {
                // Setting is done above 
            }
            else
            {
                throw new ArgumentException("This Colour has not yet been implemented.");
            };
        }
    }
}
