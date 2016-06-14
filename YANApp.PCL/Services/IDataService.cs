namespace YANApp.PCL.Services
{
	using System.Collections.Generic;

	using YANApp.PCL.Models;

	public interface IDataService
	{
		IEnumerable<Note> GetAllNotes();

		void AddNote(Note note);

		void SaveNote(Note note);

		void DeleteNote(Note note);
	}
}
