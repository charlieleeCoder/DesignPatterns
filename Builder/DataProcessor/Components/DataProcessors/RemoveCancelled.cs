using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataProcessors;

class RemoveCancelled: IDataProcessor 
{
    // Must implement method to return the relevant data
    public DataFrame ProcessData(DataFrame data){
        
        // Do something

        // Then return
        return data;
    }
}