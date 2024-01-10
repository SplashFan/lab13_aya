using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace ResourcesAndDataBinding.ViewModels
{
    public class PassengersBookViewModel
    {
        public ObservableCollection<PassengersBook> PassengersBooks { get; set; }

        public PassengersBook SelectedPassengerBook { get; set; }

        public PassengersBookViewModel()
        {
            this.PassengersBooks = new ObservableCollection<PassengersBook>();
            PassengersBooks = new ObservableCollection<PassengersBook>();
            PassengersBook pb1 = new PassengersBook
            {
                PassengersBookID = 1,
                pages = 111,
                name = "Anton"
            };
            PassengersBook pb2 = new PassengersBook
            {
                PassengersBookID = 2,
                pages = 222,
                name = "Boris"
            };
            PassengersBook pb3 = new PassengersBook
            {
                PassengersBookID = 3,
                pages = 333,
                name = "Charlie"
            };

            PassengersBooks.Add(pb1);
            PassengersBooks.Add(pb2);
            PassengersBooks.Add(pb3);
        }
    }
}
