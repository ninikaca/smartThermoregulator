using System;
using System.Threading.Tasks;

namespace Smart_thermoregulator
{
    internal class PeriodicTimer
    {
        private TimeSpan timeSpan;

        public PeriodicTimer(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        internal Task<bool> WaitForNextTickAsync()
        {
            throw new NotImplementedException();
        }
    }
}