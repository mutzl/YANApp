namespace YANApp.PCL.Models
{
	using System;

	using GalaSoft.MvvmLight;

	public class Note : ObservableObject
	{
		public Note()
		{
			CreatedAt = DateTime.Now;
		}
		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
