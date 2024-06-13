using Microsoft.Data.Analysis;

namespace Reader;
public interface IDataReader
{
    // Must implement a method to read data, requiring filepath
    public DataFrame ReadData(string filePath);

}
