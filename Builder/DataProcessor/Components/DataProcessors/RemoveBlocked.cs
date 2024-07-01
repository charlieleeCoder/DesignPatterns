using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataProcessors;

class RemoveBlocked: IDataProcessor 
{
    // Must implement method to return the relevant data
    public DataFrame ProcessData(DataFrame data)
    {

        // Do something
        data = data.Filter(data.Columns["Blocked"].ElementwiseNotEquals("y"));

        // Then return
        return data;
    }
}