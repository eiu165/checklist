
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using System.IO;
using System.Json;

namespace iPhone
{
	public partial class WebServiceScreen : UIViewController
	{
		public WebServiceScreen () : base ("WebServiceScreen", null)
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
 
			this.btnGet.TouchUpInside += (sender, e) => {

				JsonObject j;
				Uri address = new Uri("http://webapi.apphb.com/api/instructors/1");
				HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create (address);
				using (HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse ()) {
					Stream s = httpRes.GetResponseStream ();

					j = (JsonObject)JsonObject.Load (s);
				}

				var alert = new UIAlertView("test",  j.ToString(), null, "Okay");
				alert.Show();
			};


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

