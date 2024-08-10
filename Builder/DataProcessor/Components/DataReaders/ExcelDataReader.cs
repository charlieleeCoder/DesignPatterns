using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataReaders;
public class ExcelDataReader: IDataReader
{
	public DataFrame ReadData(string startLocation)
	{
        // Error handling
        ArgumentNullException.ThrowIfNull(startLocation);

        // This handles .xlsx as well as csv, but don't add encoding
        DataFrame dataFrame = DataFrame.LoadCsv(startLocation);

        return dataFrame;
    }
}
