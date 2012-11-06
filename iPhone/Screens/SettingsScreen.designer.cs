// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace iPhone
{
	[Register ("SettingsScreen")]
	partial class SettingsScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblGoal { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnInfo != null) {
				btnInfo.Dispose ();
				btnInfo = null;
			}

			if (lblGoal != null) {
				lblGoal.Dispose ();
				lblGoal = null;
			}
		}
	}
}
