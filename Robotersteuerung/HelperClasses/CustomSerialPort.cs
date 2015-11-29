using System;
using System.IO.Ports;
using System.Windows;

namespace Robotersteuerung.HelperClasses
{
    public class CustomSerialPort : SerialPort
    {
        public delegate void ClosedEventArgs();
        public event ClosedEventArgs ClosedEvent;

        public delegate void OpenedEventArgs();
        public event OpenedEventArgs OpenedEvent;

        public new void Close()
        {
            try
            {
                ClosedEvent();
                base.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public new void Open()
        {
            try
            {
                OpenedEvent();
                base.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public new void Write(byte[] buffer, int offset, int count)
        {
            string bytesToWrite = "";
            foreach (var _byte in buffer)
            {
                bytesToWrite += _byte + ", ";
            }
            Console.WriteLine("The following data was sent: " + bytesToWrite);
            base.Write(buffer, offset, count);
        }
    }
}
