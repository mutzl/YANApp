namespace YANApp.PCL.Services
{
	using System;
	using System.Collections.Generic;

	using YANApp.PCL.Models;

	public class OneTimeDataService : IDataService
	{
		private readonly List<Note> allNotes;

		public OneTimeDataService()
		{
			allNotes = new List<Note>
				           {
					           new Note { Title = "One",   Content = "First Note",  CreatedAt = DateTime.Now.AddDays(-2), },
					           new Note { Title = "Two",   Content = "Second Note", CreatedAt = DateTime.Now.AddDays(-1), },
					           new Note { Title = "Three", Content = "Third Note",  CreatedAt = DateTime.Now,             },
				           };
		} 
		public IEnumerable<Note> GetAllNotes()
		{
			return allNotes;
		}

		public void SaveNote(Note note)
		{
			allNotes.Add(note);
		}
	}
}
