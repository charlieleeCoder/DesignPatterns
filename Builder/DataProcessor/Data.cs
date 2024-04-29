using System;

public class Data
{
	// Store data
	public List<string>? Rows { get; set; }

	// For testing
	public void Show()
	{
		foreach (var row in Rows!)
		{
			Console.WriteLine(row);
		}
	}
}
