using Heater.Interfejsi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
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
            CancellationToken ct = new CancellationToken();
            TimeSpan vreme = new TimeSpan(0, 0, 5); // DRUGI PARAMETAR PROMENITI NA 2 MINUTA!!!
            Grejac.devices = Uredjaji; // prenos referenci uredjaja

            for (; !ct.IsCancellationRequested;)
            {
                await PeriodicnaProvera(vreme, ct);

                CheckTempHeater();
            }
        }

        private void CheckTempHeater()
        {
            // koji je rezim rada
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            int trenutniSat = currentTime.Hours;

            if (trenutniSat >= PocetakDnevniRezim && trenutniSat <= KrajDnevniRezim)
            {
                IsDnevniRezim = true;
                IsNocniRezim = false;
            }
            else
            {
                IsDnevniRezim = false;
                IsNocniRezim = true;
            }

            // proracun prosecne temperature
            ProsecnaTemp();

            // izdavanje komande na osnovu trenutne temperature
            if (IsDnevniRezim)
            {
                if (ProsecnaTemperatura < ZeljenaDnevnaTemperatura)
                {
                    Log log = new Log("Ukljucivanje centralne peci!");
                    log.LogNoveInformationPoruke();

                    // ukljucivanje grejaca
                    Grejac.IsHeaterOn = true;
                }
                else
                {
                    Log log = new Log("Centralna pec iskljucena!");
                    log.LogNoveInformationPoruke();

                    // gasenje grejaca
                    Grejac.IsHeaterOn = false;
                }
            }
            else if (IsNocniRezim)
            {
                if (ProsecnaTemperatura < ZeljenaNocnaTemperatura)
                {
                    Log log = new Log("Ukljucivanje centralne peci!");
                    log.LogNoveInformationPoruke();

                    // ukljucivanje grejaca
                    Grejac.IsHeaterOn = true;
                }
                else
                {
                    Log log = new Log("Centralna pec iskljucena!");
                    log.LogNoveInformationPoruke();

                    // gasenje grejaca
                    Grejac.IsHeaterOn = false;
                }
            }
            else
            {
                Log log = new Log("Greska sa centralnom peci!");
                log.LogNoveErrorPoruke();

                // gasenje grejaca
                Grejac.IsHeaterOn = false;
            }

            Grejac.PokreniZagrevanje(); // pokretanje grejaca
        }

        public async Task PeriodicnaProvera(TimeSpan interval, CancellationToken cancellationToken)
        {
            await Task.Delay(interval, cancellationToken);
        }
    }
}
