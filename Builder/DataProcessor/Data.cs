using System;

public class Data
{
	// Store data
    public string[]? Header {  get; set; }
	public List<string[]>? Rows { get; set; }

    // For testing only
    public void ShowHeader()
    {
        foreach (var row in Header!)
        {
            Console.WriteLine(row);
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
