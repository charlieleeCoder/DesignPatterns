using DataProcessor.FileLocations;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataReaders;
public interface IDataReader
{
    // Must implement a method to read data, requiring filepath
    public DataFrame ReadData(IFileLocation startLocation);

}
