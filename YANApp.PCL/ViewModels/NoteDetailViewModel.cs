namespace YANApp.PCL.ViewModels
{
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Views;

	using YANApp.PCL.Models;
	using YANApp.PCL.Services;

	public class NoteDetailViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;

		private readonly IDataService dataService;

		private readonly IDialogService dialogService;


		public NoteDetailViewModel(INavigationService navigationService, 
									  IDataService dataService, 
									  IDialogService dialogService)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;
			this.dialogService = dialogService;

			PropertyChanged += (sender, args) =>
				{
					if (args.PropertyName == nameof(Note))
					{
						Note.PropertyChanged += (s, e) => IsDirty = true;
					}
				};
		}


		public Note Note { get; set; }


		public void SaveNote()
		{
			dataService.SaveNote(Note);
			ClearAndGoBack();
		}

		public bool IsDirty { get; set; }


		public async void Cancel()
		{
			if (IsDirty)
			{
				await dialogService.ShowMessage(
					"There is unsaved data. Do you really want to navigate back?",
					"Warning",
					"Yes - bring me back!",
					"No - stay on this page",
					isGoBack =>
						{
							if (isGoBack)
							{
								ClearAndGoBack();
							}
						});
			}
			else
			{
				ClearAndGoBack();
			}


		}

		private void ClearAndGoBack()
		{
			navigationService.GoBack();

		}
	}
}
