using Common.Implementacije;
using Heater;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Korisnicki_interfejs
{
    public partial class MainWindow : Window
    {
        DeviceCollection uredjaji = new DeviceCollection();
        Regulator regulator = null;
        public MainWindow()
        {
            InitializeComponent();

            // povezivanje datagrid i kolekcije uredjaja
            aktivniUredjaji.ItemsSource = uredjaji.GetDevices();
        }

        private void dodajNoviUredjajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (uredjaji.AddDevice())
            {
                MessageBox.Show("Uređaj je uspešno dodat!", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Nije moguće dodati novi uređaj!\nPrekoračili ste limit uređaja za dodavanje!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void IspisLoga_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
