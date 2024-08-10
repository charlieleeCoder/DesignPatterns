using DataProcessor.Enums;
using DataProcessor.FileLocations.FileGroup;
using DataProcessor.FileLocations.FileGroup.FileGroupComponents;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class MuffinsMuffinsFiles : BaseFileGroup
{

    public override FileDestination DestinationLocation { get; set; }

    public MuffinsMuffinsFiles(Report report) : base(Company.MuffinsMuffins, report)
    {

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "email", sendDestination: "madeupemail@MuffinsMuffins.com");

    }

}