using System;
using ObjCRuntime;
using OpenRates.iOS.Siri;

namespace OpenRates.iOS.Shared.Siri
{
    public class ConvertAmountToCurrencyIntentHandler : ConvertAmountToCurrencyIntentHandling
    {
        public ConvertAmountToCurrencyIntentHandler()
        {
        }

        public override void HandleConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion)
        {
            throw new NotImplementedException();
        }

        public override void ResolveAmountForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyAmountResolutionResult> completion)
        {
            throw new NotImplementedException();
        }

        public override void ResolveBaseCurrencyForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyBaseCurrencyResolutionResult> completion)
        {
            throw new NotImplementedException();
        }

        public override void ResolveTargetCurrencyForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyTargetCurrencyResolutionResult> completion)
        {
            throw new NotImplementedException();
        }
    }
}
