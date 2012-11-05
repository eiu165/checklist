
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
 
			this.tbGet.ShouldReturn = (s) =>
			{
				this.tbGet.ResignFirstResponder();
				return true;
			};


			this.btnGet.TouchUpInside += (sender, e) => {

				JsonObject j;
				var address = String.Format("http://webapi.apphb.com/api/instructors/{0}", this.tbGet.Text); 
				HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create (new Uri(address));
				using (HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse ()) {
					Stream s = httpRes.GetResponseStream ();

					j = (JsonObject)JsonObject.Load (s);
				}
				this.lblGet.Text = string.Format("{0}  {1}", j.ToString(), DateTime.Now.ToString("HH:mm:ss"));
			};
 
			this.btnPost.TouchUpInside += (sender, e) => {
				string name = this.tbPostName.Text; 
				/*
				ASCIIEncoding encoding=new ASCIIEncoding();
				string postData="name="+name;
				//postData += ("&username="+strName);
				byte[]  data = encoding.GetBytes(postData);
				
				// Prepare web request...
				HttpWebRequest myRequest =
					(HttpWebRequest)WebRequest.Create("http://localhost/MyIdentity/Default.aspx");
				myRequest.Method = "POST";
				myRequest.ContentType="application/x-www-form-urlencoded";
				myRequest.ContentLength = data.Length;
				Stream newStream=myRequest.GetRequestStream();
				// Send the data.
				newStream.Write(data,0,data.Length);
				newStream.Close();
*/
			};
 

			UILabel newLabel = new UILabel(new Rectangle(200,10,100,30));
			newLabel.Text = "test test test";
			newLabel.BackgroundColor = UIColor.Brown;
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

