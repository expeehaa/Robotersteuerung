using Microsoft.Win32;
using System.Windows;
using Robotscript.ScriptExecutorCommands;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für ScriptWindow.xaml
    /// </summary>
    public partial class ScriptWindow : Window
    {
        private ScriptExecutor se;

        private bool HasScript;

        public static ScriptWindow instance;

        /// <summary>
        /// Constructor for ScriptWindow.
        /// </summary>
        /// <param name="args">Filepath to robotscript.</param>
        public ScriptWindow()
        {
            InitializeComponent();
            instance = this;
        }


        public void newScriptExecutor(string filepath)
        {
            se = new ScriptExecutor(this, new System.IO.FileInfo(filepath));

            se.ThreadStateChangedEvent += Se_ThreadStateChangedEvent;

            scriptBox.Items.Clear();
            foreach (var s in se.getrobotscript().Split('\n'))
            {
                scriptBox.Items.Add(s);
            }
            HasScript = true;
        }

        private void Se_ThreadStateChangedEvent(System.Threading.ThreadState e)
        {
            Dispatcher.Invoke(() =>
            {
                se_state.Content = "Script thread state: " + e.ToString();
            });
        }



        #region Event handler

        /// <summary>
        /// Event handler is fired when the MenuItem "Close" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_close_Click(object sender, RoutedEventArgs e)
        {
            se.stopScript();
            Visibility = Visibility.Collapsed;
        }

        private void btn_startScript_Click(object sender, RoutedEventArgs e)
        {
            if (HasScript)
            {
                se.executeScript();
            }
        }

        private void btn_stopScript_Click(object sender, RoutedEventArgs e)
        {
            if (HasScript)
            {
                se.stopScript();
            }
        }

        private void btn_pauseScript_Click(object sender, RoutedEventArgs e)
        {
            if (HasScript)
            {
                //se.pauseScript();
            }
        }

        private void btn_resumeScript_Click(object sender, RoutedEventArgs e)
        {
            if (HasScript)
            {
                //se.resumeScript();
            }
        }

        private void menuItem_loadScript_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Robotscript files | *.robotscript",
                Multiselect = false,
                Title = "Pick a robotscript!",
                CheckFileExists = true,
                CheckPathExists = true
            };

            bool success = ofd.ShowDialog().Value;
            if (!success) return;
            newScriptExecutor(ofd.FileName);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
            if (se != null) se.stopScript();
        }

        #endregion
    }
}
