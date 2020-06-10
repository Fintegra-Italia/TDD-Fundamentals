using System;
using TidyFilesConsole.Models;

namespace MSTest.Builders
{

    public class FilterBuilder
    {
        private int _id = 1;
        private string _ruleName = "HasExtension";
        private string _value = "pdf";
        private string _destination = "Pdf_Files";
        private Filter _filter;

        public FilterBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public FilterBuilder WithDestination(string destination)
        {
            _destination = destination;
            return this;
        }

        public FilterBuilder WithRuleName(string ruleName)
        {
            _ruleName = ruleName;
            return this;
        }

        public FilterBuilder WithValue(string value)
        {
            _value = value;
            return this;
        }

        public Filter Build()
        {
            _filter = new Filter();
            _filter.Id = _id;
            _filter.RuleName = _ruleName;
            _filter.Value = _value;
            _filter.Destination = _destination;
            return _filter;
        }
    }
}
