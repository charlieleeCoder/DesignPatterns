
using DataProcessor.DocumentPipeline;
using DataProcessor.Enums;
using DataProcessor.Factories;

namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Now return builder
            IFactory Factory = new Factory(Company.MuffinsMuffins, Report.Invoice);
            IDocumentPipeline documentPipeline = Factory.ReturnDocumentPipeline();

            // Call composed methods
            documentPipeline.ReadData();
            documentPipeline.ProcessData();
            documentPipeline.WriteData();
            documentPipeline.SendFile();
            documentPipeline.ArchiveFiles();
            
        }
    }
}
