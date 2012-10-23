
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hello_MultiScreen_iPhone
{
	public partial class NotifyScreen : UIViewController
	{
		public NotifyScreen () : base ("NotifyScreen", null)
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

			
			this.btnNotify.TouchUpInside += (sender, e) => {
				//Schedule one minute from the time of execution with no repeat
				UILocalNotification notification = new UILocalNotification{
					FireDate = DateTime.Now.AddSeconds(10),
					TimeZone = NSTimeZone.LocalTimeZone,
					AlertBody = "This is your scheduled local notification!",
					RepeatInterval = 0
				};
				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
				UIAlertView alert = new UIAlertView("Notification Test", 
				                                    "press the home button NOW to see the notification while app is not in foreground", null, "Okay");
				alert.Show();
			};
 

		}
		/*public override void ReceivedLocalNotification(UIApplication application, 
		                                               UILocalNotification notification)
		{
			//Do something to respond to the scheduled local notification
			UIAlertView alert = new UIAlertView("Notification Test", 
			                                    notification.AlertBody, null, "Okay");
			alert.Show();
		}*/
		
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

