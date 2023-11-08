using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAL_TelescopeAdmin;
using Newtonsoft.Json;

namespace TelecopeAdminAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string LoadAvailablePort()
        {           
            try
            {
                Class1 oClass1 = new Class1();
                String[] ports = oClass1.getAvailableComPorts();

                return JsonConvert.SerializeObject(ports);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string TestInput(REF_TelescopeAdmin.REF_Port oREF_Port)
        {
            try
            {
                Class1 oClass1 = new Class1();
                bool isSet = oClass1.ConnectToTelescope(oREF_Port);
                //if (isSet)
                //{
                //    oClass1.ConnectToTelescopeX(oREF_Port);
                //}

                return JsonConvert.SerializeObject(isSet);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string TestRotate(REF_TelescopeAdmin.REF_Port oREF_Port)
        {
            try
            {
                Class1 oClass1 = new Class1();
                bool isSet = oClass1.ConnectToTelescope(oREF_Port);

                return JsonConvert.SerializeObject(isSet);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
