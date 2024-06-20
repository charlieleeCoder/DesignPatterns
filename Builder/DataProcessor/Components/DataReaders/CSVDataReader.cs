using Microsoft.Data.Analysis;
using System.Text;

namespace DataProcessor.Components.DataReaders;
public class CSVDataReader: IDataReader
{

    private readonly Encoding _encoding = Encoding.UTF8;

    // Open file at filepath, to store in _data 
    public DataFrame ReadData(string filePath)
    {
        return DataFrame.LoadCsv(filePath, encoding: _encoding);
    }
}
