using Microsoft.Data.Analysis;
using System.Text;

namespace Reader;
public class CSVDataReader: IDataReader
{

    // Open file at filepath, to store in _data 
    public DataFrame ReadData(string filePath)
    {
        char seperator = ',';
        bool header = true;
        Encoding encoding = Encoding.UTF8;
        DataFrame _data = DataFrame.LoadCsv(filePath, seperator, header, encoding);
        return _data;
    }
}
