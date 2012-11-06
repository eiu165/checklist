// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace iPhone
{
	[Register ("FlipsideScreen")]
	partial class FlipsideScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITextField tbSet { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSet { get; set; }

		[Action ("done:")] 
		partial void done (MonoTouch.UIKit.UIBarButtonItem sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tbSet != null) {
				tbSet.Dispose ();
				tbSet = null;
			}

			if (btnSet != null) {
				btnSet.Dispose ();
				btnSet = null;
			}
		}
	}
}
