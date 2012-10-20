
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hello_MultiScreen_iPhone
{
	public partial class CameraScreen : UIViewController
	{
		public CameraScreen () : base ("CameraScreen", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Create an image picker controller.
			var imagePicker = new UIImagePickerController();
			
			// Handle an image selected.
			imagePicker.FinishedPickingImage += (sender, e) => {
				this.InvokeOnMainThread(() => {
					this.imgSnapshot.Image = e.Image;
				});
				
				DismissModalViewControllerAnimated(true);
			};
			
			// Handle media selected.
			imagePicker.FinishedPickingMedia += (sender, e) => {
				// After many crashes and debugging the image was found to be
				// part of a key/value collection with the key name of
				// "UIImagePickerControllerOriginalImage" (typically index 0).
				// Go figure.
				UIImage image = (UIImage)e.Info.ObjectForKey(
					new NSString("UIImagePickerControllerOriginalImage"));
				
				if (image != null)
				{
					this.InvokeOnMainThread(() => {
						this.imgSnapshot.Image = image;
					});
				}
				
				DismissModalViewControllerAnimated(true);
			};
			
			// Handle cancellation of picker.
			imagePicker.Canceled += (sender, e) => {
				DismissModalViewControllerAnimated(true);
			};
			
			// Handle customer asking for a photo.
			this.btnTakePicture.TouchUpInside += (sender, e) => {
				// Create an action sheet.
				var actionSheet = new UIActionSheet("Image Source") { "Photo Library", "Camera", "Cancel" };
				actionSheet.Style = UIActionSheetStyle.Automatic;
				actionSheet.ShowInView(View);
				
				// Action sheet navigation handling.
				actionSheet.Clicked += (actionSender, actionEvent) => {
					switch (actionEvent.ButtonIndex)
					{
					case 0:
						// Photo library.
						imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
						imagePicker.AllowsEditing = false;
						this.PresentModalViewController(imagePicker, true);
						break;
						
					case 1:
						// Camera.
						imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
						imagePicker.AllowsEditing = false;
						this.PresentModalViewController(imagePicker, true);
						break;
						
					default:
						// Cancel.
						break;
					}
				};
			};
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

