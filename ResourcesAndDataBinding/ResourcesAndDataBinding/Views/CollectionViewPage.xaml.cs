using ResourcesAndDataBinding.Models;
using ResourcesAndDataBinding.ViewModels;
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
    public partial class CollectionViewPage : ContentPage
    {

        private PassengersBookViewModel ViewModel { get; set; }
        public CollectionViewPage()
        {
            InitializeComponent();
            ViewModel = new PassengersBookViewModel();
            BindingContext = ViewModel;
        }

        private void PassengersBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // In case of single selection
            var selectedPerson = this.PassengersBookList.SelectedItem as Models.PassengersBook;

            // In case of multi-selection:
            var singlePerson = e.CurrentSelection.FirstOrDefault() as Models.PassengersBook;

            var selectedObjects = e.CurrentSelection.Cast<Models.PassengersBook>();
            foreach (var person in selectedObjects)
            {
                // Handle your object properties here...
            }
        }
    }
}