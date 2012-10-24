
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;

namespace iPhone
{
	public partial class MailScreen : UIViewController
	{
		public MailScreen () : base ("MailScreen", null)
		{
			this.Title = "Mail";
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		MFMailComposeViewController _mail;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			this.btnSend.TouchUpInside += (o, e) => 
			{ 
				if (MFMailComposeViewController.CanSendMail) { 
					_mail = new MFMailComposeViewController (); 
					_mail.SetMessageBody ("This is the body of the email", 
					                      false); 
					_mail.Finished += HandleMailFinished; 
					this.PresentModalViewController (_mail, true); 
				} else { 
					UIAlertView alert = new UIAlertView("email test", 
					                                    "Email not available on this device", null, "Okay");
					alert.Show();
				} 
			}; 
		}


		
		void HandleMailFinished (object sender, MFComposeResultEventArgs e) 
		{ 
			if (e.Result == MFMailComposeResult.Sent) { 
				UIAlertView alert = new UIAlertView ("Mail Alert", "Mail Sent", 
				                                     null, "Yippie", null); 
				alert.Show (); 
				// you should handle other values that could be returned 
				// in e.Result and also in e.Error 
			} 
			e.Controller.DismissModalViewControllerAnimated (true); 
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

