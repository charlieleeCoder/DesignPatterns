
namespace DataProcessor.Enums
{
    // Define valid companies
    public enum Report
    {
        Invoice,
        Accounting,
        Operations,
        BoardReport
    }

    // Provide name lookup
    public static class ReportsDictionary
    {
        public static readonly Dictionary<Report, string> ReportsLookup = new()
        {
            {   Report.Invoice,      "Invoice"      },
            {   Report.Accounting,   "Accounting"   },
            {   Report.Operations,   "Operations"   },
            {   Report.BoardReport,  "Board Report" }
        };
    }

}
