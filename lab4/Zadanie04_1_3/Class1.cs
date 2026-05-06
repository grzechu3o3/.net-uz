using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie04_1_3
{
    [ServiceContract]
    public interface IZadanie
    {
        [OperationContract]
        string doTask(int param1, int param2);
    }

    public class ZadanieImpl : IZadanie
    {
        public string doTask(int param1, int param2)
        {
            return $"{param1} + {param2} = " + (param1+param2) ;
        }
    }

    public class ZadanieManager
    {
        private ServiceHost _wcfHost;

        public void Start()
        {
            string address = "net.pipe://localhost/Usluga3";
            _wcfHost = new ServiceHost(typeof(ZadanieImpl));
            _wcfHost.AddServiceEndpoint(typeof(IZadanie), new NetNamedPipeBinding(), address);
            _wcfHost.Open();
        }

        public void Stop()
        {
            if (_wcfHost != null && _wcfHost.State == CommunicationState.Opened)
            {
                _wcfHost.Close();
            }
        }
    }
}
