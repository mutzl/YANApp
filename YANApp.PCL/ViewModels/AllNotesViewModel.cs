namespace YANApp.PCL.ViewModels
{
	using System;
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


			PropertyChanged += (sender, args) =>
			{
				if (args.PropertyName == nameof(SearchTerm)
				 || args.PropertyName == nameof(FromDate)
				 || args.PropertyName == nameof(ToDate))
				{
					LoadData();
				}
			};
		}


		public Note SelectedNote { get; set; }

		public void LoadData()
		{
			var notes = dataService.GetAllNotes();

			//if (!string.IsNullOrEmpty(SearchTerm)) notes = notes.Where(n => n.Title.ToLower().Contains(SearchTerm) || n.Content.ToLower().Contains(SearchTerm));
			//if (FromDate.HasValue)                 notes = notes.Where(n => n.CreatedAt >= FromDate.Value.Date);  
			//if (ToDate.HasValue)                   notes = notes.Where(n => n.CreatedAt < ToDate.Value.Date.AddDays(1));

			notes = notes.Where(n => (!FromDate.HasValue || n.CreatedAt >= FromDate.Value.Date)
								  && (!ToDate.HasValue || n.CreatedAt < ToDate.Value.Date.AddDays(1))
								  && (string.IsNullOrEmpty(SearchTerm) || n.Title.ToLower().Contains(SearchTerm) || n.Content.ToLower().Contains(SearchTerm)));

			notes = settings.IsSortAscending
						? notes.OrderBy(n => n.CreatedAt)
						: notes.OrderByDescending(n => n.CreatedAt);


			notes = notes.Take(settings.NumberOfNotes);
			Notes = new ObservableCollection<Note>(notes);
		}

		public bool IsEmptyList => Notes.Count == 0;

		public ObservableCollection<Note> Notes { get; set; }

		public string SearchTerm { get; set; }

		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }

	}
}
