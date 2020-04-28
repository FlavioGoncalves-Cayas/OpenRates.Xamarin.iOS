using System;
using Foundation;
using Intents;
using ObjCRuntime;

namespace OpenRates.iOS.Siri
{
	// @interface CurrencyResolutionResult : INEnumResolutionResult
	[Watch (6,0), NoTV, NoMac, iOS (13,0)]
	[BaseType (typeof(INEnumResolutionResult))]
	public interface CurrencyResolutionResult
	{
		// +(instancetype _Nonnull)successWithResolvedCurrency:(Currency)resolvedValue;
		[Static]
		[Export ("successWithResolvedCurrency:")]
		CurrencyResolutionResult SuccessWithResolvedCurrency (Currency resolvedValue);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm;
		[Static]
		[Export ("confirmationRequiredWithCurrencyToConfirm:")]
		CurrencyResolutionResult ConfirmationRequiredWithCurrencyToConfirm (Currency valueToConfirm);
	}

	// @interface ConvertAmountToCurrencyIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	public interface ConvertAmountToCurrencyIntent
	{
		// @property (readwrite, copy, nonatomic) INCurrencyAmount * _Nullable amount;
		[NullAllowed, Export ("amount", ArgumentSemantic.Copy)]
		INCurrencyAmount Amount { get; set; }

		// @property (assign, readwrite, nonatomic) Currency targetCurrency;
		[Export ("targetCurrency", ArgumentSemantic.Assign)]
		Currency TargetCurrency { get; set; }
	}

	// @protocol ConvertAmountToCurrencyIntentHandling <NSObject>
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public interface ConvertAmountToCurrencyIntentHandling
	{
		// @required -(void)handleConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ConvertAmountToCurrencyIntentResponse * _Nonnull))completion;
		[Abstract]
		[Export ("handleConvertAmountToCurrency:completion:")]
		void HandleConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion);

