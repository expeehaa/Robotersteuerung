using Robotersteuerung.ConsoleHelpers;
using Robotersteuerung.HelperClasses;
using System;
using System.IO;
using System.IO.Ports;
using System.Windows;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CustomSerialPort serialPort;

        public static MainWindow instance;

        public ScriptWindow sw;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            loadControls();
            instance = this;
            Console.SetOut(new TextBoxWriter(textBox));
            Console.WriteLine("Loaded and configured control elements");
            sw = new ScriptWindow();
        }

        #region helper methods

        private void loadControls()
        {
            serialPort = new CustomSerialPort()
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                WriteTimeout = 500,
                ReadTimeout = 500,
                ReceivedBytesThreshold = 4,
                Handshake = Handshake.None
            };
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.OpenedEvent += SerialPort_OpenedEvent;
            serialPort.ClosedEvent += SerialPort_ClosedEvent;
            reloadCOMPorts();
        }

        public void reloadCOMPorts()
        {
            Console.WriteLine("Reloading COM-Ports");
            if (SerialPort.GetPortNames().Length == 0)
            {
                Console.WriteLine("No COM-Port(s) found!");
            }
            else
            {
                comPortBox.Items.Clear();
                foreach (var item in SerialPort.GetPortNames())
                {
                    comPortBox.Items.Add(item);
                }
                comPortBox.SelectedIndex = 0;
                Console.WriteLine(SerialPort.GetPortNames().Length + " COM-Port(s) found");
            }
        }

        public void writeBytesToSerialPort()
        {
            try
            {
                //List<byte> bytes = new List<byte>() { 255, (byte)(numeric_motor.Value.Value - 1), (byte)slider.Value};
                byte[] bytes = new byte[3];
                bytes[0] = 255;
                bytes[1] = (byte)(numeric_motor.Value.Value - 1);
                bytes[2] = (byte)slider.Value;
                if (!serialPort.IsOpen) serialPort.Open();
                serialPort.Write(bytes, 0, 3);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Can't open SerialPort: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Can't open SerialPort: " + e.Message);
            }
        }

        public void toggleSerialPort()
        {
            try
            {
                if (serialPort.IsOpen) serialPort.Close();
                else serialPort.Open();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Can't open SerialPort: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Can't open SerialPort: " + e.Message);
            }
        }

        #endregion

        #region EventHandler

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string input = "";
            for (int i = 0; i < serialPort.BytesToRead; i++)
            {
                input += serialPort.ReadChar();
            }
            Console.WriteLine("Data received: " + input);
        }

        private void MenuItem_beenden_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                toggleSerialPort();
            }
            Application.Current.Shutdown();
        }

        private void btn_toggleSerialPort(object sender, RoutedEventArgs e)
        {
            toggleSerialPort();
        }

        private void MenuItem_ReloadComPorts(object sender, RoutedEventArgs e)
        {
            reloadCOMPorts();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (chckbox_autoSend.IsChecked)
            {
                writeBytesToSerialPort();
            }
        }

        private void btn_writeBytes_Click(object sender, RoutedEventArgs e)
        {
            writeBytesToSerialPort();
        }

        private void MenuItem_open_scriptexecutor(object sender, RoutedEventArgs e)
        {
            if (!sw.IsActive) sw.Show();
        }

        private void SerialPort_ClosedEvent()
        {
            Console.WriteLine("SerialPort closed!");
            button_toggleSerialPort.Content = "Open serial port";
        }

        private void SerialPort_OpenedEvent()
        {
            Console.WriteLine("SerialPort with portname '" + serialPort.PortName + "' opened!");
            button_toggleSerialPort.Content = "Close serial port";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            serialPort.Close();
            Application.Current.Shutdown();
        }

        private void comPortBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comport = (string)comPortBox.SelectedItem;
            if (comport.Length == 0) return;
            serialPort.PortName = comport;
        }

        #endregion
    }
}
