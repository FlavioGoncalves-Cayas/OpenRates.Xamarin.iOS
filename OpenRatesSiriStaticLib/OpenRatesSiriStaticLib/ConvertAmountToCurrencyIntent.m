//
// ConvertAmountToCurrencyIntent.m
//
// This file was automatically generated and should not be edited.
//

#import "ConvertAmountToCurrencyIntent.h"

#if __has_include(<Intents/Intents.h>) && (!TARGET_OS_OSX || TARGET_OS_IOSMAC) && !TARGET_OS_TV

@implementation ConvertAmountToCurrencyIntent

@dynamic baseCurrency, targetCurrency, amount;

@end

@interface ConvertAmountToCurrencyIntentResponse ()

@property (readwrite, NS_NONATOMIC_IOSONLY) ConvertAmountToCurrencyIntentResponseCode code;

@end

@implementation ConvertAmountToCurrencyIntentResponse

@synthesize code = _code;

@dynamic baseCurrency, baseAmount, amount;

- (instancetype)initWithCode:(ConvertAmountToCurrencyIntentResponseCode)code userActivity:(nullable NSUserActivity *)userActivity {
    self = [super init];
    if (self) {
        _code = code;
        self.userActivity = userActivity;
    }
    return self;
}

+ (instancetype)successIntentResponseWithBaseAmount:(NSNumber *)baseAmount baseCurrency:(Currency)baseCurrency amount:(INCurrencyAmount *)amount {
    ConvertAmountToCurrencyIntentResponse *intentResponse = [[ConvertAmountToCurrencyIntentResponse alloc] initWithCode:ConvertAmountToCurrencyIntentResponseCodeSuccess userActivity:nil];
    intentResponse.baseAmount = baseAmount;
    intentResponse.baseCurrency = baseCurrency;
    intentResponse.amount = amount;
    return intentResponse;
}

@end

@implementation ConvertAmountToCurrencyBaseCurrencyResolutionResult

+ (instancetype)unsupportedForReason:(ConvertAmountToCurrencyBaseCurrencyUnsupportedReason)reason {
    return [super unsupportedWithReason:reason];
}

+ (instancetype)successWithResolvedCurrency:(Currency)resolvedValue {
    return [super successWithResolvedCurrency:resolvedValue];
}

+ (instancetype)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm {
    return [super confirmationRequiredWithCurrencyToConfirm:valueToConfirm];
}

+ (instancetype)needsValue {
    return [super needsValue];
}

+ (instancetype)notRequired {
    return [super notRequired];
}

+ (instancetype)unsupported {
    return [super unsupported];
}

@end

@implementation ConvertAmountToCurrencyTargetCurrencyResolutionResult

+ (instancetype)unsupportedForReason:(ConvertAmountToCurrencyTargetCurrencyUnsupportedReason)reason {
    return [super unsupportedWithReason:reason];
}

+ (instancetype)successWithResolvedCurrency:(Currency)resolvedValue {
    return [super successWithResolvedCurrency:resolvedValue];
}

+ (instancetype)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm {
    return [super confirmationRequiredWithCurrencyToConfirm:valueToConfirm];
}

+ (instancetype)needsValue {
    return [super needsValue];
}

+ (instancetype)notRequired {
    return [super notRequired];
}

+ (instancetype)unsupported {
    return [super unsupported];
}

@end

@implementation ConvertAmountToCurrencyAmountResolutionResult

+ (instancetype)unsupportedForReason:(ConvertAmountToCurrencyAmountUnsupportedReason)reason {
    return [super unsupportedWithReason:reason];
}

+ (instancetype)successWithResolvedValue:(double)resolvedValue {
    return [super successWithResolvedValue:resolvedValue];
}

+ (instancetype)needsValue {
    return [super needsValue];
}

+ (instancetype)notRequired {
    return [super notRequired];
}

+ (instancetype)unsupported {
    return [super unsupported];
}

@end

#endif
