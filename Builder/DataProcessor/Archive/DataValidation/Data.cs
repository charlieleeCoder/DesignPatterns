namespace DataValidation;
public class Data
{
	// Store data
    public string[]? Header {  get; set; }
	public List<string[]>? Rows { get; set; }

    // For testing only
    public void ShowHeader()
    {
        foreach (var value in Header!)
        {
            Console.Write($"{value},");
            // Remove last comma, move to new line
            Console.Write("\b\n");
        }
    }
    // For testing only
    public void ShowRows()
	{
		foreach (var row in Rows!)
		{
            foreach (string value in row) 
            {
                Console.Write($"{value},");
            }
            // Flush
            Console.WriteLine();
		}
	}
}
