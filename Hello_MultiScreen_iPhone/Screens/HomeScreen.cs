using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hello_MultiScreen_iPhone
{
	public partial class HomeScreen : UIViewController
	{ 
		CameraScreen cameraScreen;
		NotifyScreen notifyScreen;
		MailScreen mailScreen;
		AccelerometerScreen accelerometerScreen;
		WebServiceScreen webServiceScreen;


		//loads the HomeScreen.xib file and connects it to this object
		public HomeScreen () : base ("HomeScreen", null)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		 
 
			this.btnCamera2.TouchUpInside += (sender, e) => {
				if(this.cameraScreen == null) { this.cameraScreen = new CameraScreen(); }
				this.NavigationController.PushViewController(this.cameraScreen, true);
			};
			this.btnNotify.TouchUpInside += (sender, e) => {
				if(this.notifyScreen == null) { this.notifyScreen = new NotifyScreen(); }
				this.NavigationController.PushViewController(this.notifyScreen, true);
			};
			
			this.btnAccelerometer.TouchUpInside += (sender, e) => {
				if(this.accelerometerScreen == null) { this.accelerometerScreen = new AccelerometerScreen(); }
				this.NavigationController.PushViewController(this.accelerometerScreen, true);
			};
			this.btnMail.TouchUpInside += (sender, e) => {
				if(this.mailScreen == null) { this.mailScreen = new MailScreen(); }
				this.NavigationController.PushViewController(this.mailScreen, true);
			};
			this.btnWebService.TouchUpInside += (sender, e) => {
				if(this.webServiceScreen == null) { this.webServiceScreen = new WebServiceScreen(); }
				this.NavigationController.PushViewController(this.webServiceScreen, true);
			};



		}
		
		/// <summary>
		/// Is called when the view is about to appear on the screen. We use this method to hide the 
		/// navigation bar.
		/// </summary>
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			this.NavigationController.SetNavigationBarHidden (true, animated);
		}
		
		/// <summary>
		/// Is called when the another view will appear and this one will be hidden. We use this method
		/// to show the navigation bar again.
		/// </summary>
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			this.NavigationController.SetNavigationBarHidden (false, animated);
		}
	}
}
