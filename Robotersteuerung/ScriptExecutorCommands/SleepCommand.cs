using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robotersteuerung.ScriptExecutorCommands
{
    class SleepCommand : ScriptExecutorCommand
    {
        public SleepCommand(string command, string[] args)
        {
            cmd = command;
            this.args = args;
        }

        public override void run()
        {
            if (args.Length < 1) return;
            if (!cmd.Equals("sleep")) return;

            int time;
            try
            {
                time = int.Parse(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (time <= 0) return;

            Thread.Sleep(time);
        }
    }
}
