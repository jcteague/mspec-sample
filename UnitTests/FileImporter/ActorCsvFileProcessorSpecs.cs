using System.Collections.Generic;
using System.IO;
using System.Text;
using Machine.Specifications;
using Practice_201307;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace UnitTests.FileImporter
{
   
    public class ActorCsvFileProcessorSpecs : Observes<IFileProcessor<Actor>, ActorCsvFileProcessor>
    {
        private Establish context = () =>
            {
                var sb = new StringBuilder();
                sb.AppendLine("Name");
                sb.AppendLine("John Travolta");
                sb.AppendLine("Brad Pitt");
                stream = new MemoryStream();
                var sw = new StreamWriter(stream);
                sw.Write(sb.ToString());
                sw.Flush();
                stream.Position = 0;

            };

        
        private Because of = () => result = sut.Process(stream).ToList();
        private It should_return_the_list_of_actors = () => result.Count().ShouldEqual(2);
        private It should_create_the_actors_in_the_file = () => result.ToList()[0].Name.ShouldEqual("John Travolta");
        private static Stream stream;
        private static IEnumerable<Actor> result;
    }
}