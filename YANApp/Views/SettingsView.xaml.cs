using Windows.UI.Xaml.Controls;


namespace YANApp.Views
{
	using Windows.UI.Xaml.Navigation;
	using YANApp.PCL.ViewModels;

	public sealed partial class SettingsView : Page
	{
		public SettingsView()
		{
			this.InitializeComponent();
		}

		private SettingsViewModel ViewModel => DataContext as SettingsViewModel;

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			ViewModel.Load();
			base.OnNavigatedTo(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			ViewModel.Save();
			base.OnNavigatingFrom(e);
		}
	}
}
