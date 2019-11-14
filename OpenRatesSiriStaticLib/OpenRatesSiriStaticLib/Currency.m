//
// Currency.m
//
// This file was automatically generated and should not be edited.
//

#import "Currency.h"

#if __has_include(<Intents/Intents.h>) && (!TARGET_OS_OSX || TARGET_OS_IOSMAC) && !TARGET_OS_TV

@implementation CurrencyResolutionResult

+ (instancetype)successWithResolvedCurrency:(Currency)resolvedValue {
    return [super successWithResolvedValue:resolvedValue];
}

+ (instancetype)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm {
    return [super confirmationRequiredWithValueToConfirm:valueToConfirm];
}

@end

#endif