		// @required -(void)resolveAmountForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(ConvertAmountToCurrencyAmountResolutionResult * _Nonnull))completion __attribute__((availability(watchos, introduced=6.0))) __attribute__((availability(ios, introduced=13.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveAmountForConvertAmountToCurrency:withCompletion:")]
		void ResolveAmountForConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyAmountResolutionResult> completion);

		// @required -(void)resolveTargetCurrencyForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(ConvertAmountToCurrencyTargetCurrencyResolutionResult * _Nonnull))completion __attribute__((availability(watchos, introduced=6.0))) __attribute__((availability(ios, introduced=13.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveTargetCurrencyForConvertAmountToCurrency:withCompletion:")]
		void ResolveTargetCurrencyForConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyTargetCurrencyResolutionResult> completion);

		// @optional -(void)confirmConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ConvertAmountToCurrencyIntentResponse * _Nonnull))completion;
		[Export ("confirmConvertAmountToCurrency:completion:")]
		void ConfirmConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion);
	}

	// @interface ConvertAmountToCurrencyIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	public interface ConvertAmountToCurrencyIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(ConvertAmountToCurrencyIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (ConvertAmountToCurrencyIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithBaseAmount:(INCurrencyAmount * _Nonnull)baseAmount amount:(INCurrencyAmount * _Nonnull)amount;
		[Static]
		[Export ("successIntentResponseWithBaseAmount:amount:")]
		ConvertAmountToCurrencyIntentResponse SuccessIntentResponseWithBaseAmount (INCurrencyAmount baseAmount, INCurrencyAmount amount);

		// @property (readwrite, copy, nonatomic) INCurrencyAmount * _Nullable baseAmount;
		[NullAllowed, Export ("baseAmount", ArgumentSemantic.Copy)]
		INCurrencyAmount BaseAmount { get; set; }

		// @property (readwrite, copy, nonatomic) INCurrencyAmount * _Nullable amount;
		[NullAllowed, Export ("amount", ArgumentSemantic.Copy)]
		INCurrencyAmount Amount { get; set; }

		// @property (readonly, nonatomic) ConvertAmountToCurrencyIntentResponseCode code;
		[Export ("code")]
		ConvertAmountToCurrencyIntentResponseCode Code { get; }
	}

	// @interface ConvertAmountToCurrencyAmountResolutionResult : INCurrencyAmountResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(INCurrencyAmountResolutionResult))]
	public interface ConvertAmountToCurrencyAmountResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(ConvertAmountToCurrencyAmountUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		ConvertAmountToCurrencyAmountResolutionResult UnsupportedForReason (ConvertAmountToCurrencyAmountUnsupportedReason reason);
	}

	// @interface ConvertAmountToCurrencyTargetCurrencyResolutionResult : CurrencyResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(CurrencyResolutionResult))]
	public interface ConvertAmountToCurrencyTargetCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(ConvertAmountToCurrencyTargetCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult UnsupportedForReason (ConvertAmountToCurrencyTargetCurrencyUnsupportedReason reason);
	}

	// @interface GetConversionRateIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	public interface GetConversionRateIntent
	{
		// @property (assign, readwrite, nonatomic) Currency baseCurrency;
		[Export ("baseCurrency", ArgumentSemantic.Assign)]
		Currency BaseCurrency { get; set; }

		// @property (assign, readwrite, nonatomic) Currency targetCurrency;
		[Export ("targetCurrency", ArgumentSemantic.Assign)]
		Currency TargetCurrency { get; set; }
	}

	// @protocol GetConversionRateIntentHandling <NSObject>
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	public interface GetConversionRateIntentHandling
	{
		// @required -(void)handleGetConversionRate:(GetConversionRateIntent * _Nonnull)intent completion:(void (^ _Nonnull)(GetConversionRateIntentResponse * _Nonnull))completion;
		[Abstract]
		[Export ("handleGetConversionRate:completion:")]
		void HandleGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateIntentResponse> completion);

		// @required -(void)resolveBaseCurrencyForGetConversionRate:(GetConversionRateIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(GetConversionRateBaseCurrencyResolutionResult * _Nonnull))completion __attribute__((availability(watchos, introduced=6.0))) __attribute__((availability(ios, introduced=13.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveBaseCurrencyForGetConversionRate:withCompletion:")]
		void ResolveBaseCurrencyForGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateBaseCurrencyResolutionResult> completion);

		// @required -(void)resolveTargetCurrencyForGetConversionRate:(GetConversionRateIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(GetConversionRateTargetCurrencyResolutionResult * _Nonnull))completion __attribute__((availability(watchos, introduced=6.0))) __attribute__((availability(ios, introduced=13.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveTargetCurrencyForGetConversionRate:withCompletion:")]
		void ResolveTargetCurrencyForGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateTargetCurrencyResolutionResult> completion);

		// @optional -(void)confirmGetConversionRate:(GetConversionRateIntent * _Nonnull)intent completion:(void (^ _Nonnull)(GetConversionRateIntentResponse * _Nonnull))completion;
		[Export ("confirmGetConversionRate:completion:")]
		void ConfirmGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateIntentResponse> completion);
	}

	// @interface GetConversionRateIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	public interface GetConversionRateIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(GetConversionRateIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (GetConversionRateIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithBaseCurrency:(Currency)baseCurrency targetCurrency:(Currency)targetCurrency conversionRate:(NSNumber * _Nonnull)conversionRate;
		[Static]
		[Export ("successIntentResponseWithBaseCurrency:targetCurrency:conversionRate:")]
		GetConversionRateIntentResponse SuccessIntentResponseWithBaseCurrency (Currency baseCurrency, Currency targetCurrency, NSNumber conversionRate);

		// @property (assign, readwrite, nonatomic) Currency baseCurrency;
		[Export ("baseCurrency", ArgumentSemantic.Assign)]
		Currency BaseCurrency { get; set; }

		// @property (assign, readwrite, nonatomic) Currency targetCurrency;
		[Export ("targetCurrency", ArgumentSemantic.Assign)]
		Currency TargetCurrency { get; set; }

		// @property (readwrite, copy, nonatomic) NSNumber * _Nullable conversionRate;
		[NullAllowed, Export ("conversionRate", ArgumentSemantic.Copy)]
		NSNumber ConversionRate { get; set; }

		// @property (readonly, nonatomic) GetConversionRateIntentResponseCode code;
		[Export ("code")]
		GetConversionRateIntentResponseCode Code { get; }
	}

	// @interface GetConversionRateBaseCurrencyResolutionResult : CurrencyResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(CurrencyResolutionResult))]
	public interface GetConversionRateBaseCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(GetConversionRateBaseCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		GetConversionRateBaseCurrencyResolutionResult UnsupportedForReason (GetConversionRateBaseCurrencyUnsupportedReason reason);
	}

	// @interface GetConversionRateTargetCurrencyResolutionResult : CurrencyResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(CurrencyResolutionResult))]
	public interface GetConversionRateTargetCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(GetConversionRateTargetCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		GetConversionRateTargetCurrencyResolutionResult UnsupportedForReason (GetConversionRateTargetCurrencyUnsupportedReason reason);
	}
}
