namespace Practice_201307.FileImporter
{
    public class ProcessorFactory : IProcessorFactory
    {

        public IFileProcessor<T> GetProcessor<T>(string fileType)
        {
            if (file_type_is_cvs(fileType))
                return get_csv_for<T>();
            return null;
        }

        private IFileProcessor<T> get_csv_for<T>()
        {
            if (typeof(T) == typeof(Actor))
                return (IFileProcessor<T>)new ActorCsvFileProcessor();
            return null;
        }

        private bool file_type_is_cvs(string fileType)
        {
            return fileType.ToLower() == "csv";
        }
    }
}