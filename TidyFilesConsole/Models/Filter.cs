using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyFilesConsole.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public string RuleName {get;set;}
        public string Value { get; set; }
        public string Destination { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Filter other = obj as Filter;
            if ((Object)other == null) return false;
            return this.Id == other.Id
                && this.RuleName == other.RuleName
                && this.Value == other.Value
                && this.Destination == other.Destination;
        }
    }
}
