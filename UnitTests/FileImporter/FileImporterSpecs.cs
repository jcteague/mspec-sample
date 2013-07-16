using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Practice_201307;
using Practice_201307.FileImporter;
using developwithpassion.specifications.rhinomocks;
using Rhino.Mocks;

namespace UnitTests.FileImporter
{
    class when_loading_a_actor_file :Observes<IFileImporter<Actor>,Importer<Actor>>
    {
        private Establish context = () =>
            {
                var actors = new List<Actor>();
                processor_factory = depends.on<IProcessorFactory>();
                var file_retriever = depends.on<IRetrieveFiles>();
                file_retriever.Stub(x => x.GetFile(Arg<string>.Is.Anything)).Return(new MemoryStream());
                var actor_processor = fake.an<IFileProcessor<Actor>>();
                actor_processor.Stub(x => x.Process(Arg<Stream>.Is.Anything)).Return(actors);
                processor_factory.Stub(x => x.GetProcessor<Actor>(Arg<String>.Is.Anything)).Return(actor_processor);

            };

        private Because of = () => result = sut.import("filename.csv");

        private It should_return_list_of_actors = () => result.ShouldNotBeNull();

        private static IFileImporter<Actor> file_importer;
        private static IEnumerable<Actor> result;
        private static IProcessorFactory processor_factory;
    }

    
}
