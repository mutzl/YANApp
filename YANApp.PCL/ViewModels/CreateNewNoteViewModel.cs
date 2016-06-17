namespace YANApp.PCL.ViewModels
{
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Views;

	using YANApp.PCL.Models;
	using YANApp.PCL.Services;

	public class CreateNewNoteViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;

		private readonly IDataService dataService;

		private readonly IDialogService dialogService;


		public CreateNewNoteViewModel(INavigationService navigationService, 
									  IDataService dataService, 
									  IDialogService dialogService)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;
			this.dialogService = dialogService;


		}


		public Note NewNote { get; private set; } = new Note();


		public async void SaveNote()
		{
			await dataService.AddNote(NewNote);
			ClearAndGoBack();
		}



		public async void Cancel()
		{
			if (!string.IsNullOrEmpty(NewNote.Title) || !string.IsNullOrEmpty(NewNote.Description))
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
			NewNote = new Note();
			navigationService.GoBack();

		}
	}
}
