
namespace MauiSqlite
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; private set; }

        public App(PersonRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            PersonRepo = repo;
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 400;
            const int newHeight = 600;

            window.Width = newWidth;
            window.Height = newHeight;


            return window;
        }
    }
}
