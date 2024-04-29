// Implement interface
public class CSVDataReader: IDataReader
{
    // Create private property
    private Data _data = new();

    // Open file at filepath, to store in _data 
	public void ReadData(string filePath)
    {
        // Data values
        string[] header = [];
        List<string[]> data = [];  

        // Temp variables for unpacking
        string[] line;
        bool headerRow = true;

        // Try except block
        try {
            // Equivalent of with open file as
            using (StreamReader reader = new(filePath))
            {
                // While not EOF
                while (!reader.EndOfStream)
                {
                    // First line only
                    if (headerRow) {
                        header = reader.ReadLine()!.Split(',');
                        headerRow = false;
                    }
                    // Rest
                    else {
                        line = reader.ReadLine()!.Split(',');
                        data.Add(line);
                    }
                }
            }
        }
        // Specific exceptions
        catch (ArgumentNullException ex) 
        { 
            Console.WriteLine($"Null exception. Is the document empty? {ex.Message}");
            throw;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IOException. Please ensure the document is closed. {ex.Message}");
            throw;
        }
        // General uncaught exceptions
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
            throw;
        }

        // Assign to property
        _data.Rows = data;
        _data.Header = header;
    }
    public Data GetData()
	{
        // Return
        return _data;
	}
}
