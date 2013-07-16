using System;
using System.Collections.Generic;
using System.IO;

namespace Practice_201307.FileImporter
{
    public class Importer<T> :IFileImporter<T>
    {
        private readonly IProcessorFactory parser_factory;
        private readonly IRetrieveFiles file_retriever;

        public Importer(IProcessorFactory parserFactory, IRetrieveFiles fileRetriever)
        {
            parser_factory = parserFactory;
            file_retriever = fileRetriever;
        }

        public IEnumerable<T> import(string filename)
        {
            var fi = new FileInfo(filename);
            var file = file_retriever.GetFile(filename);
            var parser = parser_factory.GetProcessor<T>(fi.Extension);
            return parser.Process(file);

        }
    }
}