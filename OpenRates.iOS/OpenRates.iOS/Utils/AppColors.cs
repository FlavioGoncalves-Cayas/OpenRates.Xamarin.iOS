using System;
using UIKit;

namespace OpenRates.iOS.Utils
{
    public static class AppColors
    {
        static bool SupportsSystemColors { get; } = Convert.ToInt16(UIDevice.CurrentDevice.SystemVersion.Split('.')[0]) >= 13;

        public static UIColor Blue => SupportsSystemColors ? UIColor.SystemBlueColor : UIColor.Blue;

        public static UIColor Red => SupportsSystemColors ? UIColor.SystemRedColor : UIColor.Red;

        public static UIColor Background => SupportsSystemColors ? UIColor.SystemBackgroundColor : UIColor.White;
    }
}