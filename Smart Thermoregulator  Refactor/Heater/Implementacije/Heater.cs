﻿using Heater.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Evidencija()
    }
}
