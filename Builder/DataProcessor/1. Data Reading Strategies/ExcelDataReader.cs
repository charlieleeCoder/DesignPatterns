using DataValidation;

namespace Reader;
public class ExcelDataReader: IDataReader
{
	public void ReadData(string FilePath)
	{
        // TODO: implement. Need to find relevant libraries.
        
    }
	public Data GetData()
	{
        // TODO: implement
        return new Data() {
            Header = ["Value One", "Value Two"],
            Rows = [["one", "two"], ["three", "four"]]
        };
	}
}
