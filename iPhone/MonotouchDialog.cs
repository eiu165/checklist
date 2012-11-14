using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.Foundation;



namespace iPhone
{ 
	public static  class MonotouchDialog
	{ 


		public static RootElement CreateRoot ()
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
	}
}

