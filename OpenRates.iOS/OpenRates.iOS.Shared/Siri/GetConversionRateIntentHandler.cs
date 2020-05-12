using System;
using ObjCRuntime;
using OpenRates.iOS.Siri;

namespace OpenRates.iOS.Shared.Siri
{
    public class GetConversionRateIntentHandler : GetConversionRateIntentHandling
    {
        public GetConversionRateIntentHandler()
        {
        }

        public override void HandleGetConversionRate(GetConversionRateIntent intent, Action<GetConversionRateIntentResponse> completion)
        {
            throw new NotImplementedException();
        }

        public override void ResolveBaseCurrencyForGetConversionRate(GetConversionRateIntent intent, Action<GetConversionRateBaseCurrencyResolutionResult> completion)
        {
            throw new NotImplementedException();
        }

        public override void ResolveTargetCurrencyForGetConversionRate(GetConversionRateIntent intent, Action<GetConversionRateTargetCurrencyResolutionResult> completion)
        {
            throw new NotImplementedException();
        }
    }
}
