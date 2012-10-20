using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hello_MultiScreen_iPhone
{
	public partial class HomeScreen : UIViewController
	{
		HelloWorldScreen helloWorldScreen;
		HelloUniverseScreen helloUniverseScreen; 
		CameraScreen cameraScreen;
		NotifyScreen notifyScreen;
		MailScreen mailScreen;
		AccelerometerScreen accelerometerScreen;


		//loads the HomeScreen.xib file and connects it to this object
		public HomeScreen () : base ("HomeScreen", null)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		
			//---- when the hello world button is clicked
			this.btnHelloWorld.TouchUpInside += (sender, e) => {
				//---- instantiate a new hello world screen, if it's null (it may not be null if they've navigated
				// backwards from it
				if(this.helloWorldScreen == null) { this.helloWorldScreen = new HelloWorldScreen(); }
				//---- push our hello world screen onto the navigation controller and pass a true so it navigates
				this.NavigationController.PushViewController(this.helloWorldScreen, true);
			};
			
			//---- same thing, but for the hello universe screen
			this.btnHelloUniverse.TouchUpInside += (sender, e) => {
				if(this.helloUniverseScreen == null) { this.helloUniverseScreen = new HelloUniverseScreen(); }
				this.NavigationController.PushViewController(this.helloUniverseScreen, true);
			};
 
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
