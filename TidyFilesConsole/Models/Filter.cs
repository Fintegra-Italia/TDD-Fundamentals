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
    }
}
