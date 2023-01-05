using Database.Interfejsi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Implementacije
{
    public class WriteHeaterData : IWriteHeaterData
    {
        public bool Evidencija(int radioSati, string datum, decimal potrosenoKw)
        {
            using (IDbConnection konekcija = DatabaseConnection.GetConnection())
            {
                konekcija.Open();

                using (IDbCommand komanda = konekcija.CreateCommand())
                {
                    komanda.CommandText = "INSERT INTO HEATER VALUES(" + radioSati + ", '" + datum + "'," + potrosenoKw + ")";
                    komanda.Prepare();

                    komanda.ExecuteNonQuery();

                    return true;
                }
            }
        }
    }
}
