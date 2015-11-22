using Robotersteuerung.ConsoleHelpers;
using Robotersteuerung.HelperClasses;
using System;
using System.Collections.Generic;
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

        private ScriptWindow sw;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            loadControls();
            Console.SetOut(new TextBoxWriter(textBox));
            Console.WriteLine("Loaded and configured control elements");
            instance = this;
            sw = new ScriptWindow();
        }

        #region helper methods

        private void loadControls()
        {
            serialPort = new SerialPort()
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                WriteTimeout = 500,
                ReadTimeout = 500,
                ReceivedBytesThreshold = 4
            };
            serialPort.DataReceived += SerialPort_DataReceived;
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
            List<byte> bytes = new List<byte>() { 255, (byte)(numeric_motor.Value - 1), (byte)slider.Value};
            if (!serialPort.IsOpen)
            {
                toggleSerialPort();
            }
            serialPort.Write(bytes.ToArray(), 0, 3);
            Console.WriteLine("Attempting to change the angel of servomotor " + numeric_motor.Value + " to " + ((slider.Value) / (255d / 90d)) + "°");
        }

        public void toggleSerialPort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                Console.WriteLine("SerialPort closed!");
                button_toggleSerialPort.Content = "Open serial port";
            }
            else
            {
                serialPort.Open();
                Console.WriteLine("SerialPort opened!");
                button_toggleSerialPort.Content = "Close serial port";
            }
        }

        #endregion

        #region EventHandler

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Data received: " + serialPort.ReadLine());
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

        #endregion
    }
}
