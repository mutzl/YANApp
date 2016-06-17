#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
namespace YANApp.PCL.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using YANApp.PCL.Models;

	public class OneTimeDataService : IDataService
	{
		private readonly List<Note> allNotes;

		public OneTimeDataService()
		{
			allNotes = new List<Note>
				           {
					           new Note { Title = "One",   Description = "First Note",  CreatedAt = DateTime.Now.AddDays(-2), },
					           new Note { Title = "Two",   Description = "Second Note", CreatedAt = DateTime.Now.AddDays(-1), },
					           new Note { Title = "Three", Description = "Third Note",  CreatedAt = DateTime.Now,             },
				           };
		}
		public async Task<IEnumerable<Note>> GetAllNotes()
		{
			return allNotes;
		}

		public async Task AddNote(Note note)
		{
			allNotes.Add(note);
		}

		public async Task SaveNote(Note note)
		{
			note.CreatedAt = DateTime.Now;
		}

		public async Task DeleteNote(Note note)
		{
			allNotes.Remove(note);
		}
	}
}
