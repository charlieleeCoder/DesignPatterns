using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;
using System.Text;

namespace DataProcessor.Components.DataReaders;
public class CSVDataReader: IDataReader
{
    // Add encoding check later, but sensible default, as more common than utf-8-sig
    private readonly Encoding _encoding = Encoding.UTF8;

    // Open file at filepath, to store in _data 
    public DataFrame ReadData(string startLocation)
    {
        // Error handling for when version number is not 1 or date is backdated
        if (!File.Exists(startLocation))
        {
            // This shouldn't ever trigger, as file verifier in place
            throw new FileNotFoundException($"Cannot find {startLocation}");
        }

        // Hand back DataFrame
        try
        {
            DataFrame Data = DataFrame.LoadCsv(startLocation, encoding: _encoding);
            return Data;
        }

        // Specific catch
        catch (IOException) 
        {
            throw new IOException($"The file {startLocation} is currently open and needs to be closed.");
        }

        // General catch
        catch (Exception) 
        {
            throw;
        }

    }
}
