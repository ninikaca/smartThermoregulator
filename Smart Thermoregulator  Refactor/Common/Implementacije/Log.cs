using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Implementacije
{
    public class Log : ILog
    {
        private string poruka_za_upis;

        public Log(string poruka)
        {
            if (poruka == null)
                throw new ArgumentNullException();

            if (poruka.Trim().Length == 0)
                throw new ArgumentException();

            poruka_za_upis = poruka;
        }

        // metoda koja sluzi za belezenje informacionih poruka
        public void LogNoveErrorPoruke(string poruka)
        {
            throw new NotImplementedException();
        }

        // metoda koja sluzi za belezenje poruka o upozorenju
        public void LogNoveInformationPoruke(string poruka)
        {
            throw new NotImplementedException();
        }

        // metoda koja sluzi za belezenje poruka o gresci
        public void LogNoveWarningPoruke(string poruka)
        {
            throw new NotImplementedException();
        }
    }
}
