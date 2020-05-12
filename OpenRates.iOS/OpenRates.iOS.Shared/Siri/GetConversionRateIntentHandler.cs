using System;
using ObjCRuntime;
using OpenRates.Api;
using OpenRates.iOS.Shared.Model;
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
            try
            {
                var knownBaseCurrency = Enum.Parse<KnownCurrency>(intent.BaseCurrency.ToString().ToUpper());
                var knownTargetCurrency = Enum.Parse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper());

                var response = new OpenRatesClient().GetLatestWithBaseAsync(knownBaseCurrency.ToString()).GetAwaiter().GetResult();

                var result = response.Rates[knownTargetCurrency.ToString()];
                
                completion(GetConversionRateIntentResponse.SuccessIntentResponseWithBaseCurrency(intent.BaseCurrency, intent.TargetCurrency, new Foundation.NSNumber(result)));
            }
            catch (Exception e)
            {
                completion(new GetConversionRateIntentResponse(GetConversionRateIntentResponseCode.Failure, null));
            }
        }

        public override void ResolveBaseCurrencyForGetConversionRate(GetConversionRateIntent intent, Action<GetConversionRateBaseCurrencyResolutionResult> completion)
        {
            if (intent.BaseCurrency == Currency.Unknown)
            {
                completion(GetConversionRateBaseCurrencyResolutionResult.NeedsValue());

                return;
            }

            if (!Enum.TryParse<KnownCurrency>(intent.BaseCurrency.ToString().ToUpper(), out _))
            {
                completion(GetConversionRateBaseCurrencyResolutionResult.Unsupported());

                return;
            }

            completion(GetConversionRateBaseCurrencyResolutionResult.SuccessWithResolvedCurrency(intent.BaseCurrency));
        }

        public override void ResolveTargetCurrencyForGetConversionRate(GetConversionRateIntent intent, Action<GetConversionRateTargetCurrencyResolutionResult> completion)
        {
            if (intent.TargetCurrency == Currency.Unknown)
            {
                completion(GetConversionRateTargetCurrencyResolutionResult.NeedsValue());

                return;
            }

            if (!Enum.TryParse<KnownCurrency>(intent.TargetCurrency.ToString().ToUpper(), out _))
            {
                completion(GetConversionRateTargetCurrencyResolutionResult.Unsupported());

                return;
            }

            completion(GetConversionRateTargetCurrencyResolutionResult.SuccessWithResolvedCurrency(intent.TargetCurrency));
        }
    }
}
