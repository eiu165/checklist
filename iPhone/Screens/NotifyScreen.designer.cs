// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Hello_MultiScreen_iPhone
{
	[Register ("NotifyScreen")]
	partial class NotifyScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNotify { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblOutput { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNotify != null) {
				btnNotify.Dispose ();
				btnNotify = null;
			}

			if (lblOutput != null) {
				lblOutput.Dispose ();
				lblOutput = null;
			}
		}
	}
}
