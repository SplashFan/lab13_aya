using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ResourcesAndDataBinding.ViewModels
{
    public class PassengerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Passenger> People { get; set; }
        private Passenger _selectedPassenger;
        public Passenger SelectedPassenger
        {
            get
            {
                return _selectedPassenger;
            }
            set
            {
                _selectedPassenger = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCommand { get; set; }
        public ICommand AddPassengerCommand { get; set; }
        public ICommand DeletePassengerCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadSampleData()
        {
            People = new ObservableCollection<Passenger>();
            // sample data
            Passenger a1 =
            new Passenger
            {
                passengerID = 1,
                name = "Vasya",
                ticket = 1111,
            };
            Passenger a2 =
            new Passenger
            {
                passengerID = 2,
                name = "Kolya",
                ticket = 2222,
            };
            Passenger a3 =
            new Passenger
            {
                passengerID = 3,
                name = "Nekolya",
                ticket = 3333,
            };
            People.Add(a1);
            People.Add(a2);
            People.Add(a3);
        }

        public PassengerViewModel()
        {
            LoadSampleData();

            Random r = new Random();
            AddPassengerCommand = new Command(() => People.Add(new Passenger()
            {
                passengerID = 4,
                name = "VascheNeKolya",
                ticket = 4444,
            }));

            DeletePassengerCommand = new Command<Passenger>((author) => People.Remove(author));

            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                LoadSampleData();
                // Simulates a longer operation
                await Task.Delay(2000);
                IsRefreshing = false;
            });
        }

    }
}
