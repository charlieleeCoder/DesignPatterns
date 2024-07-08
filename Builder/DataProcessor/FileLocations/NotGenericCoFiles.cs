using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotGenericCoFiles : BaseFileLocationGroup
{
    public override string DestinationLocation          { get; set; }
    public string SubmitFormElementName                 { get; set; }

    public NotGenericCoFiles(Report report) : base(Company.NotGenericCo, report)
    {

        // Sending
        DestinationLocation = $"www.NotGenericCo.com/upload_files/";

        // Only required for web portal sending, so not defined in the interface
        SubmitFormElementName = "btn-submit_01";

    }

}