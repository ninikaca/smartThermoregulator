using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;

namespace Smart_thermoregulator.Klase
{
    public class Device : IDevice
    {
        private int deviceId;
        private double temperatura;

        public Device()
        {
            this.deviceId = new Random().Next(0, 10000);
            this.temperatura = new Random().Next(-100, 100);
        }

        public int DeviceId { get => deviceId; set => deviceId = value; }
        public double Temperatura { get => temperatura; set => temperatura = value; }


        //TO DO: Uraditi metodu
        public void novoMerenje() { }

    }
}
