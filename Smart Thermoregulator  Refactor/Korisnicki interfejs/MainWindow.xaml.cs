﻿using Common.Implementacije;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // zatvaranje programa
            Close();
        }

        private void cuvanjeDnevneTempBtn_Click(object sender, RoutedEventArgs e)
        {
            if (uredjaji.GetDevices().Count < 4)
            {
                MessageBox.Show("Potrebno je dodati minimalno 4 uređaja!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (pocetakDnevna.SelectedIndex != -1 && krajDnevna.SelectedIndex != -1 && !tempDnevna.Text.Equals(""))
            {
                try
                {
                    int pd = Int32.Parse(pocetakDnevna.Text);
                    int kd = Int32.Parse(krajDnevna.Text);

                    if (pd > kd)
                    {
                        MessageBox.Show("Nije moguće sačuvati podešavanja!\nUnelite ste nevalidne vrednosti!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    CheckFields(pd, kd);
                    SetupUredjaja();
                }
                catch (Exception)
                {
                    MessageBox.Show("Niste uneli broj!", "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nije moguće sačuvati podešavanja!\nUneli ste nevalidne vrednosti!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SetupUredjaja()
        {
            // onemoguci dodavanje uredjaja
            dodajNoviUredjajBtn.IsEnabled = false;

            // kreiranje regulatora
            regulator = new Regulator();

            // uvezivanje uredjaja i regulatora
            regulator.Uredjaji = uredjaji.GetDevices();
            regulator.ZeljenaDnevnaTemperatura = Double.Parse(tempDnevna.Text);
            regulator.PocetakDnevniRezim = Int32.Parse(pocetakDnevna.Text);
            regulator.KrajDnevniRezim = Int32.Parse(krajDnevna.Text);
        }

        private void CheckFields(int pd, int kd)
        {
            // omoguci unos nocne temperature
            // i dugme za start termo regulatora
            tempNocna.IsEnabled = true;

            pocetakNocna.Items.Clear(); // ocisti vrednosti
            krajNocna.Items.Clear(); // ocisti vrednosti

            pocetakNocna.Items.Add(kd);
            krajNocna.Items.Add(pd);
            pocetakNocna.SelectedIndex = 0;
            krajNocna.SelectedIndex = 0;

            // onemoguci prvi unos
            pocetakDnevna.IsEnabled = false;
            krajDnevna.IsEnabled = false;
            cuvanjeDnevneTempBtn.IsEnabled = false;
            tempDnevna.IsEnabled = false;

            startTermoBtn.IsEnabled = true;
        }

    }
}
