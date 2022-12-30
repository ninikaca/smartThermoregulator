using Device.Interfejsi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Device.Implementacije
{
    public class PeriodicTimer : IPeriodicTimer
    {
        public async Task SlanjeMerenja(int d_id, double d_t)
        {
            CancellationToken ct = new CancellationToken();
            TimeSpan vreme = new TimeSpan(0, 0, 5);

            for (; !ct.IsCancellationRequested;)
            {
                await PeriodicnaProvera(vreme, ct);

                /// UKLONITI NA KRAJU
                // slanje podataka na regulator
                string str = "[" + d_id.ToString() + "] Slanje podataka na regulator: " + d_t.ToString() + "°C";
                // Trace.WriteLine(str);
                using (StreamWriter writer = new StreamWriter("uredjaji.txt", true))
                {
                    // dodavanje poruke na kraj datoteke za belezenje poruka
                    writer.WriteLine(str);
                }
            }
        }

        public async Task PeriodicnaProvera(TimeSpan interval, CancellationToken cancellationToken)
        {
            await Task.Delay(interval, cancellationToken);
        }
    }
}
