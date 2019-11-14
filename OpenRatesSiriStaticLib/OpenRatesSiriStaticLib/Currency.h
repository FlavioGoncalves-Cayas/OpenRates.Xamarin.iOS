//
// Currency.h
//
// This file was automatically generated and should not be edited.
//

#if __has_include(<Intents/Intents.h>)

#import <Intents/Intents.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger, Currency) {
    CurrencyUnknown = 0,
    CurrencyEUR = 1,
    CurrencyUSD = 2,
    CurrencyGBP = 3,
    CurrencyCAD = 4,
    CurrencyAUD = 5,
    CurrencyCNY = 6,
    CurrencyJPY = 7,
    CurrencyINR = 8
} API_AVAILABLE(ios(12.0), watchos(5.0)) API_UNAVAILABLE(macos, tvos);

API_AVAILABLE(ios(13.0), watchos(6.0)) API_UNAVAILABLE(macos, tvos)
@interface CurrencyResolutionResult : INEnumResolutionResult

// This resolution result is for when the app extension wants to tell Siri to proceed, with a given Currency. The resolvedValue can be different than the original Currency. This allows app extensions to apply business logic constraints.
// Use +notRequired to continue with a 'nil' value.
+ (instancetype)successWithResolvedCurrency:(Currency)resolvedValue NS_SWIFT_NAME(success(with:));

// This resolution result is to ask Siri to confirm if this is the value with which the user wants to continue.
+ (instancetype)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm NS_SWIFT_NAME(confirmationRequired(with:));

+ (instancetype)successWithResolvedValue:(NSInteger)resolvedValue NS_UNAVAILABLE;
+ (instancetype)confirmationRequiredWithValueToConfirm:(NSInteger)valueToConfirm NS_UNAVAILABLE;

@end

NS_ASSUME_NONNULL_END

#endif
