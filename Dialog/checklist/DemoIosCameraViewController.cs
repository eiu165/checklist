// Copyright (c) 2011 Bryan M. Allred
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to 
// deal in the Software without restriction, including without limitation the 
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
// sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DemoIosCamera
{
	/// <summary>
	/// Demo iOS camera view controller.
	/// </summary>
	public partial class DemoIosCameraViewController : UIViewController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DemoIosCamera.DemoIosCameraViewController"/> class.
		/// </summary>
		public DemoIosCameraViewController () 
			: base ("DemoIosCameraViewController", null)
		{
			this.Title = @"Demo - Camera";
		}
		
		/// <summary>
		/// Did the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		/// <summary>
		/// View did load.
		/// </summary>
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
		
		/// <summary>
		/// View did unload.
		/// </summary>
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		/// <summary>
		/// Should autorotate to interface orientation.
		/// </summary>
		/// <returns>
		/// The autorotate to interface orientation.
		/// </returns>
		/// <param name='toInterfaceOrientation'>
		/// If set to <c>true</c> to interface orientation.
		/// </param>
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}