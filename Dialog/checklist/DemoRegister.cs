using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace Sample
{


	
	
	[Preserve (AllMembers=true)]
	public class Register {
		[Section]
		public bool AccountEnabled;
		[Skip] public bool Hidden;
		
		[Section ("Info", "Your Info")]
		
		[Entry ("Enter your first name")]
		public string FirstName;
		
		[Entry ("Enter your last name")]
		public string LastName;


	}
	
	



	public partial class AppDelegate
	{ 
		Register register;
		 
		public  void  DemoRegister ()
		{
			if (register == null) {
				register = new Register();
			}
			var bc = new BindingContext (null, register, "Register");

			
			var dv = new DialogViewController (bc.Root, true);



			// When the view goes out of screen, we fetch the data.
			dv.ViewDisappearing += delegate {
				// This reflects the data back to the object instance
				bc.Fetch ();
				
				// Manly way of dumping the data.
				Console.WriteLine ("Current status:");
				Console.WriteLine (
					"fname:           {0}\n" +
					"lname:           {1}\n", 
					register.FirstName, register.LastName);
			};
			navigation.PushViewController (dv, true);
		}
	}
}

