using System;
using Xunit;
using Moq;
using TidyFiles.Interfaces;
using TidyFiles.Models;
using TidyFiles;
using System.Collections.Generic;
using TestProject.Builders;
using TestProject.FixtureObject;
using System.Linq;

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

            var filterList = new FilterBuilder();

            fileListReader.Setup(m => m.GetFileList("filejson.json"))
                            .Returns(new List<string>() { "filepath.json","filePath.docx", "filePath.xlsx" });

            filterReader.Setup(m => m.Read("filePath.json"))
                            .Returns( filterList.WithOneRandomFilterList().BuildList() );
            //setup
            IList<Filter> expected = filterList.WithOneRandomFilterList().BuildList();
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
        public void ApplyFilter_ShouldUse_GetRules()
        {
            var fixture = new EngineFixture();
            var filter = new FilterBuilder().WithValidFilter().Build();
            var fileList = new FileListBuilder().WithCorrectFileName().Build();

            fixture.RuleManager.AsMock().Setup(m => m.GetRules(It.IsAny<string>()))
                                            .Returns((string filepath, string value) => false);

            IEngine sut = fixture.CreateSut();

            var actual = sut.ApplyFilter(fileList, filter);

            fixture.RuleManager.AsMock().Verify((m => m.GetRules(It.IsAny<string>())), Times.Exactly(1));
        }
        [Fact]
        public void Execute_CorrectFlux_Applied()
        {
            IList<Filter> listaFiltri = new FilterBuilder().WithOneValidFilterList().BuildList();
            IList<string> listaFile = new FileListBuilder().WithCorrectFileName().Build();

            var fixture = new EngineFixture();
            fixture.RuleManager.AsMock().Setup(m => m.GetRules(It.IsAny<string>())).Returns(It.IsAny<Func<string, string, bool>>());
            fixture.FileListReader.AsMock().Setup(m => m.GetFileList(It.IsAny<string>())).Returns(listaFile);
            fixture.FilterReader.AsMock().Setup(m => m.Read(It.IsAny<string>())).Returns(listaFiltri);
            var sut = fixture.CreateSut();
            sut.Execute();


            fixture.RuleManager.AsMock().Verify(m => m.GetRules(It.IsAny<string>()), Times.Exactly(listaFiltri.Count));
            fixture.FileListReader.AsMock().Verify(m => m.GetFileList(It.IsAny<string>()), Times.Exactly(2));
            fixture.FilterReader.AsMock().Verify(m=>m.Read(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
