using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;
using TidyFiles.Models;

namespace TidyFiles.FixtureObject
{
    internal class EngineFixture
    {
        internal IFileListReader FileListReader;
        internal IJsonReader<Filter> FilterReader;
        internal IRuleManager RuleManager;
        internal EngineFixture()
        {
            FileListReader = new Mock<IFileListReader>().Object;
            FilterReader = new Mock<IJsonReader<Filter>>().Object;
            RuleManager = new Mock<IRuleManager>().Object;
        }
        internal Engine CreateSut()
        {
            return new Engine(RuleManager, FilterReader, FileListReader);
        }
    }
}
