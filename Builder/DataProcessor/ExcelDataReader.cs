using System;

public class CSVDataReader: IDataReader
{
    // Create private
    private Data _data = new();
    // Open file at filepath, store in _data 
	public void ReadData(string filePath)
    {
        // Temp var
        List<string> data = [];  
        try
        {
            // Using is equivalent of with open file as
            using (StreamReader reader = new(filePath))
            {
                // While not EOF
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    data.Add(line!);
                }
            }
        }
        catch (ArgumentException ex) 
        { 
            
        }
        // General exception type, as could be multiple causes
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            throw;
        }
        // Assign to 
        _data.Rows = data;
    }
    public Data GetData()
	{
        // TODO: implement
        return new Data() { Rows = ["one","two"] };
	}
}
