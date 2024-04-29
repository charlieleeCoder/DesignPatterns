using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;

interface IDataReader
{
    // Must implement a method to read data, requiring filepath
    void ReadData(string filePath);

    // Must implement method to return the relevant data
    Data GetData();
}
