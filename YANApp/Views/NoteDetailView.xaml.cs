using Windows.UI.Xaml.Controls;


namespace YANApp.Views
{
	using System;

	using Windows.UI.Core;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Navigation;

	using YANApp.PCL.Models;
	using YANApp.PCL.ViewModels;

	public sealed partial class NoteDetailView : Page
	{
		public NoteDetailView()
		{
			this.InitializeComponent(); 
		}

		private NoteDetailViewModel ViewModel => DataContext as NoteDetailViewModel;

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			ViewModel.Note = e.Parameter as Note;
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
