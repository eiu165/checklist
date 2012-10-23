using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace checklist
{
	public class DemoRegister
	{

		
		[Preserve (AllMembers=true)]
		class Register {
			[Section]
			public bool AccountEnabled;
			[Skip] public bool Hidden;
			
			[Section ("Info", "Your Info")]
			
			[Entry ("Enter your first name")]
			public string FirstName;
			
			[Entry ("Enter your last name")]
			public string LastName;
			
			[Section ("Autocapitalize, autocorrect and clear button")]
			
			[Entry (Placeholder = "Enter your name", AutocorrectionType = UITextAutocorrectionType.Yes, AutocapitalizationType = UITextAutocapitalizationType.Words, ClearButtonMode = UITextFieldViewMode.WhileEditing)]
			public string Name;


			[Section ("Enumerations")]
			
			[Caption ("Favorite CLR type")]
			public TypeCode FavoriteType;
			
			[Section ("Checkboxes")]
			[Checkbox]
			bool English = true;
			
			[Checkbox]
			bool Spanish;


			[Section ("Multiline")]
			[Caption ("This is a\nmultiline string\nall you need is the\n[Multiline] attribute")]
			[Multiline]
			public string multi;
			
			[Section ("IEnumerable")]
			[RadioSelection ("ListOfString")] 
			public int selected = 1;
			public IList<string> ListOfString;
		}



		public DemoRegister ()
		{
		}
	}
}

