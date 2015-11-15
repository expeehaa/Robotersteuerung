using System.Windows;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für ScriptWindow.xaml
    /// </summary>
    public partial class ScriptWindow : Window
    {
        private ScriptExecutor se;
        
        private bool HasScript
        {
            get
            {
                return HasScript;
            }

            set
            {
                HasScript = value;
            }
        }

        /// <summary>
        /// Constructor for ScriptWindow.
        /// </summary>
        /// <param name="args">Filepath to robotscript.</param>
        public ScriptWindow(params string[] args)
        {
            InitializeComponent();

            if (args.Length > 0) newScriptExecutor(args[0]);
        }


        public void newScriptExecutor(string filepath)
        {
            se = new ScriptExecutor(this, new System.IO.FileInfo(filepath));

            scriptBox.Items.Clear();
            foreach (var s in se.getrobotscript().Split('\n'))
            {
                scriptBox.Items.Add(s);
            }
            HasScript = true;
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
            Close();
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
                se.pauseScript();
            }
        }

        private void btn_resumeScript_Click(object sender, RoutedEventArgs e)
        {
            if (HasScript)
            {
                se.resumeScript();
            }
        }

        #endregion

    }
}
