using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotscript.ScriptExecutorCommands
{
    class TurnCommand : ScriptExecutorCommand
    {
        public TurnCommand(string command, string[] args)
        {
            cmd = command;
            this.args = args;
        }

        public override void run()
        {
            if (args.Length < 2) return;
            if (!cmd.Equals("turn")) return;

            int motor, degrees;
            try
            {
                motor = int.Parse(args[0]);
                degrees = int.Parse(args[1]);
            }
            catch (Exception)
            {
                return;
            }

            if (motor < 0 || motor > 7 || degrees < 0 || degrees > 254)
            {
                throw new ArgumentOutOfRangeException();
            }


            List<byte> bytes = new List<byte>() { 255, (byte)motor, (byte)degrees };
            MainWindow.instance.Dispatcher.Invoke(() =>
            {
                if (!MainWindow.instance.serialPort.IsOpen) MainWindow.instance.serialPort.Open();
                MainWindow.instance.serialPort.Write(bytes.ToArray(), 0, 3);
            });
        }
    }
}
