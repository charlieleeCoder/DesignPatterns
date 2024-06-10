using Microsoft.Data.Analysis;

namespace Processor;
public interface IDataProcessor
{
    // Must implement a method to process
    public DataFrame ProcessData(DataFrame data);

}
