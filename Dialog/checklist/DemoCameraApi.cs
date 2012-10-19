//
// Sample showing the core Element-based API to create a dialog
//
using System;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace Sample
{
	public partial class AppDelegate 
	{		
		public void DemoCameraApi ()
		{
			var root = CreateRootEle ();
				
			var dv = new DialogViewController (root, true);
			navigation.PushViewController (dv, true);				
		}

		RootElement CreateRootEle ()
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
				}
			};		
		}

	}
}
