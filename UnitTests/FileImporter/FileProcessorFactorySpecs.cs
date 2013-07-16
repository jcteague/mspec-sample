using System;
using System.Collections.Generic;
using System.IO;
using Machine.Specifications;
using Practice_201307;
using Practice_201307.FileImporter;
using developwithpassion.specifications.rhinomocks;

namespace UnitTests.FileImporter
{
    public class FileProcessorFactorySpecs :Observes<IProcessorFactory,ProcessorFactory>
    {
         public class when_the_filetype_is_csv_and_the_type_is_an_actor
         {
             private Because of = () => processor = sut.GetProcessor<Actor>("csv");
             private It should_return_ActorCSV_Processor = () => processor.ShouldBeOfType<ActorCsvFileProcessor>();
             private static IFileProcessor<Actor> processor;

         }
    }
}