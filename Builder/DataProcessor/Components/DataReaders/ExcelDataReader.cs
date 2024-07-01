using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataReaders;
public class ExcelDataReader: IDataReader
{
	public DataFrame ReadData(IFileLocations fileLocations)
	{
        // Error handling
        if (fileLocations == null)
        {
            throw new ArgumentNullException(nameof(fileLocations));
        }
        if (fileLocations.StartingFileExtension != ".xlsx")
        {
            throw new InvalidOperationException("The Excel reader can only handle Excels.");
        }

        // Get fully qualified name
        string FullStartingFilePathAndNameAndExtension = $"{fileLocations.StartingFileLocation}{fileLocations.StartingFileName}{fileLocations.StartingFileExtension}";

        // This handles .xlsx as well as csv, but don't add encoding
        DataFrame dataFrame = DataFrame.LoadCsv(FullStartingFilePathAndNameAndExtension);

        return new DataFrame();
    }
}
