﻿using Microsoft.Data.Analysis;
using DataProcessor.FileLocations;

namespace DataProcessor.Components.DataWriters;
public interface IDataWriter
{
    // Must write data for the processed doc to send
    public void WriteData(DataFrame data, string writeLocation);

}
