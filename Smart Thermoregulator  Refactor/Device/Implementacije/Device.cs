using System;
using Device.Interfejsi;

namespace Device
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


        //TODO: Uraditi metodu
        public void NovoMerenje() { }

    }
}
