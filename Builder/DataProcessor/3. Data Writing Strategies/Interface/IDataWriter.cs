using DataValidation;

namespace Writer;
public interface IDataWriter
{
    // Must write data for the processed doc to send
    public void WriteData(Data data);

}
