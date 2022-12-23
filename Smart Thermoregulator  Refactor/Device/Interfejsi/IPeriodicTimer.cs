using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Interfejsi
{
    public interface IPeriodicTimer
    {
        // TODO: Not used yet
        Task<bool> WaitForNextTickAsync();
    }
}
