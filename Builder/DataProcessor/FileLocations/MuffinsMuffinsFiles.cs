using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MuffinsMuffinsFiles : BaseFileGroup
{

    public override string DestinationLocation { get; set; }

    public MuffinsMuffinsFiles(Report report) : base(Company.MuffinsMuffins, report)
    {

        // Sending
        DestinationLocation = $"madeupemail@MuffinsMuffins.com";

    }

}