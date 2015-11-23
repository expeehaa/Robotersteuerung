using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //string args = "";
            //foreach (var s in e.Args)
            //{
            //    args += s + "\n";
            //}
            //MessageBox.Show(args);
            
            base.OnStartup(e);
            //if(/*e.Args.Length > 0*/true)
            //{
            //    string fileloc = "C:\\Users\\Lukas\\Desktop\\test.robotscript";
            //    Robotersteuerung.MainWindow.instance.sw.newScriptExecutor(fileloc);
            //    Robotersteuerung.MainWindow.instance.sw.Show();
            //}
        }
    }
}
