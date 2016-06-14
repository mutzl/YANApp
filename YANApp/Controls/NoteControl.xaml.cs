// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace YANApp.Controls
{
	using System;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;

	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Data;

	using YANApp.PCL.Models;

	public sealed partial class NoteControl : UserControl, INotifyPropertyChanged
	{

		private string originalTitle = null;
		private string originalContent = null;

		public NoteControl()
		{
			this.InitializeComponent();

			DataContext = this;

			Loaded += (sender, args) =>
				{
					Note.PropertyChanged += (s, e) =>
						{
							RaisePropertyChanged(nameof(CanSaveNote));
							IsDirty = Note.Title != originalTitle || Note.Content != originalContent;
						};
				};

		}

		public Note Note
		{
			get { return (Note)GetValue(NoteProperty); }
			set { SetValue(NoteProperty, value); }
		}
		// Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NoteProperty =
			DependencyProperty.Register("Note", typeof(Note), typeof(NoteControl), new PropertyMetadata(null, PropertyChangedCallback));

		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			var control = (NoteControl)dependencyObject;
			control.originalTitle = ((Note)args.NewValue).Title;
			control.originalContent = ((Note)args.NewValue).Content;
			control.Bindings.Update();
		}

		public event EventHandler<EventArgs> SaveClicked;
		public event EventHandler<EventArgs> CancelClicked;

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SaveClicked?.Invoke(this, EventArgs.Empty);
			IsDirty = false;
		}
		private void CancelButton_OnClick(object sender, RoutedEventArgs e)
		{
			CancelClicked?.Invoke(this, EventArgs.Empty);
		}

		public bool IsDirty { get; private set; }
		public bool CanSaveNote
		{
			get
			{
				bool hasData = !string.IsNullOrEmpty(Note.Title) && !string.IsNullOrEmpty(Note.Content);
				if (NeedChangeForSave)
				{
					return IsDirty && hasData;
				}

				return hasData;
			}
		}
		public bool NeedChangeForSave { get; set; }


		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
