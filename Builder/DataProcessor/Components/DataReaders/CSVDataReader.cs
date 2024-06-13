using Microsoft.Data.Analysis;
using System.Text;

namespace Reader;
public class CSVDataReader: IDataReader
{

    // Open file at filepath, to store in _data 
    public DataFrame ReadData(string filePath)
    {
        Encoding encoding = Encoding.UTF8;
        DataFrame _data = DataFrame.LoadCsv(filePath, encoding: encoding);
        return _data;
    }
}
