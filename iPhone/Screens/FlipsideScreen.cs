
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iPhone
{
	public partial class FlipsideScreen : UIViewController
	{
		public FlipsideScreen () : base ("FlipsideScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		//partial void done (UIBarButtonItem sender)
		//{
		//	if (Done != null)
		//		Done (this, EventArgs.Empty);
		//}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UILabel newLabel = new UILabel(new RectangleF(10,150,100,100));
			newLabel.Text = "hello dynmaic control";
			View.AddSubview(newLabel);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

