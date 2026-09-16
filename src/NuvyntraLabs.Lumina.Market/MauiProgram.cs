using Microsoft.Extensions.Logging;
using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;
using Plugin.Maui.FeatureFlags;
using Plugin.Maui.FormValidation;
using Plugin.Maui.HttpForge;
using Plugin.Maui.LocalStore;
using Plugin.Maui.MVVMExpress.Auth;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseNuvyntraUIKit()
            .UseMauiFormValidation(o =>
            {
                o.Trigger = ValidationTrigger.LostFocus;
                o.ShowMessage = true;
            })
            .UseMauiFeatureFlags(o =>
            {
                o.Environment = FeatureFlagEnvironment.Development;
                o.LocalFlags["new_checkout"] = true;
                o.LocalFlags["telehealth"] = true;
                o.LocalFlags["offline_first"] = true;
            })
            .UseMauiLocalStore(o =>
            {
                o.Backend = StoreBackend.Nuvexa;
                o.Path = Path.Combine(FileSystem.AppDataDirectory, "lumina-market.nvx");
                o.CreateIfMissing = true;
            })
            .UseHttpForge()
            .UseMvvmExpress(o => o
                .UseNavigationPage((nav, _) => nav
                    .Map<WalkthroughViewModel, WalkthroughPage>("walkthrough")
                    .Map<SignInViewModel, SignInPage>("signin")
                    .Map<SignUpViewModel, SignUpPage>("signup")
                    .Map<ForgotPasswordViewModel, ForgotPasswordPage>("forgotpassword")
                    .Map<ResetPasswordViewModel, ResetPasswordPage>("resetpassword")
                    .Map<ProfileSetupViewModel, ProfileSetupPage>("profilesetup")
                    .Map<HomeViewModel, HomePage>("home")
                    .Map<CategoriesViewModel, CategoriesPage>("categories")
                    .Map<CatalogViewModel, CatalogPage>("catalog")
                    .Map<ProductDetailViewModel, ProductDetailPage>("productdetail")
                    .Map<CompareViewModel, ComparePage>("compare")
                    .Map<SearchViewModel, SearchPage>("search")
                    .Map<FiltersViewModel, FiltersPage>("filters")
                    .Map<WishlistViewModel, WishlistPage>("wishlist")
                    .Map<CartViewModel, CartPage>("cart")
                    .Map<CheckoutViewModel, CheckoutPage>("checkout")
                    .Map<CardPaymentViewModel, CardPaymentPage>("cardpayment")
                    .Map<SavedCardsViewModel, SavedCardsPage>("savedcards")
                    .Map<PaymentResultViewModel, PaymentResultPage>("paymentresult")
                    .Map<OrdersViewModel, OrdersPage>("orders")
                    .Map<OrderDetailViewModel, OrderDetailPage>("orderdetail")
                    .Map<TrackingViewModel, TrackingPage>("tracking")
                    .Map<InvoiceViewModel, InvoicePage>("invoice")
                    .Map<ReceiptViewModel, ReceiptPage>("receipt")
                    .Map<ReviewsViewModel, ReviewsPage>("reviews")
                    .Map<StoreLocatorViewModel, StoreLocatorPage>("storelocator")
                    .Map<AddressesViewModel, AddressesPage>("addresses")
                    .Map<SubscriptionViewModel, SubscriptionPage>("subscription")
                    .Map<SellerChatViewModel, SellerChatPage>("sellerchat")
                    .Map<NotificationsViewModel, NotificationsPage>("notifications")
                    .Map<SettingsViewModel, SettingsPage>("settings")
                    .Map<HelpViewModel, HelpPage>("help"))
                .UseDialogs()
                .UseAuth<SignInViewModel>());

        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddSingleton<IMarketApi, MarketApi>();
        builder.Services.AddTransient<WalkthroughViewModel>();
        builder.Services.AddTransient<WalkthroughPage>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddTransient<SignUpPage>();
        builder.Services.AddTransient<ForgotPasswordViewModel>();
        builder.Services.AddTransient<ForgotPasswordPage>();
        builder.Services.AddTransient<ResetPasswordViewModel>();
        builder.Services.AddTransient<ResetPasswordPage>();
        builder.Services.AddTransient<ProfileSetupViewModel>();
        builder.Services.AddTransient<ProfileSetupPage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<CategoriesViewModel>();
        builder.Services.AddTransient<CategoriesPage>();
        builder.Services.AddTransient<CatalogViewModel>();
        builder.Services.AddTransient<CatalogPage>();
        builder.Services.AddTransient<ProductDetailViewModel>();
        builder.Services.AddTransient<ProductDetailPage>();
        builder.Services.AddTransient<CompareViewModel>();
        builder.Services.AddTransient<ComparePage>();
        builder.Services.AddTransient<SearchViewModel>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<FiltersViewModel>();
        builder.Services.AddTransient<FiltersPage>();
        builder.Services.AddTransient<WishlistViewModel>();
        builder.Services.AddTransient<WishlistPage>();
        builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<CartPage>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<CheckoutPage>();
        builder.Services.AddTransient<CardPaymentViewModel>();
        builder.Services.AddTransient<CardPaymentPage>();
        builder.Services.AddTransient<SavedCardsViewModel>();
        builder.Services.AddTransient<SavedCardsPage>();
        builder.Services.AddTransient<PaymentResultViewModel>();
        builder.Services.AddTransient<PaymentResultPage>();
        builder.Services.AddTransient<OrdersViewModel>();
        builder.Services.AddTransient<OrdersPage>();
        builder.Services.AddTransient<OrderDetailViewModel>();
        builder.Services.AddTransient<OrderDetailPage>();
        builder.Services.AddTransient<TrackingViewModel>();
        builder.Services.AddTransient<TrackingPage>();
        builder.Services.AddTransient<InvoiceViewModel>();
        builder.Services.AddTransient<InvoicePage>();
        builder.Services.AddTransient<ReceiptViewModel>();
        builder.Services.AddTransient<ReceiptPage>();
        builder.Services.AddTransient<ReviewsViewModel>();
        builder.Services.AddTransient<ReviewsPage>();
        builder.Services.AddTransient<StoreLocatorViewModel>();
        builder.Services.AddTransient<StoreLocatorPage>();
        builder.Services.AddTransient<AddressesViewModel>();
        builder.Services.AddTransient<AddressesPage>();
        builder.Services.AddTransient<SubscriptionViewModel>();
        builder.Services.AddTransient<SubscriptionPage>();
        builder.Services.AddTransient<SellerChatViewModel>();
        builder.Services.AddTransient<SellerChatPage>();
        builder.Services.AddTransient<NotificationsViewModel>();
        builder.Services.AddTransient<NotificationsPage>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<HelpViewModel>();
        builder.Services.AddTransient<HelpPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
