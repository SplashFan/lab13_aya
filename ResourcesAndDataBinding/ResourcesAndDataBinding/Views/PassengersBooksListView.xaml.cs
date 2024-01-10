using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerBooksListView : ContentPage
    {
        private ObservableCollection<Models.PassengersBook> PassengersBook { get; set; }
        public PassengerBooksListView()
        {
            InitializeComponent();
            PassengersBook = new ObservableCollection<Models.PassengersBook>();
            Models.PassengersBook j1 = new Models.PassengersBook
            {
                PassengersBookID = 01,
                pages = 0111,
                name = "aaaa"
            };
            Models.PassengersBook j2 = new Models.PassengersBook
            {
                PassengersBookID = 02,
                pages = 0222,
                name = "bbbb"
            };
            Models.PassengersBook j3 = new Models.PassengersBook
            {
                PassengersBookID = 03,
                pages = 0333,
                name = "cccc"
            };

            PassengersBook.Add(j1);
            PassengersBook.Add(j2);
            PassengersBook.Add(j3);
            BindingContext = PassengersBook;
        }

        private void PassengersBooksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var PassengersBook = e.SelectedItem as Models.PassengersBook;
            if (PassengersBook != null)
            {
                DisplayAlert("Edit", "Here we can edit selected element", "Ok");
            }
        }
    }
}