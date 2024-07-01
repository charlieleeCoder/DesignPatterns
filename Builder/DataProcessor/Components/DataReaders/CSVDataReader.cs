using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;
using System.Text;

namespace DataProcessor.Components.DataReaders;
public class CSVDataReader: IDataReader
{
    // Add encoding check later, but sensible default, as more common than utf-8-sig
    private readonly Encoding _encoding = Encoding.UTF8;

    // Open file at filepath, to store in _data 
    public DataFrame ReadData(IFileLocations fileLocations)
    {
        // Error handling
        if (fileLocations == null)
        {
            throw new ArgumentNullException(nameof(fileLocations));
        }
        if (fileLocations.StartingFileExtension != ".csv")
        {
            throw new InvalidOperationException("The CSV reader can only handle CSVs.");
        }

        // Get fully qualified name
        string FullStartingFilePathAndNameAndExtension = $"{fileLocations.StartingFileLocation}{fileLocations.StartingFileName}{fileLocations.StartingFileExtension}";

        // Hand back DataFrame
        try
        {
            DataFrame Data = DataFrame.LoadCsv(FullStartingFilePathAndNameAndExtension, encoding: _encoding);
            return Data;
        }

        catch (System.IO.IOException) 
        {
            throw new System.IO.IOException($"The file {FullStartingFilePathAndNameAndExtension} is currently open and needs to be closed.");
        }

    }
}
