using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für ProjectR.xaml
    /// </summary>
    public partial class ProjectR : Window
    {

        private MainWindow mw = MainWindow.instance;

        public ProjectR()
        {
            InitializeComponent();
        }

        private void greifer_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte[] servos = { 0, 1 };
            try
            {
                List<byte> bytes;

                bytes = new List<byte>() { 255, servos[0], (byte)((Slider)sender).Value};
                if (!mw.serialPort.IsOpen) mw.serialPort.Open();
                mw.serialPort.Write(bytes.ToArray(), 0, 3);

                bytes = new List<byte>() { 255, servos[1], (byte)(255-((Slider)sender).Value) };
                mw.serialPort.Write(bytes.ToArray(), 0, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
        }

        private void turn_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte servo = 7;
            try
            {
                List<byte> bytes = new List<byte>() { 255, servo, (byte)((Slider)sender).Value };
                if (!mw.serialPort.IsOpen) mw.serialPort.Open();
                mw.serialPort.Write(bytes.ToArray(), 0, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
        }

        private void neigen1_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte[] servos = { 2, 3 };
            try
            {
                List<byte> bytes;

                bytes = new List<byte>() { 255, servos[0], (byte)((Slider)sender).Value };
                if (!mw.serialPort.IsOpen) mw.serialPort.Open();
                mw.serialPort.Write(bytes.ToArray(), 0, 3);

                bytes = new List<byte>() { 255, servos[1], (byte)(255 - ((Slider)sender).Value) };
                mw.serialPort.Write(bytes.ToArray(), 0, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
        }

        private void neigen2_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte[] servos = { 4, 5 };
            try
            {
                List<byte> bytes;

                bytes = new List<byte>() { 255, servos[0], (byte)((Slider)sender).Value };
                if (!mw.serialPort.IsOpen) mw.serialPort.Open();
                mw.serialPort.Write(bytes.ToArray(), 0, 3);

                bytes = new List<byte>() { 255, servos[1], (byte)(255 - ((Slider)sender).Value) };
                mw.serialPort.Write(bytes.ToArray(), 0, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Can't open SerialPort: " + ex.Message);
            }
        }
    }
}
