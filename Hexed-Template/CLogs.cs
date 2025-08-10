using HexedTools.HookUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexed_Template
{
    internal class CLogs
    {
        public static void Log(string message)
        {
            Logs.Log(message, Name: "<color=red>Template Cheat</color>"); // Can use unity color shit
        }
    }
}
