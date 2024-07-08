using DataProcessor.Enums;

namespace DataProcessor.FileLocations;

public class NotRealLtdFiles : BaseFileLocationGroup
{
    public override string StartExtension           { get; set; }
    public override string EndExtension             { get; set; }
    public override string DestinationLocation      { get; set; }

    public NotRealLtdFiles(Report report) : base(Company.NotRealLtd, report)
    {
        // Reading
        StartExtension = ".xlsx";

        // Processing & Writing
        EndExtension = ".xlsx";

        // Sending
        DestinationLocation = $"sftp example@255.255.0.5";
        
    }

}
