using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

internal sealed record MarketNav(string Label, ICommand? Command, bool Primary = false, string? Icon = null, string? Hint = null);

internal sealed class MarketModel
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required IReadOnlyList<CatalogItem> Items { get; init; }
    public required IReadOnlyList<MarketNav> Actions { get; init; }
    public IReadOnlyList<CatalogItem> Aisles { get; init; } = [];
    public IReadOnlyList<MarketNav>? Tabs { get; init; }
    public string? SelectedTab { get; init; }
    public string? Kind { get; init; }
}

/// <summary>Harbour Market tokens and shared chrome. Lives only in Market.</summary>
internal static class MarketTheme
{
    public static readonly Color Blue = Color.FromArgb("#2874F0");
    public static readonly Color Deep = Color.FromArgb("#1A4FA0");
    public static readonly Color Paper = Color.FromArgb("#F1F3F6");
    public static readonly Color Surface = Colors.White;
    public static readonly Color Ink = Color.FromArgb("#212121");
    public static readonly Color Mute = Color.FromArgb("#717478");
    public static readonly Color Line = Color.FromArgb("#E0E0E0");
    public static readonly Color Buy = Color.FromArgb("#FB641B");
    public static readonly Color Amber = Color.FromArgb("#FF9F00");
    public static readonly Color Star = Color.FromArgb("#388E3C");
    public static readonly Color Ice = Color.FromArgb("#E3F2FD");

    public static IReadOnlyList<MarketNav> Tabs(ICommand? home, ICommand? shop, ICommand? cart, ICommand? orders, ICommand? you) =>
    [
        new("Home", home, Icon: "icon_home"),
        new("Shop", shop, Icon: "icon_shop"),
        new("Cart", cart, Icon: "icon_cart"),
        new("Orders", orders, Icon: "icon_orders"),
        new("You", you, Icon: "icon_user")
    ];

    public static Image Icon(string name, double size = 22) =>
        new()
        {
            Source = $"{name}.png",
            WidthRequest = size,
            HeightRequest = size,
            Aspect = Aspect.AspectFit,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

    public static View Glyph(string name, double box = 44, Color? fill = null)
    {
        return new Border
        {
            WidthRequest = box,
            HeightRequest = box,
            BackgroundColor = fill ?? Ice,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = box / 2 },
            Content = Icon(name, box * 0.48)
        };
    }

    public static View Card(View content, Thickness? padding = null, double radius = 10) =>
        new Border
        {
            BackgroundColor = Surface,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = radius },
            Padding = padding ?? new Thickness(0),
            Shadow = new Shadow { Brush = Colors.Black, Opacity = 0.05f, Radius = 10, Offset = new Point(0, 3) },
            Content = content
        };

    public static View Tap(View view, ICommand? command)
    {
        if (command is not null)
        {
            view.GestureRecognizers.Add(new TapGestureRecognizer { Command = command });
        }

        return view;
    }

    public static View BackButton(Color? color = null)
    {
        var hit = new Border
        {
            WidthRequest = 44,
            HeightRequest = 44,
            BackgroundColor = Colors.Transparent,
            StrokeThickness = 0,
            Content = new Label
            {
                Text = "‹",
                TextColor = color ?? Colors.White,
                FontSize = 28,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        };
        var tap = new TapGestureRecognizer();
        tap.Tapped += async (_, _) => await PopAsync().ConfigureAwait(true);
        hit.GestureRecognizers.Add(tap);
        return hit;
    }

    public static async Task PopAsync()
    {
        var page = Application.Current?.Windows.FirstOrDefault()?.Page;
        var nav = page?.Navigation;
        if (nav is null)
        {
            return;
        }

        if (nav.NavigationStack.Count > 1)
        {
            await nav.PopAsync().ConfigureAwait(true);
            return;
        }

        if (nav.ModalStack.Count > 0)
        {
            await nav.PopModalAsync().ConfigureAwait(true);
        }
    }
}
