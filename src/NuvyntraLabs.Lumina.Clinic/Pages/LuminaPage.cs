using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public abstract class LuminaPage : ContentPage
{
    protected LuminaPage(string title, string kicker, string body)
    {
        Title = title;
        BackgroundColor = NVTheme.Current.Paper;
        var stack = new VerticalStackLayout
        {
            Padding = new Thickness(20, 16, 20, 32),
            Spacing = NVTokens.Space3
        };
        stack.Add(new NVCaptionText { Text = kicker.ToUpperInvariant() });
        stack.Add(new NVHeading { Text = title, Role = NVTextRole.Title });
        stack.Add(new NVBodyText { Text = body });
        Root = stack;
        Content = new ScrollView { Content = stack };
    }

    protected VerticalStackLayout Root { get; }

    protected void AddCard(string title, string body)
    {
        Root.Add(new NVCard { Title = title, Body = body });
    }

    protected void AddAction(string text, System.Windows.Input.ICommand command, NVButtonVariant variant = NVButtonVariant.Filled)
    {
        Root.Add(new NVButton { Text = text, Variant = variant, Command = command });
    }
}
