using DataProcessor.DocumentPipeline.Interface;

namespace DataProcessor.Factories.Interface
{
    public interface IFactory
    {
        public IDocumentPipeline FactoryMethod();
    }
}
