//
// GetConversionRateIntent.m
//
// This file was automatically generated and should not be edited.
//

#import "GetConversionRateIntent.h"

#if __has_include(<Intents/Intents.h>) && (!TARGET_OS_OSX || TARGET_OS_IOSMAC) && !TARGET_OS_TV

@implementation GetConversionRateIntent

@dynamic baseCurrency, targetCurrency;

@end

@interface GetConversionRateIntentResponse ()

@property (readwrite, NS_NONATOMIC_IOSONLY) GetConversionRateIntentResponseCode code;

@end

@implementation GetConversionRateIntentResponse

@synthesize code = _code;

@dynamic baseCurrency, targetCurrency, conversionRate;

- (instancetype)initWithCode:(GetConversionRateIntentResponseCode)code userActivity:(nullable NSUserActivity *)userActivity {
    self = [super init];
    if (self) {
        _code = code;
        self.userActivity = userActivity;
    }
    return self;
}

+ (instancetype)successIntentResponseWithBaseCurrency:(Currency)baseCurrency targetCurrency:(Currency)targetCurrency conversionRate:(NSNumber *)conversionRate {
    GetConversionRateIntentResponse *intentResponse = [[GetConversionRateIntentResponse alloc] initWithCode:GetConversionRateIntentResponseCodeSuccess userActivity:nil];
    intentResponse.baseCurrency = baseCurrency;
    intentResponse.targetCurrency = targetCurrency;
    intentResponse.conversionRate = conversionRate;
    return intentResponse;
}

@end

@implementation GetConversionRateBaseCurrencyResolutionResult

+ (instancetype)unsupportedForReason:(GetConversionRateBaseCurrencyUnsupportedReason)reason {
    return [super unsupportedWithReason:reason];
}

@end

@implementation GetConversionRateTargetCurrencyResolutionResult

+ (instancetype)unsupportedForReason:(GetConversionRateTargetCurrencyUnsupportedReason)reason {
    return [super unsupportedWithReason:reason];
}

@end

#endif
