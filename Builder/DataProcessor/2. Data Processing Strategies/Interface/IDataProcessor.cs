﻿using DataValidation;

namespace Processor;
public interface IDataProcessor
{
    // Must implement a method to process
    public Data ProcessData(Data data);

}