using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;
using Plugin.Maui.LocalStore;

namespace NuvyntraLabs.Lumina.Civic;

public partial class App : Application
{
    readonly IServiceProvider _services;

    public App(IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(services);
        InitializeComponent();
        _services = services;
        NVTheme.Current.UseLumina();
        NVTheme.Current.SetAccent(Color.FromArgb("#C23B2E"));
        NVTheme.Current.SetMode(NVThemeMode.Light);
        _ = SeedAsync();
    }

    protected override Window CreateWindow(IActivationState? activationState)
        => new(new NavigationPage(_services.GetRequiredService<SignInPage>())
        {
            BarBackgroundColor = Color.FromArgb("#1B365D"),
            BarTextColor = Colors.White
        });

    static async Task SeedAsync()
    {
        try
        {
            await LuminaStore.SeedAsync(LocalStore.Current, CivicSeed.Collection, CivicSeed.Items).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Prototype still runs from in-memory seed when the .nvx file cannot open.
        }
    }
}
