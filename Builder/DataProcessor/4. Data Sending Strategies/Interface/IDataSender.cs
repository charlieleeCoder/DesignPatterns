using System;

public interface IDataSender
{
    // Must implement a method to send data
    void SendData(string filePath, string endLocation);

}
