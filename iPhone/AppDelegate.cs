using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.IO;


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
			RegisterDefaultsFromSettingsBundle();

			this.window = new UIWindow (UIScreen.MainScreen.Bounds); 
			tabBarController = new UITabBarController ();  
			var root = MonotouchDialog.CreateRoot ();
			var dv = new DialogViewController (root, true);


			tabBarController.ViewControllers = new UIViewController [] {
				new UINavigationController(new HomeScreen()), 
				new UINavigationController(dv) { TabBarItem = new UITabBarItem("setting", UIImage.FromBundle("Images/home.png"),0)}, 
				new UINavigationController(new CameraScreen()), 
				new UINavigationController(new HelloUniverseScreen()) { TabBarItem = new UITabBarItem("hello", UIImage.FromBundle("Images/home.png"),0)},
			};  
			this.window.RootViewController = tabBarController;
			
			this.window.MakeKeyAndVisible ();

			
			return true;
		}

		//http://stackoverflow.com/questions/5963234/how-to-register-defaults-in-monotouch
		public static void RegisterDefaultsFromSettingsBundle() 
		{
			string settingsBundle = NSBundle.MainBundle.PathForResource("Settings", @"bundle");
			if(settingsBundle == null) {
				System.Console.WriteLine(@"Could not find Settings.bundle");
				return;
			}
			NSString keyString = new NSString(@"Key");
			NSString defaultString = new NSString(@"DefaultValue");
			NSDictionary settings = NSDictionary.FromFile(Path.Combine(settingsBundle,@"Root.plist"));
			NSArray preferences = (NSArray) settings.ValueForKey(new NSString(@"PreferenceSpecifiers"));
			NSMutableDictionary defaultsToRegister = new NSMutableDictionary();
			for (uint i=0; i<preferences.Count; i++) {
				NSDictionary prefSpecification = new NSDictionary(preferences.ValueAt(i));
				NSString key = (NSString) prefSpecification.ValueForKey(keyString);
				if(key != null) {
					NSObject def = prefSpecification.ValueForKey(defaultString);
					if (def != null) {
						defaultsToRegister.SetValueForKey(def, key);
					}
				}
			}
			NSUserDefaults.StandardUserDefaults.RegisterDefaults(defaultsToRegister);
		}




	}
}
