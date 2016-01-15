using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Robotscript;

namespace Robotscript.ScriptExecutorCommands
{
    abstract class ScriptExecutorCommand
    {
        protected string cmd;

        protected string[] args;

        Dispatcher dispatcher = ScriptWindow.instance.Dispatcher;

        public abstract void run();

    }
}
