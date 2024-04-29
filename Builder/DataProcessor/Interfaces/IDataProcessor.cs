using System;

interface IDataProcessor
{
    // Must implement a method to process
    void ProcessData(Data data);

    // Must implement method to return the relevant data
    Data ReturnData();

}
