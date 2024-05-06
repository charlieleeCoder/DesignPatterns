using System;

public interface IDataWriter
{
    // Must write data for the processed doc to send
    public void WriteData(Data data);

    // Return file locations for processed and original docs
    public string ReturnArchivedFilePath();
    public string ReturnProcessedFilePath();

}
