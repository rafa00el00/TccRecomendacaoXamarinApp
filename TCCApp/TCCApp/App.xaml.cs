
using TCCApp.Negocio;
using TCCApp.Services;
using TCCApp.Views;
using Xamarin.Forms;

namespace TCCApp
{
    public partial class App : Application
	{
        
		public App ()
		{
			InitializeComponent();

            DependencyService.Register<IAuthNegocio, AuthNegocio>();
            DependencyService.Register<IEventoNegocio, EventoNegocio>();
            DependencyService.Register<IEventoService, EventoService>();
            DependencyService.Register<IServiceHelper, ServiceHelper>();
            
            MainPage = new NavigationPage(new LoginPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
