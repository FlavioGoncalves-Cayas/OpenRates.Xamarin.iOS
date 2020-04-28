//
// ConvertAmountToCurrencyIntent.h
//
// This file was automatically generated and should not be edited.
//

#if __has_include(<Intents/Intents.h>)

#import <Intents/Intents.h>
#import "Currency.h"

NS_ASSUME_NONNULL_BEGIN

API_AVAILABLE(ios(12.0), watchos(5.0)) API_UNAVAILABLE(macos, tvos)
@interface ConvertAmountToCurrencyIntent : INIntent

@property (readwrite, copy, nullable, nonatomic) INCurrencyAmount *amount;
@property (readwrite, assign, nonatomic) Currency targetCurrency;

@end

@class ConvertAmountToCurrencyIntentResponse;
@class ConvertAmountToCurrencyAmountResolutionResult;
@class ConvertAmountToCurrencyTargetCurrencyResolutionResult;

/*!
 @abstract Protocol to declare support for handling a ConvertAmountToCurrencyIntent. By implementing this protocol, a class can provide logic for resolving, confirming and handling the intent.
 @discussion The minimum requirement for an implementing class is that it should be able to handle the intent. The confirmation method is optional. The handling method is always called last, after confirming the intent.
 */
API_AVAILABLE(ios(12.0), watchos(5.0)) API_UNAVAILABLE(macos, tvos)
@protocol ConvertAmountToCurrencyIntentHandling <NSObject>

@required

/*!
 @abstract Handling method - Execute the task represented by the ConvertAmountToCurrencyIntent that's passed in
 @discussion Called to actually execute the intent. The app must return a response for this intent.

 @param  intent The input intent
 @param  completion The response handling block takes a ConvertAmountToCurrencyIntentResponse containing the details of the result of having executed the intent

 @see  ConvertAmountToCurrencyIntentResponse
 */
- (void)handleConvertAmountToCurrency:(ConvertAmountToCurrencyIntent *)intent completion:(void (^)(ConvertAmountToCurrencyIntentResponse *response))completion NS_SWIFT_NAME(handle(intent:completion:));

/*!
@abstract Resolution methods - Determine if this intent is ready for the next step (confirmation)
@discussion Called to make sure the app extension is capable of handling this intent in its current form. This method is for validating if the intent needs any further fleshing out.

@param  intent The input intent
@param  completion The response block contains an INIntentResolutionResult for the parameter being resolved

@see INIntentResolutionResult
*/
- (void)resolveAmountForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent *)intent withCompletion:(void (^)(ConvertAmountToCurrencyAmountResolutionResult *resolutionResult))completion NS_SWIFT_NAME(resolveAmount(for:with:)) API_AVAILABLE(ios(13.0), watchos(6.0));

- (void)resolveTargetCurrencyForConvertAmountToCurrency:(ConvertAmountToCurrencyIntent *)intent withCompletion:(void (^)(ConvertAmountToCurrencyTargetCurrencyResolutionResult *resolutionResult))completion NS_SWIFT_NAME(resolveTargetCurrency(for:with:)) API_AVAILABLE(ios(13.0), watchos(6.0));

@optional

/*!
 @abstract Confirmation method - Validate that this intent is ready for the next step (i.e. handling)
 @discussion Called prior to asking the app to handle the intent. The app should return a response object that contains additional information about the intent, which may be relevant for the system to show the user prior to handling. If unimplemented, the system will assume the intent is valid, and will assume there is no additional information relevant to this intent.

 @param  intent The input intent
 @param  completion The response block contains a ConvertAmountToCurrencyIntentResponse containing additional details about the intent that may be relevant for the system to show the user prior to handling.

 @see ConvertAmountToCurrencyIntentResponse
 */
- (void)confirmConvertAmountToCurrency:(ConvertAmountToCurrencyIntent *)intent completion:(void (^)(ConvertAmountToCurrencyIntentResponse *response))completion NS_SWIFT_NAME(confirm(intent:completion:));

@end

/*!
 @abstract Constants indicating the state of the response.
 */
typedef NS_ENUM(NSInteger, ConvertAmountToCurrencyIntentResponseCode) {
    ConvertAmountToCurrencyIntentResponseCodeUnspecified = 0,
    ConvertAmountToCurrencyIntentResponseCodeReady,
    ConvertAmountToCurrencyIntentResponseCodeContinueInApp,
    ConvertAmountToCurrencyIntentResponseCodeInProgress,
    ConvertAmountToCurrencyIntentResponseCodeSuccess,
    ConvertAmountToCurrencyIntentResponseCodeFailure,
    ConvertAmountToCurrencyIntentResponseCodeFailureRequiringAppLaunch
} API_AVAILABLE(ios(12.0), watchos(5.0)) API_UNAVAILABLE(macos, tvos);

