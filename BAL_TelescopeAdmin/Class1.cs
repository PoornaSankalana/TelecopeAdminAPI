using REF_TelescopeAdmin;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_TelescopeAdmin
{
    public class Class1
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        public String[] getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
            return ports;
        }

        public bool ConnectToTelescope(REF_Port oREF_Port)
        {

            ArduinoConnection oArduinoConnection = new ArduinoConnection();
            try
            {
                port = oArduinoConnection.ConnectToArduino(oREF_Port);
                port.Write("#TEXT" + oREF_Port.inputY + "#\n");
                oArduinoConnection.DisconnectFromArduino(oREF_Port, port);
                // Add another 5-second delay
                System.Threading.Thread.Sleep(5000);
                port = oArduinoConnection.ConnectToArduino(oREF_Port);
                port.Write("#TEXX" + oREF_Port.inputX + "#\n");
                oArduinoConnection.DisconnectFromArduino(oREF_Port, port);
                // Add another 5-second delay
                System.Threading.Thread.Sleep(2000);
                // ConnectToTelescopeX(oREF_Port);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        //public bool ConnectToTelescopeX(REF_Port oREF_Port)
        //{

        //    ArduinoConnection oArduinoConnection = new ArduinoConnection();
        //    try
        //    {
        //        port = oArduinoConnection.ConnectToArduino(oREF_Port);
        //       // port.Write("#TEXT" + oREF_Port.inputX + "#\n");
        //        port.Write("#TEXX" + oREF_Port.inputX + "#\n");
        //        oArduinoConnection.DisconnectFromArduino(oREF_Port, port);
                
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return false;
        //    }

        //}

        public bool RotateToTelescope(REF_Port oREF_Port)
        {

            ArduinoConnection oArduinoConnection = new ArduinoConnection();
            try
            {              
                port.Write("#TEXT" + oREF_Port.inputY + "#\n");
                port.Write("#TEXT" + oREF_Port.inputX + "#\n");
                oArduinoConnection.DisconnectFromArduino(oREF_Port, port);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }


        //private bool DisconnectFromArduino(REF_Port oREF_Port)
        //{
        //    ArduinoConnection oArduinoConnection = new ArduinoConnection();
        //    try
        //    {
        //        oArduinoConnection.DisconnectFromArduino(oREF_Port,);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return false;
        //    }
        //}

    }



}
