using DataValidation;

namespace Processor;
class RemoveCancelled: IDataProcessor 
{
    // Must implement method to return the relevant data
    public Data ProcessData(Data data){
        // To implement
        return new Data() {
            Header = ["Value One", "Value Two"],
            Rows = [["one", "two"], ["three", "four"]]
        };
    }
}