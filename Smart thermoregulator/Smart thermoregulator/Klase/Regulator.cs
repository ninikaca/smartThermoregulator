using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_thermoregulator.Klase
{
    public class Regulator : IRegulator
    {
        int dnevna_temperatura;
        int nocna_temperatura;

        int br_sati;
        int prosecna_temperatura;

        int komanda;

        enum REZIM { DNEVNI_REZIM, NOCNI_REZIM };

        public int DNEVNA { get => dnevna_temperatura; set => dnevna_temperatura = value; }
        public int NOCNA { get => nocna_temperatura; set => nocna_temperatura = value; }
        public int KOMANDA { get => komanda; set => komanda = value; }

        public void regulacija()
        {
            throw new NotImplementedException();
        }
    }
}
