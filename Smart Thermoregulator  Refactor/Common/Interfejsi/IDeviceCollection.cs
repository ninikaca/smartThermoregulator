using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
