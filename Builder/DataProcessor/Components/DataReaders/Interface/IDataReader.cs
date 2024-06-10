using Microsoft.Data.Analysis;

namespace Reader;
public interface IDataReader
{
    // Must implement a method to read data, requiring filepath
    DataFrame ReadData(string filePath);

}
