using System;
using System.Collections.Generic;
using System.IO;

namespace Practice_201307
{
    public class ActorCsvFileProcessor : IFileProcessor<Actor>
    {
        public IEnumerable<Actor> Process(Stream stream)
        {
            var sr = new StreamReader(stream);
            var first_line = sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return new Actor() {Name = line};
            }
        }
    }
}