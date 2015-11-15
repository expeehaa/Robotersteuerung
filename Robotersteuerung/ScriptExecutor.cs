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
        private ScriptWindow sw;
        private Thread thread;
        private string fileContent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mw"></param>
        /// <param name="fileinfo"></param>
        public ScriptExecutor(ScriptWindow sw, FileInfo fileinfo)
        {
            this.sw = sw;
            file = fileinfo;
            getFileContent();
            thread = new Thread(new ThreadStart(scriptexecutor));
        }

        #region GetSet

        /// <summary>
        /// Get the robotscripts FileInfo data
        /// </summary>
        /// <returns></returns>
        public FileInfo getFile()
        {
            return file;
        }

        /// <summary>
        /// Set the robotscripts FileInfo
        /// </summary>
        /// <param name="fileinfo"></param>
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

        /// <summary>
        /// Start executing the robotscript
        /// </summary>
        public void executeScript()
        {
            thread.Start();
        }

        /// <summary>
        /// Stop a running robotscript
        /// </summary>
        public void stopScript()
        {
            thread.Abort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if script is running</returns>
        public bool IsScriptRunning()
        {
            return thread.IsAlive;
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
                        if (!MainWindow.instance.serialPort.IsOpen)
                        {
                            MainWindow.instance.toggleSerialPort();
                        }
                        MainWindow.instance.serialPort.Write(bytes.ToArray(), 0, 3);
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
