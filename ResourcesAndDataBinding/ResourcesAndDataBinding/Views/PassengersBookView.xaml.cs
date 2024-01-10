using ResourcesAndDataBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengersBook : ContentPage
    {
        private Models.PassengersBook NewPassengerBook { get; set; }
        public PassengersBook()
        {
            InitializeComponent();
            NewPassengerBook = new Models.PassengersBook
            {
                PassengersBookID = 023,
                pages = 02333,
                name = "Book_new"
            };

            BindingContext = NewPassengerBook;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("PassengersBook saved", $"{NewPassengerBook.PassengersBookID} " +
                $"{Environment.NewLine} {NewPassengerBook.pages} " +
                $"{Environment.NewLine} {NewPassengerBook.name}", "Ok");
        }
    }
}