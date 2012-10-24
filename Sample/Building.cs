//
// Sample showing the core Element-based API to create a dialog
//
using System;
using System.Collections.Generic;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Sample
{
	// Use the preserve attribute to inform the linker that even if I do not
	// use the fields, to not try to optimize them away.
	
	[Preserve (AllMembers=true)]
	class Building {
	[Section]
		public bool AccountEnabled;
		[Skip] public bool Hidden;
				
	[Section ("General", "buildingInformation")]
		
		[Entry ("Enter building name")]
		public string Name;
		[Entry ("Enter building location")]
		public string Location; 
		//[Entry (Placeholder = "Enter primary contact name", AutocorrectionType = UITextAutocorrectionType.Yes, AutocapitalizationType = UITextAutocapitalizationType.Words, ClearButtonMode = UITextFieldViewMode.WhileEditing)]
		[Entry (Placeholder = "Enter primary contact name", AutocapitalizationType = UITextAutocapitalizationType.Words, ClearButtonMode = UITextFieldViewMode.WhileEditing)]
		public string ContactName;
		  
		 
		
	[Section ("Image Selection")]
		public UIImage Top;
		public UIImage Middle;
		public UIImage Bottom;
		
	[Section ("Multiline")]
		//[Caption ("This is a\nmultiline string\nall you need is the\n[Multiline] attribute")]
		[Multiline]
		public string multi;
		
	[Section ("IEnumerable")]
		[RadioSelection ("ListOfString")] 
		public int selected = 0;
		public IList<string> ListOfString;
	}


	
	public partial class AppDelegate 
	{
		Building building ;
		
		public void Building ()
		{	
			if (building == null){ 
				
				building = new Building () {
					AccountEnabled = true,   
					ListOfString = new List<string> () { "One", "Two", "Three" }
				};
			}
			var bc = new BindingContext (null, building, "Building");
			
			var dv = new DialogViewController (bc.Root, true);
			
			// When the view goes out of screen, we fetch the data.
			dv.ViewDisappearing += delegate {
				// This reflects the data back to the object instance
				bc.Fetch ();
				
				// Manly way of dumping the data.
				Console.WriteLine ("Current status:");
				Console.WriteLine ( 
					"Name:      	  {0}\n" + 
				    "IEnumerable idx: {1}", 
					building.Name, 
				    building.selected);
			};
			navigation.PushViewController (dv, true);	
		}
	}
}