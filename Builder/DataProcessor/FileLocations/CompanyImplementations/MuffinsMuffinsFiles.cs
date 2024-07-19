using DataProcessor.Enums;

namespace DataProcessor.FileLocations.CompanyImplementations;

public class MuffinsMuffinsFiles : FileGroup
{

    public override FileDestination DestinationLocation { get; set; }

    public MuffinsMuffinsFiles(Report report) : base(Company.MuffinsMuffins, report)
    {

        // Sending
        DestinationLocation = new FileDestination(sendMethod: "email", sendDestination: "madeupemail@MuffinsMuffins.com");

    }

}