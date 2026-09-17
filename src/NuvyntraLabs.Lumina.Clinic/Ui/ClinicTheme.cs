using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

internal sealed record ClinicNav(string Label, ICommand? Command, bool Primary = false, string? Icon = null, string? Hint = null);

internal sealed class ClinicModel
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required IReadOnlyList<CatalogItem> Items { get; init; }
    public required IReadOnlyList<ClinicNav> Actions { get; init; }
    public IReadOnlyList<ClinicNav>? Tabs { get; init; }
    public string? SelectedTab { get; init; }
    public string? Kind { get; init; }
}

/// <summary>Harbour Care tokens and shared chrome. Lives only in Clinic.</summary>
internal static class ClinicTheme
{
    public static readonly Color Teal = Color.FromArgb("#0EA5A0");
    public static readonly Color Deep = Color.FromArgb("#0A5C59");
    public static readonly Color Mint = Color.FromArgb("#E6F6F5");
    public static readonly Color Paper = Color.FromArgb("#F3F6F8");
    public static readonly Color Surface = Colors.White;
    public static readonly Color Ink = Color.FromArgb("#12202A");
    public static readonly Color Mute = Color.FromArgb("#6B7A82");
    public static readonly Color Line = Color.FromArgb("#E3EAEC");
    public static readonly Color Amber = Color.FromArgb("#F5A524");
    public static readonly Color Success = Color.FromArgb("#14804A");
    public static readonly Color Coral = Color.FromArgb("#FF6B57");

    public static IReadOnlyList<ClinicNav> Tabs(ICommand? home, ICommand? doctors, ICommand? visits, ICommand? records, ICommand? you) =>
    [
        new("Home", home, Icon: "icon_home"),
        new("Doctors", doctors, Icon: "icon_doctor"),
        new("Visits", visits, Icon: "icon_calendar"),
        new("Records", records, Icon: "icon_records"),
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
            BackgroundColor = fill ?? Mint,
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
            Shadow = new Shadow { Brush = Colors.Black, Opacity = 0.05f, Radius = 12, Offset = new Point(0, 4) },
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
                TextColor = Ink,
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
