namespace YANApp.PCL.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using YANApp.PCL.Models;

	public interface IDataService
	{
		Task<IEnumerable<Note>> GetAllNotes();

		Task AddNote(Note note);

		Task SaveNote(Note note);

		Task DeleteNote(Note note);
	}
}