API_AVAILABLE(ios(12.0), watchos(5.0)) API_UNAVAILABLE(macos, tvos)
@interface ConvertAmountToCurrencyIntentResponse : INIntentResponse

- (instancetype)init NS_UNAVAILABLE;

/*!
 @abstract Initializes the response object with the specified code and user activity object.
 @discussion The app extension has the option of capturing its private state as an NSUserActivity and returning it as the 'currentActivity'. If the app is launched, an NSUserActivity will be passed in with the private state. The NSUserActivity may also be used to query the app's UI extension (if provided) for a view controller representing the current intent handling state. In the case of app launch, the NSUserActivity will have its activityType set to the name of the intent. This intent object will also be available in the NSUserActivity.interaction property.

 @param  code The response code indicating your success or failure in confirming or handling the intent.
 @param  userActivity The user activity object to use when launching your app. Provide an object if you want to add information that is specific to your app. If you specify nil, the system automatically creates a user activity object for you, sets its type to the class name of the intent being handled, and fills it with an INInteraction object containing the intent and your response.
 */
- (instancetype)initWithCode:(ConvertAmountToCurrencyIntentResponseCode)code userActivity:(nullable NSUserActivity *)userActivity NS_DESIGNATED_INITIALIZER;

/*!
 @abstract Initializes and returns the response object with the success code.
 */
+ (instancetype)successIntentResponseWithBaseAmount:(INCurrencyAmount *)baseAmount amount:(INCurrencyAmount *)amount NS_SWIFT_NAME(success(baseAmount:amount:));

@property (readwrite, copy, nullable, nonatomic) INCurrencyAmount *baseAmount;
@property (readwrite, copy, nullable, nonatomic) INCurrencyAmount *amount;

/*!
 @abstract The response code indicating your success or failure in confirming or handling the intent.
 */
@property (readonly, NS_NONATOMIC_IOSONLY) ConvertAmountToCurrencyIntentResponseCode code;

@end

typedef NS_ENUM(NSInteger, ConvertAmountToCurrencyAmountUnsupportedReason) {
    ConvertAmountToCurrencyAmountUnsupportedReasonNegativeNumbersNotSupported = 1,
    ConvertAmountToCurrencyAmountUnsupportedReasonGreaterThanMaximumValue,
    ConvertAmountToCurrencyAmountUnsupportedReasonLessThanMinimumValue,
} API_AVAILABLE(ios(13.0), watchos(6.0));

API_AVAILABLE(ios(13.0), watchos(6.0))
@interface ConvertAmountToCurrencyAmountResolutionResult : INCurrencyAmountResolutionResult

+ (instancetype)unsupportedForReason:(ConvertAmountToCurrencyAmountUnsupportedReason)reason;

+ (instancetype)successWithResolvedCurrencyAmount:(INCurrencyAmount *)resolvedCurrencyAmount NS_SWIFT_NAME(success(with:));

+ (instancetype)disambiguationWithCurrencyAmountsToDisambiguate:(NSArray<INCurrencyAmount *> *)currencyAmountsToDisambiguate NS_SWIFT_NAME(disambiguation(with:));

+ (instancetype)confirmationRequiredWithCurrencyAmountToConfirm:(nullable INCurrencyAmount *)currencyAmountToConfirm NS_SWIFT_NAME(confirmationRequired(with:));

+ (instancetype)needsValue NS_SWIFT_NAME(needsValue());

+ (instancetype)notRequired NS_SWIFT_NAME(notRequired());

+ (instancetype)unsupported NS_SWIFT_NAME(unsupported());

@end

typedef NS_ENUM(NSInteger, ConvertAmountToCurrencyTargetCurrencyUnsupportedReason) {
    ConvertAmountToCurrencyTargetCurrencyUnsupportedReasonUnknownCurrency = 1,
} API_AVAILABLE(ios(13.0), watchos(6.0));

API_AVAILABLE(ios(13.0), watchos(6.0))
@interface ConvertAmountToCurrencyTargetCurrencyResolutionResult : CurrencyResolutionResult

+ (instancetype)unsupportedForReason:(ConvertAmountToCurrencyTargetCurrencyUnsupportedReason)reason;

+ (instancetype)successWithResolvedCurrency:(Currency)resolvedValue NS_SWIFT_NAME(success(with:));

+ (instancetype)confirmationRequiredWithCurrencyToConfirm:(Currency)valueToConfirm NS_SWIFT_NAME(confirmationRequired(with:));

+ (instancetype)needsValue NS_SWIFT_NAME(needsValue());

+ (instancetype)notRequired NS_SWIFT_NAME(notRequired());

+ (instancetype)unsupported NS_SWIFT_NAME(unsupported());

@end

NS_ASSUME_NONNULL_END

#endif
