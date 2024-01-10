using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ResourcesAndDataBinding.Models
{
    public class Passenger : INotifyPropertyChanged
    {
        public int passengerID { get; set; }

        private string _name;

        [MaxLength(50)]
        [NotNull]
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _ticketID;
        public int ticket
        {
            get
            {
                return _ticketID;
            }

            set
            {
                _ticketID = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName
                                        = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
