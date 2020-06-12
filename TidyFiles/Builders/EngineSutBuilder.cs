using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;
using TidyFiles.Models;

namespace TidyFiles.Builders
{
    public class EngineSutBuilder
    {
        private IFileListReader FileListReader;
        private IJsonReader<Filter> FilterReader;
        private IRuleManager RuleManager;
        public EngineSutBuilder()
        {
            FileListReader = new Mock<IFileListReader>().Object;
            FilterReader  = new Mock<IJsonReader<Filter>>().Object;
            RuleManager = new Mock<IRuleManager>().Object;
        }
        public EngineSutBuilder WithFilterReader(IJsonReader<Filter> newFilterReader)
        {
            FilterReader = newFilterReader;
            return this;
        }
        public EngineSutBuilder WithFileListReader(IFileListReader newFileListReader)
        {
            FileListReader = newFileListReader;
            return this;
        }
        public EngineSutBuilder WithRuleManager(IRuleManager newRuleManager)
        {
            RuleManager = newRuleManager;
            return this;
        }
        public Engine Build()
        {
            return new Engine(RuleManager, FilterReader, FileListReader);
        }
    }
}
