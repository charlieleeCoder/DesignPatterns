
using DataProcessor.DocumentPipeline;
using DataProcessor.Factories;

namespace DataProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Now return builder

            IFactory Factory = new BlueFactory();
            IDocumentPipeline documentPipeline = Factory.FactoryMethod();

            // Call composed methods
            documentPipeline.ReadData();
            documentPipeline.ProcessData();
            documentPipeline.WriteData();
            documentPipeline.SendFile();
            documentPipeline.ArchiveFiles();
            
        }
    }
}
