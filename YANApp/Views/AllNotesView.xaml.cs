using Windows.UI.Xaml.Controls;


namespace YANApp.Views
{
	using Windows.UI.Xaml.Navigation;

	using YANApp.PCL.ViewModels;

	public sealed partial class AllNotesView : Page
	{
		public AllNotesView()
		{
			this.InitializeComponent();
		}

		private AllNotesViewModel ViewModel => DataContext as AllNotesViewModel;

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			ViewModel.LoadData();
			base.OnNavigatedTo(e);
		}
	}
}
