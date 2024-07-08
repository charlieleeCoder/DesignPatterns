using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class MadeUpCoFiles : BaseFileLocationGroup
{
    public override string EndExtension                 { get; set; }
    public override string DestinationLocation          { get; set; }

    public MadeUpCoFiles(Report report) : base(Company.MadeUpCo, report)
    {

        // Processing & Writing
        EndExtension = ".xlsx";

        // Sending
        DestinationLocation = "sftp example@255.255.0.1";

    }


}
