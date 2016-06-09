namespace YANApp.PCL.ViewModels
{
	using GalaSoft.MvvmLight;

	using Services;

	public class SettingsViewModel : ViewModelBase
	{

		private readonly IStorageService storageService;

		public SettingsViewModel(IStorageService storageService)
		{
			this.storageService = storageService;
			Load();
		}

		public int NumberOfNotes { get; set; }

		public bool IsSortAscending { get; set; }

		


		public void Save()
		{
			storageService.Write(nameof(NumberOfNotes), NumberOfNotes);
			storageService.Write(nameof(IsSortAscending), IsSortAscending);
		}

		public void Load()
		{
			NumberOfNotes = storageService.Read<int>(nameof(NumberOfNotes), 5);
			IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), true);
		}
	}
}
