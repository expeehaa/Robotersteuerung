using System.Windows;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für ScriptWindow.xaml
    /// </summary>
    public partial class ScriptWindow : Window
    {
        private ScriptExecutor se;
        private bool hasScript = false;

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
            foreach (var s in se.getFileContent().Split('\n'))
            {
                scriptBox.Items.Add(s);
            }
            hasScript = true;
        }


        /// <summary>
        /// Event handler is fired when the MenuItem "Close" is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
