using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;
using Plugin.Maui.LocalStore;

namespace NuvyntraLabs.Lumina.Market;

public partial class App : Application
{
    readonly IServiceProvider _services;

    public App(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        InitializeComponent();
        _services = services;
        NVTheme.Current.UseLumina();
        NVTheme.Current.SetAccent(Color.FromArgb("#2874F0"));
        NVTheme.Current.SetMode(NVThemeMode.Light);
        _ = SeedAsync();
    }

    protected override Window CreateWindow(IActivationState? activationState)
        => new(new NavigationPage(_services.GetRequiredService<WalkthroughPage>())
        {
            BarBackgroundColor = Color.FromArgb("#2874F0"),
            BarTextColor = Colors.White
        });

    static async Task SeedAsync()
    {
        try
        {
            await LuminaStore.SeedAsync(LocalStore.Current, MarketSeed.Collection, MarketSeed.Items).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Prototype still runs from in-memory seed when the .nvx file cannot open.
        }
    }
}
