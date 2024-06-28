using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataProcessors;

class UnProcessed : IDataProcessor
{
    // Must implement method to return the relevant data
    public DataFrame ProcessData(DataFrame data)
    {

        // Do nothing

        // Then returnoriginal data
        return data;
    }
}