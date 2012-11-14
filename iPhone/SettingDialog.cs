using System;
using MonoTouch.Dialog;

namespace Hello_MultiScreen_iPhone
{
	public static class SettingDialog
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
					}},
				new Section (){ 
					new RootElement ("Brightness"){
						new Section (){
							new FloatElement (null, null, 0.5f),
							new BooleanElement ("Auto-brightness", false),
						}
					},
					new RootElement ("Wallpaper"){
						new Section (){
							new ImageElement (null),
							new ImageElement (null),
							new ImageElement (null)
						}
					}
				},
				new Section () {
					new EntryElement ("Login", "Your login name", "miguel"),
					new EntryElement ("Password", "Your password", "password", true),
					new DateElement ("Select Date", DateTime.Now),
					new TimeElement ("Select Time", DateTime.Now),
				}, 
				new Section () {
					new HtmlElement ("About", "http://monotouch.net"),
					new MultilineElement ("Remember to eat\nfruits and vegetables\nevery day")
				}
			};		
		}
	}
}

