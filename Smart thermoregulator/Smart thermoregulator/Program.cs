using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_thermoregulator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string broj_u;
            uint broj_uredjaja;

            Console.WriteLine("Unesite broj uredjaja. ");
            broj_u = Console.ReadLine();

            broj_uredjaja = UInt32.Parse(broj_u);

            if (broj_uredjaja < 4)
            {
                Console.WriteLine("Minimalan broj registrovanih uredjaja mora biti veci ili jednak 4;");
            }

            Klase.Device[] uredjaji = new Klase.Device[broj_uredjaja];

            for (int i = 0; i < broj_uredjaja; ++i)
                uredjaji[i] = new Klase.Device();

            //Proverava da li su id za uredjaje razliciti
            //Ukoliko nisu razliciti, dodeljuje se nova razlicita vrednost 
            for (int i = 0; i < broj_uredjaja; ++i)
            {
                for (int j = i + 1; j < broj_uredjaja; ++j)
                {
                    if (uredjaji[i].DeviceId == uredjaji[j].DeviceId)
                    {
                        uredjaji[j].DeviceId = new Random().Next(0, 10000);
                    }
                }
            }

            var timer = new PeriodicTimer(TimeSpan.FromMinutes(3));
            //System.Threading.Thread.Sleep(1000);
            while (await timer.WaitForNextTickAsync())
            {
                // -ovo se treba promeniti
                for (int i = 0; i < broj_uredjaja; ++i)
                    uredjaji[i].Temperatura = new Random().Next(-100, 100);

                // temperature ^ slati odavde na regulator
                for (int i = 0; i < broj_uredjaja; ++i)
                    Console.WriteLine("Device ID:" + uredjaji[i].DeviceId + " temperatura: " + uredjaji[i].Temperatura);

                Console.WriteLine("\n------------------------\n");
            }

            Console.ReadLine();
        }
    }
}
