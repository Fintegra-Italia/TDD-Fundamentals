using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;

namespace TidyFiles
{
    public class HasExtension : IRule
    {
        public Func<string, string, bool> GetRule()
        {
            return (string FilePath, string Value) => false;
        }
    }
}
