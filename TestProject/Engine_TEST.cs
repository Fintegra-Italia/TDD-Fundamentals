using System;
using Xunit;
using Moq;
using TidyFiles.Interfaces;
using TidyFiles.Models;
using TidyFiles;
using System.Collections.Generic;
using TidyFiles.Builders;

namespace TestProject
{

    public class Engine_TEST
    {
        private Filter FiltroCasuale()
        {
            return new Filter()
            {
                Id = 1,
                RuleName = "regolaACaso",
                Destination = "finalDestination2",
                Value = "valoreAcaso"
            };
         }
        private IList<string> ListaFile = new List<string>() { "fileuno.jpeg", "file2.json", "file4.xlsx" };
        private IList<Filter> ListaFiltri = new List<Filter>() { new Filter()
                                                                    {
                                                                        Id = 1,
                                                                        RuleName = "regolaACaso",
                                                                        Destination = "finalDestination2",
                                                                        Value = "valoreAcaso"
                                                                    }
                                                                };

        [Fact]
        public void GetFilters_ShouldUse_FileListReader()
        {
            //setup dipendenze
            var fileListReader = new Mock<IFileListReader>();
            var filterReader = new Mock<IJsonReader<Filter>>();
            var ruleManager = new Mock<IRuleManager>();

            fileListReader.Setup(m => m.GetFileList("filejson.json"))
                            .Returns(new List<string>() { "filepath.json","filePath.docx", "filePath.xlsx" });

            filterReader.Setup(m => m.Read("filePath.json"))
                            .Returns(new List<Filter>() { FiltroCasuale() });
            //setup
            IList<Filter> expected = new List<Filter>() { FiltroCasuale() };
            IEngine sut = new Engine(ruleManager.Object, filterReader.Object, fileListReader.Object);
            
            //exercise
            IList<Filter> actual = sut.GetFilters("filejson.json");

            //verify
            fileListReader.Verify((m=>m.GetFileList("filejson.json")), Times.Exactly(1));
            filterReader.Verify((m => m.Read("filepath.json")), Times.Exactly(1));
        }
        [Fact]
        public void GetFiles_ShouldUse_FileListReader()
        {
            //setup dipendenze
            var fileListReader = new Mock<IFileListReader>();
            fileListReader.Setup(m => m.GetFileList("pathQualisiasi"))
                            .Returns(new List<string>() { "filepath.json", "filePath.docx", "filePath.xlsx" });

            IEngine sut = new EngineSutBuilder()
                                .WithFileListReader(fileListReader.Object)
                                .Build();
            //exercise
            IList<string> actual = sut.GetFiles("pathQualsiasi");
            //verify
            fileListReader.Verify((m => m.GetFileList("pathQualsiasi")), Times.Exactly(1));
        }
        [Fact]
        public void Apply_ShouldUse_GetRules()
        {
            var ruleManager = new Mock<IRuleManager>();
            ruleManager.Setup(m => m.GetRules("HasExtension"))
                        .Returns((string filepath, string value) => false);

            IEngine sut = new EngineSutBuilder()
                                .WithRuleManager(ruleManager.Object)
                                .Build();
            var actual = sut.Apply(ListaFile, ListaFiltri);
            ruleManager.Verify((m => m.GetRules("HasExtension")), Times.Exactly(1));
        }
    }
}
