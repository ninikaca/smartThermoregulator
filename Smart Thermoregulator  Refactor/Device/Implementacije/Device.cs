using Device.Implementacije;
using Device.Interfejsi;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Device
{
    public class Device : IDevice
    {
        private int deviceId;
        private double temperatura;

        public Device()
        {
            deviceId = new Random().Next(0, 10000);
            temperatura = Math.Round((new Random().Next(-10, 37) + (new Random().NextDouble())), 2); ;

        }

        public int DeviceId { get => deviceId; set => deviceId = value; }
        public double Temperatura
        {
            get { return temperatura; }
            set
            {
                if (value != temperatura)
                {
                    temperatura = value;
                
                }
            }
        }

        public void NovoMerenje()
        {
            throw new NotImplementedException();
        }
    }
}
