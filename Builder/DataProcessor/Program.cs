
using DataProcessor.ComponentsRequired;
using DataProcessor.DocumentPipeline;
using DataProcessor.Enums;
using DataProcessor.Factory;

namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Implement command line arg parsing later
            //

            // Now return builder
            IFactory Factory = new Factory.Factory(Company.MuffinsMuffins, Report.Invoice);
            IDocumentPipeline documentPipeline = Factory.ReturnDocumentPipeline();

            // Call composed methods
            documentPipeline.ReadData();
            documentPipeline.ProcessData();
            documentPipeline.WriteData();
            documentPipeline.SendFile();
            //documentPipeline.ArchiveFiles();

            // Success!
            Environment.Exit(0);

        }
    }
}
