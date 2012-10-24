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
		UITabBarController tabbarController; 
		public UIView MainView;
//		UINavigationController [] navigationRoots;
//		DialogViewController main, mentions, messages , favorites,  searches; 

		// This method is invoked when the application has loaded its UI and it is ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			this.window = new UIWindow (UIScreen.MainScreen.Bounds);


			CreatePhoneGui();
			//---- instantiate a new navigation controller
			var rootNavigationController = new UINavigationController();
			//---- instantiate a new home screen
			HomeScreen homeScreen = new HomeScreen();
			//---- add the home screen to the navigation controller (it'll be the top most screen)
			rootNavigationController.PushViewController(homeScreen, false);
			
			//---- set the root view controller on the window. the nav controller will handle the rest
			this.window.RootViewController = rootNavigationController;
			
			this.window.MakeKeyAndVisible ();

			
			return true;
		}
		protected void CreatePhoneGui()
		{
			this.tabbarController = new UITabBarController();
			MainView = this.tabbarController.View;
			window.AddSubview(MainView);
			
//			navigationRoots = new UINavigationController [5] {
//				new UINavigationController (main) {
//					TabBarItem = new UITabBarItem (Locale.GetText ("Friends"), UIImage.FromBundle ("Images/home.png"), 0),
//				},
//				new UINavigationController (mentions) {
//					TabBarItem = new UITabBarItem (Locale.GetText ("Mentions"), UIImage.FromBundle ("Images/replies.png"), 1)
//				},
//				new UINavigationController (messages) {
//					TabBarItem = new UITabBarItem (Locale.GetText ("Messages"), UIImage.FromBundle ("Images/messages.png"), 2)
//				},
//				new UINavigationController (favorites) {
//					TabBarItem = new UITabBarItem (Locale.GetText ("Favorites"), UIImage.FromBundle ("Images/fav.png"), 3)
//				},
//				new UINavigationController (searches) {
//					TabBarItem = new UITabBarItem (Locale.GetText ("Search"), UIImage.FromBundle ("Images/lupa.png"), 4)
//				}
//			};
		}
	}
}
