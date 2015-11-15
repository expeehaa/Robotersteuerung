using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace Robotersteuerung
{
    class ScriptExecutor
    {
        private FileInfo file;
        private MainWindow mw;
        private Thread thread;
        private string fileContent;

        public ScriptExecutor(MainWindow mw, FileInfo fileinfo)
        {
            this.mw = mw;
            file = fileinfo;
            getFileContent();
        }

        #region GetSet

        public FileInfo getFile()
        {
            return file;
        }

        public void setFile(FileInfo fileinfo)
        {
            file = fileinfo;
            getFileContent();
        }
        #endregion

        #region Helpers

        private void getFileContent()
        {
            StreamReader sr = new StreamReader(file.OpenRead());
            fileContent = sr.ReadToEnd();
            sr.Close();
        }

        #endregion

        public void executeScript()
        {
            thread = new Thread(new ThreadStart(scriptexecutor));
            
        }

        public void stopScript()
        {

        }


        private void scriptexecutor()
        {
            foreach (var s in fileContent.Split('\n'))
            {
                if (s.ToLower().StartsWith("turn"))
                {
                    if (s.Split(' ').Length != 3) continue;
                    List<string> slist = s.Split(' ').ToList();

                    int motor, degrees;
                    try
                    {
                        motor = int.Parse(slist[1]);
                        degrees = int.Parse(slist[2]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    if (slist[0] == "turn"
                        && 0 <= motor && motor <= 7
                        && 0 <= degrees && degrees <= 255)
                    {
                        List<byte> bytes = new List<byte>() { 255, (byte)motor, (byte)degrees };
                        if (!mw.serialPort.IsOpen)
                        {
                            mw.toggleSerialPort();
                        }
                        mw.serialPort.Write(bytes.ToArray(), 0, 3);
                    }
                }

                else if (s.ToLower().StartsWith("sleep"))
                {
                    if (s.Split(' ').Length != 2) continue;

                    int time;
                    try
                    {
                        time = int.Parse(s.Split(' ')[1]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    Thread.Sleep(time);
                }
            }
        }
    }
}
