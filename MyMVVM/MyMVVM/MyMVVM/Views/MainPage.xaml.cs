using MyMVVM.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyMVVM
{
    public partial class MainPage : ContentPage
    {
        private List<Person> persons { get; set; }
        private PersonService _personService { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _personService = new PersonService();
            persons = _personService.GetPersons();
            personsListView.ItemsSource = persons;
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            var persons = _personService.GetPersons();
        }
    }
}
