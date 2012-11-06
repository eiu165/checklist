
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iPhone
{
	public partial class SettingsScreen : UIViewController
	{
		public SettingsScreen () : base ("SettingsScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad (); 

		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			this.lblGoal.Text = NSUserDefaults.StandardUserDefaults.StringForKey("goal") + " grams"; 
 
			this.btnInfo.TouchUpInside += (sender, e) => { 
				var controller = new FlipsideScreen () {
					ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal,
				};
				controller.Done += delegate {
					DismissModalViewControllerAnimated (true);
				};
				
				PresentModalViewController (controller, true);
			};
		}


		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			//ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		 
	}
}

