namespace Practice_201307.FileImporter
{
    public interface IProcessorFactory
    {
        IFileProcessor<T> GetProcessor<T>(string fileType);
    }
}