using System;
using Foundation;
using Intents;
using ObjCRuntime;

namespace OpenRates.iOS.Siri
{
	// @interface CurrencyResolutionResult : INEnumResolutionResult
	[Watch (6,0), NoTV, NoMac, iOS (13,0)]
	[BaseType (typeof(INEnumResolutionResult))]
	interface CurrencyResolutionResult
	{
		// +(instancetype _Nonnull)successWithResolvedCurrency:(Currency)resolvedValue __attribute__((swift_name("success(with:)")));
		[Static]
		[Export ("successWithResolvedCurrency:")]
		CurrencyResolutionResult SuccessWithResolvedCurrency (Currency resolvedValue);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm __attribute__((swift_name("confirmationRequired(with:)")));
		[Static]
		[Export ("confirmationRequiredWithCurrencyToConfirm:")]
		CurrencyResolutionResult ConfirmationRequiredWithCurrencyToConfirm (Currency valueToConfirm);
	}

	// @interface ConvertAmountToCurrencyIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface ConvertAmountToCurrencyIntent
	{
		// @property (readwrite, copy, nonatomic) INCurrencyAmount * _Nullable amount;
		[NullAllowed, Export ("amount", ArgumentSemantic.Copy)]
		INCurrencyAmount Amount { get; set; }

		// @property (assign, readwrite, nonatomic) Currency targetCurrency;
		[Export ("targetCurrency", ArgumentSemantic.Assign)]
		Currency TargetCurrency { get; set; }
	}

	// @protocol ConvertAmountToCurrencyIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ConvertAmountToCurrencyIntentHandling
	{
		// @required -(void)handleConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ConvertAmountToCurrencyIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleConvertAmountToCurrency:completion:")]
		void HandleConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion);

