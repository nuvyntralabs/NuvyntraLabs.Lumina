using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

internal sealed record FieldNav(string Label, ICommand? Command, bool Primary = false, string? Icon = null, string? Hint = null);

internal sealed class FieldModel
{
    public required string Title { get; init; }
    public required string Subtitle { get; init; }
    public required IReadOnlyList<CatalogItem> Items { get; init; }
    public required IReadOnlyList<FieldNav> Actions { get; init; }
    public IReadOnlyList<FieldNav>? Tabs { get; init; }
    public string? SelectedTab { get; init; }
    public string? Kind { get; init; }
}

/// <summary>Harbour Fields tokens and shared chrome. Lives only in Field.</summary>
internal static class FieldTheme
{
    public static readonly Color Slate = Color.FromArgb("#1B3A4B");
    public static readonly Color Deep = Color.FromArgb("#12232E");
    public static readonly Color Orange = Color.FromArgb("#E07A3D");
    public static readonly Color Amber = Color.FromArgb("#C4841D");
    public static readonly Color SoftOrange = Color.FromArgb("#F6E4D6");
    public static readonly Color Soft = Color.FromArgb("#E8E4DA");
    public static readonly Color Paper = Color.FromArgb("#F3F1EC");
    public static readonly Color Surface = Colors.White;
    public static readonly Color Ink = Color.FromArgb("#1A1A1A");
    public static readonly Color Mute = Color.FromArgb("#6B7280");
    public static readonly Color Line = Color.FromArgb("#E5E1D8");
    public static readonly Color Go = Color.FromArgb("#2F8A4E");

    public static IReadOnlyList<FieldNav> Tabs(ICommand? today, ICommand? jobs, ICommand? assets, ICommand? queue, ICommand? you) =>
    [
        new("Today", today, Icon: "icon_home"),
        new("Jobs", jobs, Icon: "icon_jobs"),
        new("Assets", assets, Icon: "icon_asset"),
        new("Queue", queue, Icon: "icon_queue"),
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
            BackgroundColor = fill ?? SoftOrange,
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
