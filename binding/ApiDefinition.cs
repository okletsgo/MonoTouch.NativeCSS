//
// ApiDefinition.cs: Bindings to the native.css iOS library.
//
//	Authors:
//		J.P. Park (mailing@mono.developer.kr)
//
//
using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


namespace MonoTouch.NativeCSS
{
	public delegate void FetchMissingCSSAndAssetsFromURLHandler(bool success, bool cssIsDifferent, string cssContent, NSObject[] unavailableAssets);
	public delegate void UpdateCSSAndAssetsFromURLHandler(bool success, bool cssIsDifferent, string cssContent, NSObject[] unavailableAssets);
	/// <summary>
	/// Update CSS from Url.
	/// </summary>
	/// <param name="success"></param>
	/// <param name="cssIsDifferent"></param>
	/// <param name="cssContent"></param>
	public delegate void UpdateCSSFromURLHandler(bool success, bool cssIsDifferent, string cssContent);

	/// <summary>
	/// Issue - Cannot register two managed types ('MonoTouch.NativeCSS.UIApplication' and 'MonoTouch.UIKit.UIApplication') with the same native name
	/// </summary>
	[BaseType(typeof(NSObject))] //[Category, BaseType (typeof (UIApplication))]
	public partial interface UIApplication
	{
		// +(void) styleWithCSSString:(NSString*) cssContent;
		[Static, Export("styleWithCSSString:")]
		void StyleWithCSSString(string cssContent);

		//+(void) styleWithLESSString:(NSString*) cssContent;
		[Static, Export("styleWithLESSString:")]
		void StyleWithLESSString(string cssContent);

		//+(void) styleWithLESSString:(NSString*) cssContent debugLogging:(BOOL) debugLogging;
		[Static, Export("styleWithLESSString:")]
		void StyleWithLESSString(string cssContent, bool debugLogging);

		// +(void) styleWithCSSString:(NSString*) cssContent debugLogging:(BOOL) debugLogging;
		[Static, Export("styleWithCSSString:debugLogging:")]
		void StyleWithCSSString(string cssContent, bool debugLogging);

		// +(void) fetchMissingCSSAndAssetsFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent, NSArray *unavailableAssets)) completionBlock;
		[Static, Export("fetchMissingCSSAndAssetsFromURL:completionBlock:")]
		void FetchMissingCSSAndAssetsFromURL(NSUrl url, FetchMissingCSSAndAssetsFromURLHandler completionBlock);

		// +(void) updateCSSAndAssetsFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent, NSArray *unavailableAssets)) completionBlock;
		[Static, Export("updateCSSAndAssetsFromURL:completionBlock:")]
		void UpdateCSSAndAssetsFromURL(NSUrl url, UpdateCSSAndAssetsFromURLHandler completionBlock);

		// +(void) updateCSSFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent)) completionBlock;
		[Static, Export("updateCSSFromURL:completionBlock:")]
		void UpdateCSSFromURL(NSUrl url, UpdateCSSFromURLHandler completionBlock);

		// +(void) updateCSSFromURL:(NSURL*) url repeatInterval: (double) repeatInterval completionBlock:(void (^)(BOOL success,  BOOL cssIsDifferent, NSString* cssContent)) completionBlock;
		[Static, Export("updateCSSFromURL:repeatInterval:completionBlock:")]
		void UpdateCSSFromURL(NSUrl url, double repeatInterval, UpdateCSSFromURLHandler completionBlock);

		// +(BOOL) isAssetCachedForURL:(NSURL*) url;
		[Static, Export("isAssetCachedForURL:")]
		bool IsAssetCachedForURL(NSUrl url);

		// +(UIImage*) cachedAssetForURL:(NSURL*) url;
		[Static, Export("cachedAssetForURL:")]
		UIImage CachedAssetForURL(NSUrl url);

		// +(void) deleteCachedAssetForURL:(NSURL*) url;
		[Static, Export("deleteCachedAssetForURL:")]
		void DeleteCachedAssetForURL(NSUrl url);

		// +(void) deleteCachedAssetsFromURL:(NSURL*) url;
		[Static, Export("deleteCachedAssetsFromURL:")]
		void DeleteCachedAssetsFromURL(NSUrl url);

		// +(NSArray*) assetURLsFromURL:(NSURL*) url;
		[Static, Export("assetURLsFromURL:")]
		NSObject[] AssetURLsFromURL(NSUrl url);

		// +(void) clearCSSAssetCache;
		[Static, Export("clearCSSAssetCache")]
		void ClearCSSAssetCache();

	}

	[BaseType(typeof(NSObject))]
	public partial interface UIBarButtonItem
	{
		[Static, Export("refreshCSSStylingInsideToolbar:")]
		void RefreshCssStylingInsideToolbar(UIToolbar toolbar);
	}

	[BaseType(typeof(NSObject))]
	public partial interface UIView
	{
		[Static, Export("refreshCSSStyling")]
		void RefreshCSSStyling();

		[Static, Export("refreshCSSStylingAndIgnoreSubviews:")]
		void RefreshCSSStylingAndIgnoreSubviews(bool ignoreSubviews);

		[Static, Export("viewControllerNCSSObfuscated")]
		UIViewController ViewControllerNCSSObfuscated { set; }

		[Static, Export("viewControllerForNavButtonNCSSObfuscated")]
		UIViewController ViewControllerForNavButtonNCSSObfuscated { get; }

		[Static, Export("viewHasCSSStyle")]
		bool ViewHasCSSSTyle { get; }

		[Static, Export("addCSSClass:")]
		void AddCSSClass(string className);

		[Static, Export("removeCSSClass:")]
		void RemoveCSSClass(string className);

		[Static, Export("CSSClasses")]
		NSObject[] CSSClasses { get; }

		[Static, Export("cSSId")]
		string CSSId { get; set; }
	}

}
