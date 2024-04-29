using System;

public class ColourValidation
{
	// Define valid colours
	private enum ValidColour
	{
		red, 
		green, 
		blue,
		yellow
	}

	// Validated colour
	private ValidColour _Colour;

	// Ensure valid
	public string Colour {

		// Return as string
        get {	
			return _Colour.ToString().ToLower(); 
		}
		// Validate before setting
        set {
			// If the colour is a valid option, assign to _Colour
			if (ValidColour.TryParse(value, true, out _Colour))
			{
                // Setting is done above with out.
            }
            else
			{
				throw new ArgumentException("This colour has not yet been implemented.");
			};	
		}
	}
}
