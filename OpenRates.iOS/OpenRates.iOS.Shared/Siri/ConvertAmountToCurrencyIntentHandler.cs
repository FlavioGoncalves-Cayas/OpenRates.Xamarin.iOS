using System;
using System.Globalization;
using OpenRates.Api;
using OpenRates.iOS.Shared.Model;
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
            try
            {
                var knownBaseCurrency = Enum.Parse<KnownCurrency>(intent.BaseCurrency.ToString().ToUpper());
                var knownTargetCurrency = Enum.Parse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper());

                var response = new OpenRatesClient().GetLatestWithBaseAsync(knownBaseCurrency.ToString()).GetAwaiter().GetResult();

                var result = Math.Round(response.Rates[knownTargetCurrency.ToString()] * intent.Amount.DoubleValue, 2);

                var nsAmount = new Foundation.NSDecimalNumber(result.ToString(CultureInfo.InvariantCulture));
                var nCurrencyAmount = new Intents.INCurrencyAmount(nsAmount, knownTargetCurrency.ToString());

                completion(ConvertAmountToCurrencyIntentResponse.SuccessIntentResponseWithBaseAmount(intent.Amount, intent.BaseCurrency, nCurrencyAmount));
            }
            catch(Exception e)
            {
                completion(new ConvertAmountToCurrencyIntentResponse(ConvertAmountToCurrencyIntentResponseCode.Failure, null));
            }
        }

        public override void ResolveAmountForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyAmountResolutionResult> completion)
        {
            if(intent.Amount == null)
            {
                completion(ConvertAmountToCurrencyAmountResolutionResult.NeedsValue());

                return;
            }

            if(intent.Amount.DoubleValue < 0)
            {
                completion(ConvertAmountToCurrencyAmountResolutionResult.UnsupportedForReason(ConvertAmountToCurrencyAmountUnsupportedReason.NegativeNumbersNotSupported));

                return;
            }

            completion(ConvertAmountToCurrencyAmountResolutionResult.SuccessWithResolvedValue(intent.Amount.DoubleValue));
        }

        public override void ResolveBaseCurrencyForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyBaseCurrencyResolutionResult> completion)
        {
            if(intent.BaseCurrency == Currency.Unknown)
            {
                completion(ConvertAmountToCurrencyBaseCurrencyResolutionResult.NeedsValue());

                return;
            }

            if(!Enum.TryParse<KnownCurrency>(intent.BaseCurrency.ToString().ToUpper(), out _))
            {
                completion(ConvertAmountToCurrencyBaseCurrencyResolutionResult.Unsupported());

                return;
            }

            completion(ConvertAmountToCurrencyBaseCurrencyResolutionResult.SuccessWithResolvedCurrency(intent.BaseCurrency));
        }

        public override void ResolveTargetCurrencyForConvertAmountToCurrency(ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyTargetCurrencyResolutionResult> completion)
        {
            if (intent.TargetCurrency == Currency.Unknown)
            {
                completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.NeedsValue());

                return;
            }

            if (!Enum.TryParse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper(), out _))
            {
                completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.Unsupported());

                return;
            }

            completion(ConvertAmountToCurrencyTargetCurrencyResolutionResult.SuccessWithResolvedCurrency(intent.TargetCurrency));
        }
    }
}
