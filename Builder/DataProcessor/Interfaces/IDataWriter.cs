using System;

interface IDataWriter
{
    // Must write data for the processed doc to send
    void WriteData(Data data);

    // Return file locations for processed and original docs
    string ReturnArchivedFilePath();
    string ReturnProcessedFilePath();

}
