﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyFiles.Interfaces;

namespace TidyFiles
{
    public class NameContain : IRule
    {
        public Func<string, string, bool> GetRule()
        {
            return (string FilePath, string Value) =>
            {
                string nomeFile = FilePath.Split('\\').Last().Split('.').First();
                return nomeFile.Contains(Value);
            };
        }
    }
}
