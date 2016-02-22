using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace Robotersteuerung
{
    /// <summary>
    /// Interaktionslogik für SerialPortSettingsWindow.xaml
    /// </summary>
    public partial class SerialPortSettingsWindow : Window
    {
        private int baudrate = 9600;
        private List<int> availableBaudrates = null;

        public int Baudrate { get { return baudrate; } }
        public List<int> AvailableBaudrates { get { return availableBaudrates; } }

        

        public SerialPortSettingsWindow()
        {
            InitializeComponent();
        }

        public void reloadSettings()
        {
            COMMPROP commProp = new COMMPROP();
            IntPtr hFile = CreateFile(@"\\.\" + MainWindow.instance.serialPort.PortName, 0, 0, IntPtr.Zero, 3, 0x80, IntPtr.Zero);
            GetCommProperties(hFile, ref commProp);
        }

        #region Valid Baudrates

        [StructLayout(LayoutKind.Sequential)]
        struct COMMPROP
        {
            short wPacketLength;
            short wPacketVersion;
            int dwServiceMask;
            int dwReserved1;
            int dwMaxTxQueue;
            int dwMaxRxQueue;
            int dwMaxBaud;
            int dwProvSubType;
            int dwProvCapabilities;
            int dwSettableParams;
            int dwSettableBaud;
            short wSettableData;
            short wSettableStopParity;
            int dwCurrentTxQueue;
            int dwCurrentRxQueue;
            int dwProvSpec1;
            int dwProvSpec2;
            string wcProvChar;
        }

        [DllImport("kernel32.dll")]
        static extern bool GetCommProperties(IntPtr hFile, ref COMMPROP lpCommProp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess,
                   int dwShareMode, IntPtr securityAttrs, int dwCreationDisposition,
                   int dwFlagsAndAttributes, IntPtr hTemplateFile);

        
        #endregion
    }
}
