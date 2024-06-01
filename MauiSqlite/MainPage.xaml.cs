using MauiSqlite.Models;
using System.Collections.Generic;

namespace MauiSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            await App.PersonRepo.AddNewPerson(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";

            List<Person> people = await App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }

        public async void GoToWeatherClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("WeatherPage");
        }

        public async void GoToRestApiClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RestClientPage");
        }
    }
}
