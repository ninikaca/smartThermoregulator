using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfejsi
{
    public interface IWriteHeaterData
    {
        bool Evidencija(int radioSati, string datum, decimal potrosenoKw);
    }
}
