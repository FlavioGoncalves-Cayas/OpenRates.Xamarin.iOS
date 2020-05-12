using System;
using System.Collections.Generic;

using Foundation;
using Intents;
using OpenRates.iOS.Shared.Siri;
using OpenRates.iOS.Siri;

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
            if (intent is GetConversionRateIntent)
                return new GetConversionRateIntentHandler();

            if (intent is ConvertAmountToCurrencyIntent)
                return new ConvertAmountToCurrencyIntentHandler();

            throw new NotSupportedException();
        }
    }
}
