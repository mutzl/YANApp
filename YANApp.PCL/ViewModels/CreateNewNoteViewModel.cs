﻿namespace YANApp.PCL.ViewModels
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



		public string NewTitle { get; set; }

		public string NewContent { get; set; }


		public void SaveNote()
		{
			var note = new Note
				           {
					           Title = NewTitle,
					           Content = NewContent,
				           };
			dataService.SaveNote(note);
			navigationService.GoBack();
		}


		public bool CanSaveNote => !string.IsNullOrEmpty(NewTitle) && !string.IsNullOrEmpty(NewContent);

		public async void Cancel()
		{
			if (!string.IsNullOrEmpty(NewTitle) || !string.IsNullOrEmpty(NewContent))
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
			NewTitle = string.Empty;
			NewContent = string.Empty;
			navigationService.GoBack();

		}
	}
}
