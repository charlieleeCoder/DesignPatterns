﻿namespace DataProcessor.FileLocations;

public interface IFileDestination
{
    string SendMethod       { get; set; }
    string SendDestination  { get; set; }
}

public class FileDestination(string sendMethod, string sendDestination) : IFileDestination 
{

    public string SendMethod       { get; set; } = sendMethod;
    public string SendDestination  { get; set; } = sendDestination;
    
}
