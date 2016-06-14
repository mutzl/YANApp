namespace YANApp.PCL.ViewModels
{
	using GalaSoft.MvvmLight.Ioc;

	using Microsoft.Practices.ServiceLocation;

	using YANApp.PCL.Services;

	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<AllNotesViewModel>();
			SimpleIoc.Default.Register<CreateNewNoteViewModel>();
			SimpleIoc.Default.Register<NoteDetailViewModel>();
			SimpleIoc.Default.Register<SettingsViewModel>();


			SimpleIoc.Default.Register<IDataService, OneTimeDataService>();
		}

		public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
		public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();
		public AllNotesViewModel AllNotesViewModel => ServiceLocator.Current.GetInstance<AllNotesViewModel>();
		public CreateNewNoteViewModel CreateNewNoteViewModel => ServiceLocator.Current.GetInstance<CreateNewNoteViewModel>();
		public NoteDetailViewModel NoteDetailViewModel => ServiceLocator.Current.GetInstance<NoteDetailViewModel>();

	}
}
