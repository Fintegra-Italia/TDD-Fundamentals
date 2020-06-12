using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidyFiles.Interfaces
{
    public interface IRuleManager
    {
        Func<string, string, bool> GetRules(string RuleName);
    }
}