		// @required -(void)resolveAmountForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(ConvertAmountToCurrencyAmountResolutionResult * _Nonnull))completion __attribute__((swift_name("resolveAmount(for:with:)"))) __attribute__((availability(ios, introduced=13.0))) __attribute__((availability(watchos, introduced=6.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveAmountForConvertAmountToCurrency:withCompletion:")]
		void ResolveAmountForConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyAmountResolutionResult> completion);

		// @required -(void)resolveTargetCurrencyForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(ConvertAmountToCurrencyTargetCurrencyResolutionResult * _Nonnull))completion __attribute__((swift_name("resolveTargetCurrency(for:with:)"))) __attribute__((availability(ios, introduced=13.0))) __attribute__((availability(watchos, introduced=6.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveTargetCurrencyForConvertAmountToCurrency:withCompletion:")]
		void ResolveTargetCurrencyForConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyTargetCurrencyResolutionResult> completion);

		// @optional -(void)confirmConvertAmountToCurrency:(ConvertAmountToCurrencyIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ConvertAmountToCurrencyIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmConvertAmountToCurrency:completion:")]
		void ConfirmConvertAmountToCurrency (ConvertAmountToCurrencyIntent intent, Action<ConvertAmountToCurrencyIntentResponse> completion);
	}

	// @interface ConvertAmountToCurrencyIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface ConvertAmountToCurrencyIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(ConvertAmountToCurrencyIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (ConvertAmountToCurrencyIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithBaseAmount:(INCurrencyAmount * _Nonnull)baseAmount amount:(INCurrencyAmount * _Nonnull)amount __attribute__((swift_name("success(baseAmount:amount:)")));
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
	interface ConvertAmountToCurrencyAmountResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(ConvertAmountToCurrencyAmountUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		ConvertAmountToCurrencyAmountResolutionResult UnsupportedForReason (ConvertAmountToCurrencyAmountUnsupportedReason reason);

		// +(instancetype _Nonnull)successWithResolvedCurrencyAmount:(INCurrencyAmount * _Nonnull)resolvedCurrencyAmount __attribute__((swift_name("success(with:)")));
		[Static]
		[Export ("successWithResolvedCurrencyAmount:")]
		ConvertAmountToCurrencyAmountResolutionResult SuccessWithResolvedCurrencyAmount (INCurrencyAmount resolvedCurrencyAmount);

		// +(instancetype _Nonnull)disambiguationWithCurrencyAmountsToDisambiguate:(NSArray<INCurrencyAmount *> * _Nonnull)currencyAmountsToDisambiguate __attribute__((swift_name("disambiguation(with:)")));
		[Static]
		[Export ("disambiguationWithCurrencyAmountsToDisambiguate:")]
		ConvertAmountToCurrencyAmountResolutionResult DisambiguationWithCurrencyAmountsToDisambiguate (INCurrencyAmount[] currencyAmountsToDisambiguate);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyAmountToConfirm:(INCurrencyAmount * _Nullable)currencyAmountToConfirm __attribute__((swift_name("confirmationRequired(with:)")));
		[Static]
		[Export ("confirmationRequiredWithCurrencyAmountToConfirm:")]
		ConvertAmountToCurrencyAmountResolutionResult ConfirmationRequiredWithCurrencyAmountToConfirm ([NullAllowed] INCurrencyAmount currencyAmountToConfirm);

		// +(instancetype _Nonnull)needsValue __attribute__((swift_name("needsValue()")));
		[Static]
		[Export ("needsValue")]
		ConvertAmountToCurrencyAmountResolutionResult NeedsValue ();

		// +(instancetype _Nonnull)notRequired __attribute__((swift_name("notRequired()")));
		[Static]
		[Export ("notRequired")]
		ConvertAmountToCurrencyAmountResolutionResult NotRequired ();

		// +(instancetype _Nonnull)unsupported __attribute__((swift_name("unsupported()")));
		[Static]
		[Export ("unsupported")]
		ConvertAmountToCurrencyAmountResolutionResult Unsupported ();
	}

	// @interface ConvertAmountToCurrencyTargetCurrencyResolutionResult : CurrencyResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(CurrencyResolutionResult))]
	interface ConvertAmountToCurrencyTargetCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(ConvertAmountToCurrencyTargetCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult UnsupportedForReason (ConvertAmountToCurrencyTargetCurrencyUnsupportedReason reason);

		// +(instancetype _Nonnull)successWithResolvedCurrency:(Currency)resolvedValue __attribute__((swift_name("success(with:)")));
		[Static]
		[Export ("successWithResolvedCurrency:")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult SuccessWithResolvedCurrency (Currency resolvedValue);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm __attribute__((swift_name("confirmationRequired(with:)")));
		[Static]
		[Export ("confirmationRequiredWithCurrencyToConfirm:")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult ConfirmationRequiredWithCurrencyToConfirm (Currency valueToConfirm);

		// +(instancetype _Nonnull)needsValue __attribute__((swift_name("needsValue()")));
		[Static]
		[Export ("needsValue")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult NeedsValue ();

		// +(instancetype _Nonnull)notRequired __attribute__((swift_name("notRequired()")));
		[Static]
		[Export ("notRequired")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult NotRequired ();

		// +(instancetype _Nonnull)unsupported __attribute__((swift_name("unsupported()")));
		[Static]
		[Export ("unsupported")]
		ConvertAmountToCurrencyTargetCurrencyResolutionResult Unsupported ();
	}

	// @interface GetConversionRateIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface GetConversionRateIntent
	{
		// @property (assign, readwrite, nonatomic) Currency baseCurrency;
		[Export ("baseCurrency", ArgumentSemantic.Assign)]
		Currency BaseCurrency { get; set; }

		// @property (assign, readwrite, nonatomic) Currency targetCurrency;
		[Export ("targetCurrency", ArgumentSemantic.Assign)]
		Currency TargetCurrency { get; set; }
	}

	// @protocol GetConversionRateIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GetConversionRateIntentHandling
	{
		// @required -(void)handleGetConversionRate:(GetConversionRateIntent * _Nonnull)intent completion:(void (^ _Nonnull)(GetConversionRateIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleGetConversionRate:completion:")]
		void HandleGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateIntentResponse> completion);

		// @required -(void)resolveBaseCurrencyForGetConversionRate:(GetConversionRateIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(GetConversionRateBaseCurrencyResolutionResult * _Nonnull))completion __attribute__((swift_name("resolveBaseCurrency(for:with:)"))) __attribute__((availability(ios, introduced=13.0))) __attribute__((availability(watchos, introduced=6.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveBaseCurrencyForGetConversionRate:withCompletion:")]
		void ResolveBaseCurrencyForGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateBaseCurrencyResolutionResult> completion);

		// @required -(void)resolveTargetCurrencyForGetConversionRate:(GetConversionRateIntent * _Nonnull)intent withCompletion:(void (^ _Nonnull)(GetConversionRateTargetCurrencyResolutionResult * _Nonnull))completion __attribute__((swift_name("resolveTargetCurrency(for:with:)"))) __attribute__((availability(ios, introduced=13.0))) __attribute__((availability(watchos, introduced=6.0)));
		[Watch (6,0), iOS (13,0)]
		[Abstract]
		[Export ("resolveTargetCurrencyForGetConversionRate:withCompletion:")]
		void ResolveTargetCurrencyForGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateTargetCurrencyResolutionResult> completion);

		// @optional -(void)confirmGetConversionRate:(GetConversionRateIntent * _Nonnull)intent completion:(void (^ _Nonnull)(GetConversionRateIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmGetConversionRate:completion:")]
		void ConfirmGetConversionRate (GetConversionRateIntent intent, Action<GetConversionRateIntentResponse> completion);
	}

	// @interface GetConversionRateIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface GetConversionRateIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(GetConversionRateIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (GetConversionRateIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithBaseCurrency:(Currency)baseCurrency targetCurrency:(Currency)targetCurrency conversionRate:(NSNumber * _Nonnull)conversionRate __attribute__((swift_name("success(baseCurrency:targetCurrency:conversionRate:)")));
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
	interface GetConversionRateBaseCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(GetConversionRateBaseCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		GetConversionRateBaseCurrencyResolutionResult UnsupportedForReason (GetConversionRateBaseCurrencyUnsupportedReason reason);

		// +(instancetype _Nonnull)successWithResolvedCurrency:(Currency)resolvedValue __attribute__((swift_name("success(with:)")));
		[Static]
		[Export ("successWithResolvedCurrency:")]
		GetConversionRateBaseCurrencyResolutionResult SuccessWithResolvedCurrency (Currency resolvedValue);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm __attribute__((swift_name("confirmationRequired(with:)")));
		[Static]
		[Export ("confirmationRequiredWithCurrencyToConfirm:")]
		GetConversionRateBaseCurrencyResolutionResult ConfirmationRequiredWithCurrencyToConfirm (Currency valueToConfirm);

		// +(instancetype _Nonnull)needsValue __attribute__((swift_name("needsValue()")));
		[Static]
		[Export ("needsValue")]
		GetConversionRateBaseCurrencyResolutionResult NeedsValue ();

		// +(instancetype _Nonnull)notRequired __attribute__((swift_name("notRequired()")));
		[Static]
		[Export ("notRequired")]
		GetConversionRateBaseCurrencyResolutionResult NotRequired ();

		// +(instancetype _Nonnull)unsupported __attribute__((swift_name("unsupported()")));
		[Static]
		[Export ("unsupported")]
		GetConversionRateBaseCurrencyResolutionResult Unsupported ();
	}

	// @interface GetConversionRateTargetCurrencyResolutionResult : CurrencyResolutionResult
	[Watch (6,0), iOS (13,0)]
	[BaseType (typeof(CurrencyResolutionResult))]
	interface GetConversionRateTargetCurrencyResolutionResult
	{
		// +(instancetype _Nonnull)unsupportedForReason:(GetConversionRateTargetCurrencyUnsupportedReason)reason;
		[Static]
		[Export ("unsupportedForReason:")]
		GetConversionRateTargetCurrencyResolutionResult UnsupportedForReason (GetConversionRateTargetCurrencyUnsupportedReason reason);

		// +(instancetype _Nonnull)successWithResolvedCurrency:(Currency)resolvedValue __attribute__((swift_name("success(with:)")));
		[Static]
		[Export ("successWithResolvedCurrency:")]
		GetConversionRateTargetCurrencyResolutionResult SuccessWithResolvedCurrency (Currency resolvedValue);

		// +(instancetype _Nonnull)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm __attribute__((swift_name("confirmationRequired(with:)")));
		[Static]
		[Export ("confirmationRequiredWithCurrencyToConfirm:")]
		GetConversionRateTargetCurrencyResolutionResult ConfirmationRequiredWithCurrencyToConfirm (Currency valueToConfirm);

		// +(instancetype _Nonnull)needsValue __attribute__((swift_name("needsValue()")));
		[Static]
		[Export ("needsValue")]
		GetConversionRateTargetCurrencyResolutionResult NeedsValue ();

		// +(instancetype _Nonnull)notRequired __attribute__((swift_name("notRequired()")));
		[Static]
		[Export ("notRequired")]
		GetConversionRateTargetCurrencyResolutionResult NotRequired ();

		// +(instancetype _Nonnull)unsupported __attribute__((swift_name("unsupported()")));
		[Static]
		[Export ("unsupported")]
		GetConversionRateTargetCurrencyResolutionResult Unsupported ();
	}
}
