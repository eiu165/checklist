//
// Shows how to add/remove cells dynamically.
//

using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace Sample
{
	public partial class AppDelegate
	{
		RootElement demoRoot2;
		Section region2;
		Random rnd2;
		int count2;		
		
		public void DemoAddRemove2 ()
		{
			rnd2 = new Random ();
			var section = new Section (null, "Elements are added randomly") {
				new StringElement ("Add elements", AddElements2),
				new StringElement ("Remove top element", RemoveElements2),
		 	};
			region2 = new Section ();
			
			demoRoot2 = new RootElement ("Add/Remove Demo") { section, region2 };
			var dvc = new DialogViewController (demoRoot2, true);
			navigation.PushViewController (dvc, true);
		}
		
		void AddElements2 ()
		{
			region2.Insert (rnd2.Next (0, region2.Elements.Count),
			               UITableViewRowAnimation.Fade,
			               new StringElement ("Ding " + count2++));	               
		}
		 
		void RemoveElements2 ()
		{
			region2.RemoveRange (0, 1);
		}	
		  
	}
}
