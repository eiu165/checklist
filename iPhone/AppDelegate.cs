using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace iPhone
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		//---- declarations
		UIWindow window;
		public static UITabBarController tabBarController;  

		// This method is invoked when the application has loaded its UI and it is ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			this.window = new UIWindow (UIScreen.MainScreen.Bounds);

 
			
			tabBarController = new UITabBarController ();
			
			tabBarController.ViewControllers = new UIViewController [] {
				new UINavigationController(new HelloUniverseScreen()) { TabBarItem = new UITabBarItem("hello", UIImage.FromBundle("Images/home.png"),0)},
				new UINavigationController(new HomeScreen()), 
				new UINavigationController(new CameraScreen()), 
				new UINavigationController(new MailScreen()), 
			};  
			this.window.RootViewController = tabBarController;
			
			this.window.MakeKeyAndVisible ();

			
			return true;
		}

	}
}
