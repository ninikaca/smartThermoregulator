using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfejsi
{
    interface IDeviceCollection
    {
        bool AddDevice();
        ObservableCollection<Device.Device> GetDevices();
    }
}
