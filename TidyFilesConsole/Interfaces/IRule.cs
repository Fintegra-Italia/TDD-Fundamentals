using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyFilesCore.Interfaces
{
    public interface IRule
    {
        Func<string, string, bool> GetRule();
    }
}
