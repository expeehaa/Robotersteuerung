using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();
            write("Loading and configuring control elements");
            loadUIControls();
        }

        #region helper methods

        private void loadUIControls()
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

        public void write(string text, bool time = true)
        {
            DateTime t = DateTime.Now;
            string timenow = "[" + t.ToLongTimeString() + "]";
            textBox.Text += (time ? timenow : "") + text + "\n";
        }

        public void reloadCOMPorts()
        {
            write("Reloading COM-Ports");
            if (SerialPort.GetPortNames().Length == 0)
            {
                write("No COM-Port(s) found!");
            }
            else
            {
                comPortBox.Items.Clear();
                foreach (var item in SerialPort.GetPortNames())
                {
                    comPortBox.Items.Add(item);
                }
                comPortBox.SelectedIndex = 0;
                write(SerialPort.GetPortNames().Length + " COM-Port(s) found");
            }
        }

        public void writeBytesToSerialPort()
        {
            List<byte> bytes = new List<byte>() { 255, (byte)(numeric_motor.Value - 1d), (byte)slider.Value};
            if (!serialPort.IsOpen)
            {
                toggleSerialPort();
            }
            serialPort.Write(bytes.ToArray(), 0, 3);
            write("Attempting to change the angel of servomotor " + 0 + " to " + ((slider.Value) / (255d / 90d)) + "°");
        }

        public void toggleSerialPort()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                write("SerialPort closed!");
                button_toggleSerialPort.Content = "Open serial port";
            }
            else
            {
                serialPort.Open();
                write("SerialPort opened!");
                button_toggleSerialPort.Content = "Close serial port";
            }
        }

        #endregion

        #region EventHandler

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            write("Data received: " + serialPort.ReadLine());
        }

        private void MenuItem_beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_toggleSerialPort(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_ReloadComPorts(object sender, RoutedEventArgs e)
        {
            reloadCOMPorts();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (chckbox_autoSend.IsChecked.Value)
            {
                writeBytesToSerialPort();
            }
        }

        private void btn_writeBytes_Click(object sender, RoutedEventArgs e)
        {
            writeBytesToSerialPort();
        }

        #endregion
    }
}
