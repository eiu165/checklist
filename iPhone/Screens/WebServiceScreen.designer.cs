// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Hello_MultiScreen_iPhone
{
	[Register ("WebServiceScreen")]
	partial class WebServiceScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnGet { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPost { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPut { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblGet { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPost { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPut { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGet != null) {
				btnGet.Dispose ();
				btnGet = null;
			}

			if (btnPost != null) {
				btnPost.Dispose ();
				btnPost = null;
			}

			if (btnPut != null) {
				btnPut.Dispose ();
				btnPut = null;
			}

			if (lblGet != null) {
				lblGet.Dispose ();
				lblGet = null;
			}

			if (lblPost != null) {
				lblPost.Dispose ();
				lblPost = null;
			}

			if (lblPut != null) {
				lblPut.Dispose ();
				lblPut = null;
			}
		}
	}
}
