using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace iPhone
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
			this.Title = "Home";
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		  
//			this.NavigationController.HidesBottomBarWhenPushed = true;
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
			this.btnSettings.TouchUpInside += (sender, e) => { 
				var menu = new RootElement ("Demos"){
					new Section ("Element API"){ 
						new StringElement ("aaa", DemoElementApi),
						new StringElement ("bbb", DemoElementApi),
						new StringElement ("ccc", DemoElementApi),
					},
				}; 
				var dv = new DialogViewController (menu) {
					Autorotate = true
				}; 
 
				this.NavigationController.PushViewController (dv, true);	  
				// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
//				window = new UIWindow (UIScreen.MainScreen.Bounds);
//				window.MakeKeyAndVisible ();
//				if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0)){
//					window.RootViewController = navigation;	
//				}
//				else{
//					window.AddSubview (navigation.View);
//				}


			};
		} 
		public void DemoElementApi ()
		{
			var root = CreateRoot ();
			
			var dv = new DialogViewController (root, true);
			this.NavigationController.PushViewController (dv, true);				
		}
		
		RootElement CreateRoot ()
		{
			return new RootElement ("Settings") {
				new Section (){
					new BooleanElement ("Airplane Mode", false),
					new RootElement ("Notifications", 0, 0) {
						new Section (null, "Turn off Notifications to disable Sounds\n" +
						             "Alerts and Home Screen Badges for the\napplications below."){
							new BooleanElement ("Notifications", false)
						}
					}
				}, 
				new Section () {
					new HtmlElement ("About", "http://monotouch.net"),
					new MultilineElement ("Remember to eat\nfruits and vegetables\nevery day")
				}
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
