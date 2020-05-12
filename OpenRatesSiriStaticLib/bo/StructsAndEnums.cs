using System;
using ObjCRuntime;

namespace OpenRates.iOS.Siri
{
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum Currency : nint
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
	public enum ConvertAmountToCurrencyIntentResponseCode : nint
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
	public enum ConvertAmountToCurrencyBaseCurrencyUnsupportedReason : nint
	{
		ConvertAmountToCurrencyBaseCurrencyUnsupportedReasonUndefinedBaseCurrency = 1
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum ConvertAmountToCurrencyTargetCurrencyUnsupportedReason : nint
	{
		ConvertAmountToCurrencyTargetCurrencyUnsupportedReasonUndefinedTargetCurrency = 1
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum ConvertAmountToCurrencyAmountUnsupportedReason : nint
	{
		NegativeNumbersNotSupported = 1,
		GreaterThanMaximumValue,
		LessThanMinimumValue
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum GetConversionRateIntentResponseCode : nint
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
	public enum GetConversionRateBaseCurrencyUnsupportedReason : nint
	{
		GetConversionRateBaseCurrencyUnsupportedReasonUndefinedBaseCurrency = 1
	}

	[Watch (6,0), iOS (13,0)]
	[Native]
	public enum GetConversionRateTargetCurrencyUnsupportedReason : nint
	{
		GetConversionRateTargetCurrencyUnsupportedReasonUndefinedTargetCurrency = 1
	}
}
