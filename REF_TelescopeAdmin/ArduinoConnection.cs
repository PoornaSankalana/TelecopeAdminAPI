using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REF_TelescopeAdmin
{
    public class ArduinoConnection
    {
         SerialPort port;


        public SerialPort ConnectToArduino(REF_Port oREF_Port)
        {     
            string selectedPort = oREF_Port.portName;
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("#STAR\n");
            return port;

        }
        public void DisconnectFromArduino(REF_Port oREF_Port, SerialPort port2)
        {
            string selectedPort = oREF_Port.portName;
            port2.Write("#STOP\n");
            port2.Close();
                             
        }
    }
}
