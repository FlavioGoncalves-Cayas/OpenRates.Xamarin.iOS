//
//  main.m
//  OpenRatesSiriCodeGen
//
//  Created by Flavio Goncalves on 12.05.20.
//  Copyright © 2020 Cayas Software GmbH. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "AppDelegate.h"

int main(int argc, char * argv[]) {
    NSString * appDelegateClassName;
    @autoreleasepool {
        // Setup code that might create autoreleased objects goes here.
        appDelegateClassName = NSStringFromClass([AppDelegate class]);
    }
    return UIApplicationMain(argc, argv, nil, appDelegateClassName);
}
