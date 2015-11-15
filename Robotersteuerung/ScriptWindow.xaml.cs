using System.Windows;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für ScriptWindow.xaml
    /// </summary>
    public partial class ScriptWindow : Window
    {
        private ScriptExecutor se;

        /// <summary>
        /// Constructor for ScriptWindow.
        /// </summary>
        /// <param name="args">Filepath to robotscript.</param>
        public ScriptWindow(params string[] args)
        {
            
            InitializeComponent();
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
