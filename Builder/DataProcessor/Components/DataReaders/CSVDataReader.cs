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
        // Error handling
        if (startLocation == null)
        {
            throw new ArgumentNullException(nameof(startLocation));
        }

        // Hand back DataFrame
        try
        {
            DataFrame Data = DataFrame.LoadCsv(startLocation, encoding: _encoding);
            return Data;
        }

        catch (System.IO.IOException) 
        {
            throw new System.IO.IOException($"The file {startLocation} is currently open and needs to be closed.");
        }

    }
}
