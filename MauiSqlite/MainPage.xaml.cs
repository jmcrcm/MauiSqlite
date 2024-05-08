﻿using MauiSqlite.Models;
using System.Collections.Generic;

namespace MauiSqlite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            App.PersonRepo.AddNewPerson(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<Person> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }
    }
}
