using System;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;
using CoreGraphics;

namespace TabbarIconSizeFix.Platforms.iOS
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomShellTabBarAppearanceTracker();
        }
    }

    public class CustomShellTabBarAppearanceTracker : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void ResetAppearance(UITabBarController controller)
        {
            //throw new NotImplementedException();
        }

        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            //throw new NotImplementedException();
        }

        public void UpdateLayout(UITabBarController controller)
        {
            //throw new NotImplementedException();

            foreach(var tabbarItem in controller.TabBar.Items)
            {
                var prevImage = tabbarItem.Image;//.Copy() as UIImage;
                var size = new CGSize(24, 24);
                UIGraphics.BeginImageContextWithOptions(size, false, 0);
                prevImage.Draw(new CGRect(new CGPoint(0, 0), size));
                var resizedImage = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();
                tabbarItem.Image = resizedImage;
            }
        }
    }
}

