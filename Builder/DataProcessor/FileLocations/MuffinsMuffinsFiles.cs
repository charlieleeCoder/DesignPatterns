using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileGroup
{

    public override FileDestination DestinationLocation { get; set; }

    public MuffinsMuffinsFiles(Report report) : base(Company.MuffinsMuffins, report)
    {

        // Sending
        DestinationLocation = new FileDestination(sendMethod:"email",sendDestination:"madeupemail@MuffinsMuffins.com");

    }

}