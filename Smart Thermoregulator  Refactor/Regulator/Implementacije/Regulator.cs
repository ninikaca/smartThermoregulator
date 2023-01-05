using Heater.Interfejsi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heater
{
    public class Regulator : IRegulator
    {
        public bool IsNocniRezim { get; set; }
        public bool IsDnevniRezim { get; set; }
        public double ZeljenaDnevnaTemperatura { get; set; }
        public double ZeljenaNocnaTemperatura { get; set; }
        public double ProsecnaTemperatura { get; set; }
        public int PocetakDnevniRezim { get; set; }
        public int KrajDnevniRezim { get; set; }
        public ObservableCollection<Device.Device> Uredjaji { get; set; }

        private Heater Grejac { get; set; }

        public Regulator()
        {
            IsNocniRezim = false;
            IsDnevniRezim = false;
            ZeljenaDnevnaTemperatura = 0;
            ZeljenaNocnaTemperatura = 0;
            ProsecnaTemperatura = 0;

            // instanciranje grejaca
            Grejac = new Heater();
        }

        public async void Regulacija()
        {
            await ProveraRada();
        }

        public async Task ProveraRada()
        {

        }
    }
}
