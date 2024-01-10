using ResourcesAndDataBinding.DataAccess;
using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ResourcesAndDataBinding.ViewModels
{
    public class PassengersBookDbViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PassengersBook> Books { get; set; }

        private PassengersBook _selectedBook;
        public PassengersBook SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        public Command AddCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command SaveAllCommand { get; set; }

        public PassengersBooksDataAccess PassengersBooksDataBase;

        private void LoadData()
        {
            Books = new ObservableCollection<PassengersBook>
                ();
        }

        public PassengersBookDbViewModel()
        {
            PassengersBooksDataBase = new PassengersBooksDataAccess();
            LoadData();

            AddCommand =
                new Command(() => Books.Add(new PassengersBook()));

            DeleteCommand =
                new Command<PassengersBook>((passengersbook) =>
                {
                    Books.Remove(passengersbook);
                    if (passengersbook.PassengersBookID != 0)
                        PassengersBooksDataBase.DeletePassengersBook(passengersbook);
                },
                (PassengersBook) => PassengersBook != null);

            SaveAllCommand = new Command(() => PassengersBooksDataBase.SaveAll(Books));

            RefreshCommand =
                new Command(async () =>
                {
                    IsRefreshing = true;
                    LoadData();
                    // Simulates a longer operation
                    await Task.Delay(2000);
                    IsRefreshing = false;
                }
            );
        }
    }
}
