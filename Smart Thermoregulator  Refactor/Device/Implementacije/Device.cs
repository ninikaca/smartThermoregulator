using Device.Implementacije;
using Device.Interfejsi;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Device
{
    public class Device : IDevice, INotifyPropertyChanged
    {
        private int deviceId;
        private double temperatura;

        public Device()
        {
            deviceId = new Random().Next(0, 10000);
            temperatura = Math.Round((new Random().Next(-10, 37) + (new Random().NextDouble())), 2); ;

            // todo
            NovoMerenje();
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
                    OnPropertyChanged("Temperatura");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // promena temperature na uredjaju treba se prikaze i u datagrid-u
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public async void NovoMerenje()
        {
            // slanje merenja regulatoru
            PeriodicTimer vreme = new PeriodicTimer();

            await vreme.SlanjeMerenja(deviceId, temperatura);
        }
    }
}
