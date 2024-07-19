using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataReaders;
public class ExcelDataReader: IDataReader
{
	public DataFrame ReadData(IFileLocation startLocation)
	{
        // Error handling
        if (startLocation == null)
        {
            throw new ArgumentNullException(nameof(startLocation));
        }

        // This handles .xlsx as well as csv, but don't add encoding
        DataFrame dataFrame = DataFrame.LoadCsv(startLocation.GetFileLocation());

        return dataFrame;
    }
}
