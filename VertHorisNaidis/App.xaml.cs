using Microsoft.Extensions.DependencyInjection;

namespace VertHorisNaidis
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var startPage = new StartPage();
            var navPage = new NavigationPage(startPage)
            {
                BarBackgroundColor = Colors.Bisque,
                BarTextColor = Colors.White
            };

            return new Window(navPage);
        }
    }
}