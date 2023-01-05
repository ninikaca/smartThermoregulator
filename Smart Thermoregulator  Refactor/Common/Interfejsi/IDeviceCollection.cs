using System.Collections.ObjectModel;

namespace Common.Interfejsi
{
    public interface IDeviceCollection
    {
        bool AddDevice();
        ObservableCollection<Device.Device> GetDevices();
    }
}
