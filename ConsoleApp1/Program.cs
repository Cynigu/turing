using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>() {"0", "0", "0", "0", "1" };

            TuringEmulator t = new TuringEmulator(str);

            List<qCommand> q0 = new List<qCommand>();
            List<qCommand> q1 = new List<qCommand>();
            List<qCommand> q3 = new List<qCommand>();

            q0.Add(new qCommand("0", "1", ">", 0));
            q0.Add(new qCommand("1", "1", ">", 0));
            q0.Add(new qCommand("_", "_", "<", 1));

            q1.Add(new qCommand("0", "_", "<", 1));
            q1.Add(new qCommand("1", "_", "<", 1));
            q1.Add(new qCommand("_", "_", ".", -1));

            t.Q.Add(new qFullCommand(q0));
            t.Q.Add(new qFullCommand(q1));
            t.Q.Add(new qFullCommand(q3));

            t.Str = str;
            t.PrintToConsoleStr();

            t.RunProgramm();
        }
    }
}
