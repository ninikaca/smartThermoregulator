using Device.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Implementacije
{
    public class PeriodicTimer : IPeriodicTimer
    {
        private TimeSpan timeSpan;
        public PeriodicTimer(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }
        public Task<bool> WaitForNextTickAsync()
        {
            throw new NotImplementedException();
        }
    }
}
