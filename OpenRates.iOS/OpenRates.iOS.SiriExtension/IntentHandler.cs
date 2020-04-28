using System;
using OpenRates.iOS.Siri;

using Foundation;
using Intents;
using OpenRates.iOS.Shared.Siri;

namespace OpenRates.iOS.SiriExtension
{
    [Register("IntentHandler")]
    public class IntentHandler : INExtension
    {
        protected IntentHandler(IntPtr handle) : base(handle)
        {
        }

        public override NSObject GetHandler(INIntent intent)
        {
            if (intent is ConvertAmountToCurrencyIntent)
                return new ConvertAmountToCurrencyIntentHandler();

            if (intent is GetConversionRateIntent)
                return new GetConversionRateIntentHandler();
        
            return null;
        }
    }
}
