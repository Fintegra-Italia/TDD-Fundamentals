using System;
using Xunit;
using Moq;
using TidyFiles.Interfaces;
using TidyFiles.Models;
using TidyFiles;
using System.Collections.Generic;

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

        [Fact]
        public void GetFilters_ShouldUse_FileListReader()
        {
            //setup dipendenze
            var fileListReader = new Mock<IFileListReader>();
            var filterReader = new Mock<IJsonReader<Filter>>();
            var ruleManager = new Mock<IRuleManager>();

            fileListReader.Setup(m => m.GetFileList("filejson.json")).Returns(new List<string>() { "filepath.json","filePath.docx", "filePath.xlsx" });
            filterReader.Setup(m => m.Read("filePath.json")).Returns(new List<Filter>() { FiltroCasuale() });
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
            var filterReader = new Mock<IJsonReader<Filter>>();
            var ruleManager = new Mock<IRuleManager>();

            fileListReader.Setup(m => m.GetFileList("pathQualisiasi")).Returns(new List<string>() { "filepath.json", "filePath.docx", "filePath.xlsx" });
            IEngine sut = new Engine(ruleManager.Object, filterReader.Object, fileListReader.Object);

            //exercise
            IList<string> actual = sut.GetFiles("pathQualsiasi");
            fileListReader.Verify((m => m.GetFileList("pathQualsiasi")), Times.Exactly(1));
        }
    }
}
