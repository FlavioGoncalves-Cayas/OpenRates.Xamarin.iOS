using System;
using System.Globalization;
using OpenRates.Api;
using OpenRates.iOS.Shared.Model;
using OpenRates.iOS.Siri;

namespace OpenRates.iOS.Shared.Siri
{
    public class ConvertAmountToCurrencyIntentHandler : ConvertAmountToCurrencyIntentHandling
    {
        public override void HandleConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion)
        {
            var knownSourceCurrency = Enum.Parse<KnownCurrency>(intent.Amount.CurrencyCode.ToUpper());
            var knownTargetCurrency = Enum.Parse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper());

            var response = new OpenRatesClient().GetLatestWithBaseAsync(knownSourceCurrency.ToString()).GetAwaiter().GetResult();
            
            double result = Math.Round(response.Rates[knownTargetCurrency.ToString()] * intent.Amount.Amount.UInt32Value, 2);
            completion(ConvertAmountToCurrencyIntentResponse.SuccessIntentResponseWithBaseAmount(intent.Amount, new Intents.INCurrencyAmount(new Foundation.NSDecimalNumber(result.ToString(CultureInfo.InvariantCulture)), knownSourceCurrency.ToString())));
        }

        public override void ResolveAmountForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyAmountResolutionResult> completion)
        {
            if (intent.Amount == null)
            {
                completion(ConvertAmountToCurrencyAmountResolutionResult.NeedsValue());

                return;
            }

            if (string.IsNullOrEmpty(intent.Amount.CurrencyCode))
            {
                completion(ConvertAmountToCurrencyAmountResolutionResult.NeedsValue());

                return;
            }

            if(!Enum.TryParse<KnownCurrency>(intent.Amount.CurrencyCode.ToUpper(), out _))
            {
                completion(ConvertAmountToCurrencyAmountResolutionResult.Unsupported());

                return;
            }

            completion(ConvertAmountToCurrencyAmountResolutionResult.SuccessWithResolvedCurrencyAmount(intent.Amount));
        }

        public override void ResolveTargetCurrencyForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyTargetCurrencyResolutionResult> completion)
        {
            if(intent.TargetCurrency == Currency.Unknown)
            {
                completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.NeedsValue());

                return;
            }

            if(!Enum.TryParse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper(), out _))
            {
                completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.Unsupported());

                return;
            }

            completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.SuccessWithResolvedCurrency(intent.TargetCurrency));
        }
    }
}
