using DataProcessor.Enums;
using DataProcessor.FileLocations.FileGroup;
using DataProcessor.FileLocations.FileGroup.FileGroupComponents;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class NotGenericCoFiles : BaseFileGroup
{
    public override FileDestination DestinationLocation { get; set; }
    public string SubmitFormElementName { get; set; }

    public NotGenericCoFiles(Report report) : base(Company.NotGenericCo, report)
    {

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "selenium webdriver", sendDestination: "www.NotGenericCo.com/upload_files/");

        // Only required for web portal sending, so not defined in the interface
        SubmitFormElementName = "btn-submit_01";

    }

}