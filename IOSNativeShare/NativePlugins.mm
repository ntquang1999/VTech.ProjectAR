#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();

@interface NativePlugins : NSObject

@end

@implementation NativePlugins

+(void)shareOnFacebook:(NSString * )shareLink
{
    NSArray* dataToShare = @[shareLink];
    UIActivityViewController* activityViewController =[[UIActivityViewController alloc] initWithActivityItems:dataToShare applicationActivities:nil];
    activityViewController.excludedActivityTypes = @[UIActivityTypeAddToReadingList,
                                                     UIActivityTypeAssignToContact,
                                                     UIActivityTypePrint,
                                                     UIActivityTypeSaveToCameraRoll,
                                                     UIActivityTypeAirDrop,
                                                     UIActivityTypePostToTwitter];
    // [self presentViewController:activityViewController animated:YES completion:^{}];
    [UnityGetGLViewController() presentViewController:activityViewController animated:YES completion:nil];
}

@end

extern "C"
{
    void _ShareOnFacebook(const char *shareLink)
    {
        [NativePlugins shareOnFacebook:[NSString stringWithUTF8String:shareLink]];
    }
}
