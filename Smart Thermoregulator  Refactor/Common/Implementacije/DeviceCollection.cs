using Common.Interfejsi;
using System.Collections.ObjectModel;

namespace Common.Implementacije
{
    public class DeviceCollection : IDeviceCollection
    {
        private ObservableCollection<Device.Device> listaUredjaja = new ObservableCollection<Device.Device>();


        public bool AddDevice()
        {
            Device.Device novi = new Device.Device();

            if (listaUredjaja.Count > 9) // npr max 9 mernih uredjaja
                return false;
            else
            {
                listaUredjaja.Add(novi);
                return true;
            }
        }

        public ObservableCollection<Device.Device> GetDevices()
        {
            return listaUredjaja;
        }
    }
}
