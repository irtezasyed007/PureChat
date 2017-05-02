using Xamarin.Forms;

namespace PureChat
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new PureChatPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
