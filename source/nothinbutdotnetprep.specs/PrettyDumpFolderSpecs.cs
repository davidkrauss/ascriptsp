using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.tests.utility;
using System.Linq;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.CodeKata;


namespace nothinbutdotnetprep.specs
{
    public class PrettyDumpFolderSpecs
    {
        public abstract class pretty_dump_folder_concern : Observes<PrettyDumpFolder>
        {

        } ;

        [Subject(typeof(PrettyDumpFolder))]
        public class when_dumping_folder : pretty_dump_folder_concern
        {
            static int number_of_sub_folders;

            Because b = () =>
                number_of_sub_folders = sut.WalkDirectoryTree(@"c:\NBDN", 4);

            It should_return_the_number_of_all_movies_in_the_library = () =>
            {
                number_of_sub_folders.ShouldEqual(551);
            };
        }


    }
}