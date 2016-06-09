using Windows.UI.Xaml.Controls;


namespace YANApp.Views
{
	using System;

	using Windows.UI.Core;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Navigation;

	using YANApp.PCL.ViewModels;

	public sealed partial class CreateNoteView : Page
	{
		public CreateNoteView()
		{
			this.InitializeComponent();
		}

		private CreateNewNoteViewModel ViewModel => DataContext as CreateNewNoteViewModel;

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			((App)Application.Current).OnBackRequested += OnOnBackRequested;
			base.OnNavigatedTo(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			((App)Application.Current).OnBackRequested -= OnOnBackRequested;

			base.OnNavigatingFrom(e);
		}

		private void OnOnBackRequested(object sender, BackRequestedEventArgs e)
		{

			e.Handled = true;

			ViewModel.Cancel();

		}
	}
}
