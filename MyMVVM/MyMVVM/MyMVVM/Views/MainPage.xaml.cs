using MyMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMVVM
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Person> persons { get; set; }
        private PersonService _personService { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _personService = new PersonService();

            var persons = new ObservableCollection<Person>(_personService.GetPersons());
            personsListView.ItemsSource = persons;
        }
    }
}
