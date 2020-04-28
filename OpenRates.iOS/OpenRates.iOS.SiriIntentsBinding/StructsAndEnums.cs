using System;
using ObjCRuntime;

namespace OpenRates.iOS.Siri
{
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum Currency : long
	{
		Unknown = 0,
		Eur = 1,
		Usd = 2,
		Gbp = 3,
		Cad = 4,
		Aud = 5,
		Cny = 6,
		Jpy = 7,
		Inr = 8
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum ConvertAmountToCurrencyIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum ConvertAmountToCurrencyAmountUnsupportedReason : long
	{
		NegativeNumbersNotSupported = 1,
		GreaterThanMaximumValue,
		LessThanMinimumValue
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum ConvertAmountToCurrencyTargetCurrencyUnsupportedReason : long
	{
		ConvertAmountToCurrencyTargetCurrencyUnsupportedReasonUnknownCurrency = 1
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum GetConversionRateIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum GetConversionRateBaseCurrencyUnsupportedReason : long
	{
		GetConversionRateBaseCurrencyUnsupportedReasonUnknownCurrency = 1
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum GetConversionRateTargetCurrencyUnsupportedReason : long
	{
		GetConversionRateTargetCurrencyUnsupportedReasonUnknowCurrency = 1
	}
}
