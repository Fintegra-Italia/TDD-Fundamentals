using System;
using Xunit;
using Moq;
using TidyFiles.Interfaces;
using TidyFiles.Models;
using TidyFiles;
using System.Collections.Generic;
using TestProject.Builders;
using TestProject.FixtureObject;

namespace TestProject
{

    public class Engine_TEST
    {


        [Fact]
        public void GetFilters_ShouldUse_FileListReader()
        {
            //setup dipendenze
            var fileListReader = new Mock<IFileListReader>();
            var filterReader = new Mock<IJsonReader<Filter>>();
            var ruleManager = new Mock<IRuleManager>();

            var input = new EngineInputBuilder();

            fileListReader.Setup(m => m.GetFileList("filejson.json"))
                            .Returns(new List<string>() { "filepath.json","filePath.docx", "filePath.xlsx" });

            filterReader.Setup(m => m.Read("filePath.json"))
                            .Returns( input.SingleElementFilterList() );
            //setup
            IList<Filter> expected = input.SingleElementFilterList();
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
            fileListReader.Setup(m => m.GetFileList(It.IsAny<string>()))
                            .Returns(new List<string>() { "filepath.json", "filePath.docx", "filePath.xlsx" });

            IEngine sut = new EngineSutBuilder()
                                .WithFileListReader(fileListReader.Object)
                                .Build();
            //exercise
            IList<string> actual = sut.GetFiles(It.IsAny<string>());
            //verify
            fileListReader.Verify((m => m.GetFileList(It.IsAny<string>())), Times.Exactly(1));
        }
        [Fact]
        public void Apply_ShouldUse_GetRules()
        {
            var fixture = new EngineFixture();
            var input = new EngineInputBuilder();
            fixture.RuleManager.AsMock().Setup(m => m.GetRules(It.IsAny<string>()))
                                            .Returns((string filepath, string value) => false);

            IEngine sut = fixture.CreateSut();

            var actual = sut.Apply(input.FileListWithAJsonFile(), input.FilterListWithRandomValue());

            fixture.RuleManager.AsMock().Verify((m => m.GetRules(It.IsAny<string>())), Times.Exactly(1));
        }
    }
}
