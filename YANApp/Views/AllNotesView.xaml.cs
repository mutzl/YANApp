using Windows.UI.Xaml.Controls;


namespace YANApp.Views
{
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls.Primitives;
	using Windows.UI.Xaml.Input;
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

		private void UIElement_OnHolding(object sender, HoldingRoutedEventArgs e)
		{
			FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
		}
	}
}
