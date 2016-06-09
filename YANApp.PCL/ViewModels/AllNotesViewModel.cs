namespace YANApp.PCL.ViewModels
{
	using System.Collections.ObjectModel;
	using System.Linq;

	using GalaSoft.MvvmLight;

	using Services;

	using YANApp.PCL.Models;

	public class AllNotesViewModel : ViewModelBase
	{
		private readonly IDataService dataService;

		private readonly SettingsViewModel settings;

		public AllNotesViewModel(IDataService dataService, SettingsViewModel settings)
		{
			this.dataService = dataService;
			this.settings = settings;
		}

		public void LoadData()
		{
			var notes = dataService.GetAllNotes();
			notes = settings.IsSortAscending 
						? notes.OrderBy(n => n.CreatedAt) 
						: notes.OrderByDescending(n => n.CreatedAt);
			notes = notes.Take(settings.NumberOfNotes);
			Notes = new ObservableCollection<Note>(notes);
		}

		public ObservableCollection<Note> Notes { get; set; }

	}
}
