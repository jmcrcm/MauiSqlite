using MauiSqlite.Views.Pages;

namespace MauiSqlite
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("WeatherPage", typeof(WeatherPage));
        }
    }
}
