// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Hello_MultiScreen_iPhone
{
	[Register ("HomeScreen")]
	partial class HomeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnHelloWorld { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnHelloUniverse { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnCamera2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnNotify { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnHelloWorld != null) {
				btnHelloWorld.Dispose ();
				btnHelloWorld = null;
			}

			if (btnHelloUniverse != null) {
				btnHelloUniverse.Dispose ();
				btnHelloUniverse = null;
			}

			if (btnCamera2 != null) {
				btnCamera2.Dispose ();
				btnCamera2 = null;
			}

			if (btnNotify != null) {
				btnNotify.Dispose ();
				btnNotify = null;
			}
		}
	}
}
