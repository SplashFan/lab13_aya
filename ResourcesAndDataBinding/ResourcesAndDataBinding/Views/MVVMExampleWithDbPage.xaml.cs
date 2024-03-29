﻿using ResourcesAndDataBinding.ViewModels;
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
    public partial class MVVMExampleWithDbPage : ContentPage
    {
        private PassengersBookDbViewModel ViewModel { get; set; }

        public MVVMExampleWithDbPage()
        {
            InitializeComponent();
            this.ViewModel = new PassengersBookDbViewModel();
            this.BindingContext = this.ViewModel;
        }
    }
}