using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataProccessors
{
    public interface IDataProcessor
    {
        // Must implement a method to process
        public DataFrame ProcessData(DataFrame data);

    }

    class RemoveCancelled: IDataProcessor 
    {
        // Must implement method to return the relevant data
        public DataFrame ProcessData(DataFrame data){
        
            // To implement
            return new DataFrame();
        }
    }
}