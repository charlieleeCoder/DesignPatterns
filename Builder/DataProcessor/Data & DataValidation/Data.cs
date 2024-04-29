using System;

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
            Console.WriteLine(value);
        }
    }
    // For testing only
    public void ShowData()
	{
		foreach (var row in Rows!)
		{
            foreach (string value in row) {
                Console.Write(value);
            }
            // Flush
            Console.WriteLine();
		}
	}
}
