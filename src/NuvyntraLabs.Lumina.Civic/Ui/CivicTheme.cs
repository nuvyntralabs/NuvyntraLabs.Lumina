using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

internal sealed record CivicNav(string Label, ICommand? Command, bool Primary = false, string? Icon = null, string? Hint = null);

internal sealed class CivicModel
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required IReadOnlyList<CatalogItem> Items { get; init; }
    public required IReadOnlyList<CivicNav> Actions { get; init; }
    public IReadOnlyList<CivicNav>? Tabs { get; init; }
    public string? SelectedTab { get; init; }
    public string? Kind { get; init; }
}

/// <summary>Harbour borough tokens and shared chrome. Lives only in Civic.</summary>
internal static class CivicTheme
{
    public static readonly Color Navy = Color.FromArgb("#1B365D");
    public static readonly Color Deep = Color.FromArgb("#12243F");
    public static readonly Color Pulse = Color.FromArgb("#C23B2E");
    public static readonly Color Gold = Color.FromArgb("#D4A017");
    public static readonly Color SoftGold = Color.FromArgb("#F4E8C4");
    public static readonly Color Soft = Color.FromArgb("#E8EEF4");
    public static readonly Color Paper = Color.FromArgb("#F4F1EC");
    public static readonly Color Surface = Colors.White;
    public static readonly Color Ink = Color.FromArgb("#12202E");
    public static readonly Color Mute = Color.FromArgb("#5C6B7A");
    public static readonly Color Line = Color.FromArgb("#D9E1E8");
    public static readonly Color Success = Color.FromArgb("#1B7F4E");

    public static IReadOnlyList<CivicNav> Tabs(ICommand? home, ICommand? services, ICommand? transit, ICommand? wallet, ICommand? you) =>
    [
        new("Home", home, Icon: "icon_home"),
        new("Services", services, Icon: "icon_services"),
        new("Transit", transit, Icon: "icon_transit"),
        new("Wallet", wallet, Icon: "icon_wallet"),
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
            BackgroundColor = fill ?? Soft,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = box / 2 },
            Content = Icon(name, box * 0.48)
        };
    }

    public static View Card(View content, Thickness? padding = null) =>
        new Border
        {
            BackgroundColor = Surface,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 16 },
            Padding = padding ?? new Thickness(0),
            Shadow = new Shadow { Brush = Colors.Black, Opacity = 0.06f, Radius = 12, Offset = new Point(0, 4) },
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

    public static View BackButton()
    {
        var hit = new Border
        {
            WidthRequest = 44,
            HeightRequest = 44,
            BackgroundColor = Colors.Transparent,
            StrokeThickness = 0,
            Padding = 0,
            Content = new Label
            {
                Text = "‹",
                TextColor = Colors.White,
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
