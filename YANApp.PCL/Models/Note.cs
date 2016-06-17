namespace YANApp.PCL.Models
{
	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Messaging;
	using Newtonsoft.Json;
	using System;

	public class Note : ObservableObject
	{
		public Note()
		{
			CreatedAt = DateTime.Now;
		}

		public int Id { get; set; }

		public string Title { get; set; }

		[JsonProperty("Content")]
		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public override string ToString()
		{
			return $"{Title}";
		}

		public void Delete()
		{
			Messenger.Default.Send(new DeleteMessage(this));
		}
	}

	public class DeleteMessage : GenericMessage<Note>
	{
		public DeleteMessage(Note content)
			: base(content)
		{
		}

		public DeleteMessage(object sender, Note content)
			: base(sender, content)
		{
		}

		public DeleteMessage(object sender, object target, Note content)
			: base(sender, target, content)
		{
		}
	}
}
