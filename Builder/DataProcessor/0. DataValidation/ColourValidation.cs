namespace DataValidation;
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
	public string Colour {

        get {	
			return _colour.ToString().ToLower(); 
		}

        set {
			// If the colour is valid, assign to _colour
			if (ValidColour.TryParse(value, true, out _colour)){
                // Setting is done above 
            }
            else {
				throw new ArgumentException("This colour has not yet been implemented.");
			};	
		}
	}
}
