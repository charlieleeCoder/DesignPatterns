using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataProcessors;

public interface IDataProcessor
{
    // Must implement a method to process
    public DataFrame ProcessData(DataFrame data);

}
