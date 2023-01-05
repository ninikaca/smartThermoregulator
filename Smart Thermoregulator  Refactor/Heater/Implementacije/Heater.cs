using Database.Implementacije;
using Database.Interfejsi;
using Device;
using Heater.Interfejsi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Heater
{
    public class Heater : IHeater
    {
        public bool IsHeaterOn { get; set; }
        public ObservableCollection<Device.Device> devices { get; set; }

        Stopwatch ProtekloVreme { get; set; }

        public Heater()
        {
            IsHeaterOn = false;
            ProtekloVreme = new Stopwatch();
        }
        public void PokreniZagrevanje()
        {
            if (IsHeaterOn) // ako je izdata komanda za paljenje grejaca
            {
                ProtekloVreme.Start(); // pokreni brojanje koliko je grejac radio

                foreach (Device.Device d in devices)
                {
                    d.Temperatura += 0.01;
                }
            }
            else
            {
                ProtekloVreme.Stop(); // zaustavi rad i upisi u evidenciju
                Evidencija();
                ProtekloVreme.Reset(); // ponovno brojanje od nule
            }
        }

        // TODO LOG U BAZU PODATAKA
        public void Evidencija()
        {
            try
            {
                IWriteHeaterData belezenjePodataka = new WriteHeaterData();

                var ts = ProtekloVreme.Elapsed;
                int proteklo = ts.Seconds;
                string datum = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                decimal potroseno = (decimal)(proteklo * 0.125); // 125W po sekundi

                belezenjePodataka.Evidencija(proteklo, datum, potroseno);
            }
            catch (Exception)
            {
                // catch Exception
            }
        }
    }
}
