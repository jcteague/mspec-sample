using System.Collections.Generic;
using System.IO;

namespace Practice_201307
{
    public interface IFileImporter<T>
    {
        IEnumerable<T> import(string filename);
    }

    
    public interface IFileProcessor<T>
    {
        IEnumerable<T> Process(Stream stream);
    }

    public interface IRetrieveFiles
    {
        Stream GetFile(string filename);
    }
}