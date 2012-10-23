using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.IO;

namespace Sample
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UINavigationController navigation;
		UIWindow window;
		const string footer = 
			"These show the two sets of APIs\n" +
				"available in MonoTouch.Dialogs";
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			JsonElement sampleJson;
			var Last = new DateTime (2010, 10, 7);
			Console.WriteLine (Last);
			
			var p = Path.GetFullPath ("background.png");
			
			var menu = new RootElement ("Demos"){
				new Section ("Element API"){
					new StringElement ("iPhone Settings Sample", DemoElementApi),
					new StringElement ("Add Remove", DemoAddRemove), 
					new StringElement ("Register", DemoRegister),
					new StringElement ("Reflection", DemoReflectionApi),
					new StringElement ("Camera Sample", DemoCameraApi),
				},
			};


			//
			// Create our UI and add it to the current toplevel navigation controller
			// this will allow us to have nice navigation animations.
			//
			var dv = new DialogViewController (menu) {
				Autorotate = true
			};
			navigation = new UINavigationController ();
			navigation.PushViewController (dv, true);				
			
			// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = navigation;	
			else
				window.AddSubview (navigation.View);
			
			return true;
		}
		 
		
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}
