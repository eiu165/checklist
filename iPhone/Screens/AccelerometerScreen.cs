
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iPhone
{
	public partial class AccelerometerScreen : UIViewController
	{
		public AccelerometerScreen () : base ("AccelerometerScreen", null)
		{
			this.Title = "Accelerometer";
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

			var alert = new UIAlertView("Accelerometer demo",  "this one is Not working yet", null, "Okay");
			alert.Show();


			UIAccelerometer.SharedAccelerometer.UpdateInterval = 0.05;
			
			UIAccelerometer.SharedAccelerometer.Acceleration += delegate(object sender, UIAccelerometerEventArgs e)
			{
				double accelerationX = e.Acceleration.X;
				double accelerationY = - e.Acceleration.Y;
				double currentRawReading = Math.Atan2(accelerationY, accelerationX);
				
				var angle = RadiansToDegrees(currentRawReading);

				var s = string.Format("x: {0}\n"+
				                      "y: {1}\n"+
				                      "angle: {2}\n"+
				                      "time: {3}\n", accelerationX, accelerationY, angle, DateTime.Now.ToString());
				lblOutput.Text = angle.ToString();
			};

		}
		
		private double RadiansToDegrees(double radians)
		{
			return radians * 180/Math.PI;
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

