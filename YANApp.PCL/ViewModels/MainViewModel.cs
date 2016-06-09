namespace YANApp.PCL.ViewModels
{
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Views;

	public class MainViewModel : ViewModelBase
	{

		private readonly INavigationService navigationService;

		public MainViewModel(INavigationService navigationService)
		{
			this.navigationService = navigationService;
		}
		
		public void GotoCreateNewNote()
		{
			navigationService.NavigateTo(Common.Navigation.CreateNewNote);
		}

		public void GotoAllNotes()
		{
			navigationService.NavigateTo(Common.Navigation.AllNotes);

		}

		public void GotoSettings()
		{
			navigationService.NavigateTo(Common.Navigation.Settings);
		}
	}
}
