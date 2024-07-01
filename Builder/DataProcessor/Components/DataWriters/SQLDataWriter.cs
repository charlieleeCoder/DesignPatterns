using DataProcessor.FileLocations;
using DataProcessor.SubComponents;
using Microsoft.Data.Analysis;

namespace DataProcessor.Components.DataWriters;
public class SQLWriter : IDataWriter
{
    private DatabaseConnection _connection = new();

    // The sql writer effectively gets sent twice, once to the db, once by sender method
    public void WriteData(DataFrame data, string writeLocation)
    {
        // To implement
        _connection.Connect();
    }
}