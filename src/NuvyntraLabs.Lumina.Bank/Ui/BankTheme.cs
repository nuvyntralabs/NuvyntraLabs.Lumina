using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

internal sealed record BankNav(string Label, ICommand? Command, bool Primary = false, string? Icon = null, string? Hint = null);

internal sealed class BankModel
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required IReadOnlyList<CatalogItem> Items { get; init; }
    public required IReadOnlyList<BankNav> Actions { get; init; }
    public IReadOnlyList<BankNav>? Tabs { get; init; }
    public string? SelectedTab { get; init; }
    public string? Kind { get; init; }
}

/// <summary>Aether Bank tokens and shared chrome. Lives only in Bank.</summary>
internal static class BankTheme
{
    public static readonly Color Burgundy = Color.FromArgb("#6B1E3C");
    public static readonly Color Wine = Color.FromArgb("#2A1520");
    public static readonly Color Gold = Color.FromArgb("#C9A227");
    public static readonly Color SoftGold = Color.FromArgb("#F4E8C4");
    public static readonly Color Paper = Color.FromArgb("#F7F3EF");
    public static readonly Color Surface = Colors.White;
    public static readonly Color Ink = Color.FromArgb("#1A1214");
    public static readonly Color Mute = Color.FromArgb("#7A6A6E");
    public static readonly Color Line = Color.FromArgb("#E8DED6");
    public static readonly Color Credit = Color.FromArgb("#1B7F4E");
    public static readonly Color Danger = Color.FromArgb("#B42318");

    public static IReadOnlyList<BankNav> Tabs(ICommand? home, ICommand? accounts, ICommand? pay, ICommand? cards, ICommand? more) =>
    [
        new("Home", home, Icon: "icon_home"),
        new("Accounts", accounts, Icon: "icon_wallet"),
        new("Pay", pay, Icon: "icon_send"),
        new("Cards", cards, Icon: "icon_card"),
        new("More", more, Icon: "icon_more")
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
            BackgroundColor = fill ?? SoftGold,
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
