namespace YANApp.ViewModels
{
	using GalaSoft.MvvmLight.Ioc;
	using GalaSoft.MvvmLight.Views;

	using PCL.Common;
	using PCL.Services;
	using Services;
	using Views;

	using YANApp.PCL.ViewModels;

	public class UwpViewModelLocator : ViewModelLocator
	{
		static UwpViewModelLocator()
		{
			SimpleIoc.Default.Register(RegisterNavigationService);
			SimpleIoc.Default.Register<IDialogService, DialogService>();
			SimpleIoc.Default.Register<IStorageService, LocalStorageService>();
		}

		private static INavigationService RegisterNavigationService()
		{
			var service = new NavigationService();
			service.Configure(Navigation.CreateNewNote, typeof(CreateNoteView));
			service.Configure(Navigation.AllNotes, typeof(AllNotesView));
			service.Configure(Navigation.Settings, typeof(SettingsView));

			return service;
		}

	}
}
