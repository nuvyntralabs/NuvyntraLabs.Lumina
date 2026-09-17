using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

/// <summary>City 311 / resident-services chrome for Civic Pulse. Tabs, pass, and desk live here.</summary>
internal static class CivicUi
{
    static Color Navy => CivicTheme.Navy;
    static Color Deep => CivicTheme.Deep;
    static Color Pulse => CivicTheme.Pulse;
    static Color Gold => CivicTheme.Gold;
    static Color SoftGold => CivicTheme.SoftGold;
    static Color Soft => CivicTheme.Soft;
    static Color Paper => CivicTheme.Paper;
    static Color Surface => CivicTheme.Surface;
    static Color Ink => CivicTheme.Ink;
    static Color Mute => CivicTheme.Mute;
    static Color Line => CivicTheme.Line;
    static Color Success => CivicTheme.Success;

    public static View Home(CivicModel m) => Page(HomeBody(m), Dock(m), hideTitle: true);
    public static View Services(CivicModel m) => Page(ServicesBody(m), Dock(m), "Services", tab: true);
    public static View Transit(CivicModel m) => Page(TransitBody(m), Dock(m), "Transit", tab: true);
    public static View Wallet(CivicModel m) => Page(WalletBody(m), Dock(m), "Wallet", tab: true);
    public static View Account(CivicModel m) => Page(AccountBody(m), Dock(m), "You", tab: true);
    public static View Auth(CivicModel m) => AuthBody(m);
    public static View Form(CivicModel m) => Page(FormBody(m), ActionBar(m), m.Title);
    public static View Detail(CivicModel m) => Page(DetailBody(m), ActionBar(m), m.Title);
    public static View List(CivicModel m) => Page(ListBody(m), ActionBar(m), m.Title);

    static View Page(View body, View? footer, string? title = null, bool hideTitle = false, bool tab = false)
    {
        var grid = new Grid
        {
            BackgroundColor = Paper,
            RowDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            SafeAreaEdges = new SafeAreaEdges(SafeAreaRegions.None, SafeAreaRegions.Container, SafeAreaRegions.None, SafeAreaRegions.None)
        };
        View header;
        if (hideTitle)
        {
            header = new BoxView { HeightRequest = 0, Color = Navy };
        }
        else
        {
            var bar = new Grid
            {
                BackgroundColor = Navy,
                Padding = new Thickness(tab ? 16 : 4, 6, 16, 10),
                MinimumHeightRequest = 48,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
            };
            if (!tab)
            {
                bar.Add(CivicTheme.BackButton());
            }

            var titleLabel = new Label
            {
                Text = title ?? "Civic Pulse",
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 17,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(tab ? 0 : 4, 0, 0, 0)
            };
            Grid.SetColumn(titleLabel, tab ? 0 : 1);
            if (tab)
            {
                Grid.SetColumnSpan(titleLabel, 3);
            }

            bar.Add(titleLabel);
            header = bar;
        }

        var scroll = new ScrollView { Content = body };
        Grid.SetRow(header, 0);
        Grid.SetRow(scroll, 1);
        grid.Add(header);
        grid.Add(scroll);
        if (footer is not null)
        {
            Grid.SetRow(footer, 2);
            grid.Add(footer);
        }

        return grid;
    }

    static View HomeBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Spacing = 0 };
        var hero = new Grid { BackgroundColor = Navy, Padding = new Thickness(20, 14, 20, 28) };
        var top = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        top.Add(new VerticalStackLayout
        {
            Spacing = 2,
            Children =
            {
                new HorizontalStackLayout
                {
                    Spacing = 6,
                    Children =
                    {
                        CivicTheme.Icon("icon_pin", 14),
                        new Label { Text = "Harbour borough", TextColor = Gold, FontSize = 12, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center }
                    }
                },
                new Label { Text = $"{Greeting()}, Ada", TextColor = Colors.White, FontSize = 24, FontAttributes = FontAttributes.Bold },
                new Label { Text = "Resident desk · East Quay", TextColor = Colors.White.WithAlpha(0.7f), FontSize = 13 }
            }
        });
        var bell = CivicTheme.Tap(Bell(), Find(m, "Alert", "Notify"));
        Grid.SetColumn(bell, 1);
        top.Add(bell);
        hero.Add(top);
        stack.Add(hero);

        var body = new VerticalStackLayout { BackgroundColor = Paper, Padding = new Thickness(16, 0, 16, 20), Spacing = 14, Margin = new Thickness(0, -16, 0, 0) };
        body.Add(CivicTheme.Tap(SearchBox("Search bins, permits, buses"), Find(m, "Service")));
        body.Add(TodayStrip(m));
        body.Add(Section("Report or request", "All services", Find(m, "Service")));
        body.Add(ServiceTiles(m));
        body.Add(Section("Borough today", "News", Find(m, "News")));
        foreach (var row in m.Items.Take(3))
        {
            body.Add(CivicTheme.Tap(InfoCard(row.Title, row.Subtitle, IconForItem(row.Title)), FirstFor(m, row.Title)));
        }

        body.Add(Section("This week", "Events", Find(m, "Event")));
        body.Add(CivicTheme.Tap(EventBanner(), Find(m, "Event")));
        stack.Add(body);
        return stack;
    }

    static View ServicesBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(CivicTheme.Tap(SearchBox("What do you need to report?"), First(m)));
        stack.Add(ChipRow(["Open", "Bins", "Roads", "Permits"], 0));
        stack.Add(Section("Open with the desk", null, null));
        foreach (var row in m.Items)
        {
            stack.Add(CivicTheme.Tap(RequestCard(row.Title, row.Subtitle), First(m)));
        }

        stack.Add(Section("Start a request", null, null));
        stack.Add(ServiceTiles(m));
        var permits = Find(m, "Permit");
        if (permits is not null)
        {
            stack.Add(CivicTheme.Tap(CivicTheme.Card(new VerticalStackLayout
            {
                Padding = 16,
                Spacing = 4,
                Children =
                {
                    new Label { Text = "Visitor bay or skip", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                    new Label { Text = "Apply or show a permit already issued.", FontSize = 13, TextColor = Mute }
                }
            }), permits));
        }

        return stack;
    }

    static View TransitBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(CivicTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 4,
            Children =
            {
                new Label { Text = "Harbour Walk", FontSize = 12, TextColor = Mute },
                new Label { Text = "Live board", FontAttributes = FontAttributes.Bold, FontSize = 20, TextColor = Ink },
                new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        foreach (var row in m.Items)
        {
            stack.Add(CivicTheme.Tap(BusCard(row.Title, row.Subtitle), First(m)));
        }

        var ticket = Find(m, "Ticket");
        if (ticket is not null)
        {
            stack.Add(CivicTheme.Tap(CivicTheme.Card(new Grid
            {
                Padding = 16,
                ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) },
                Children =
                {
                    new VerticalStackLayout
                    {
                        Children =
                        {
                            new Label { Text = "Day rover", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                            new Label { Text = "Zones 1–2 · QR in Wallet", FontSize = 13, TextColor = Mute }
                        }
                    },
                    Col(1, new Label { Text = "£8.40", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Pulse, VerticalOptions = LayoutOptions.Center })
                }
            }), ticket));
        }

        return stack;
    }

    static View WalletBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(PassCard());
        stack.Add(Section("On this pass", null, null));
        foreach (var row in m.Items)
        {
            stack.Add(CivicTheme.Tap(InfoCard(row.Title, row.Subtitle, IconForItem(row.Title)), First(m)));
        }

        stack.Add(ShortcutGrid(
        [
            ("Ticket", "icon_ticket", Find(m, "Ticket")),
            ("Permits", "icon_permit", Find(m, "Permit")),
            ("Scan", "icon_qr", Find(m, "Ticket")),
            ("Help", "icon_help", Find(m, "Help"))
        ]));
        return stack;
    }

    static View AccountBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(CivicTheme.Card(new Grid
        {
            Padding = 16,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 12,
            Children =
            {
                new Image { Source = "avatar_ada.png", WidthRequest = 56, HeightRequest = 56 },
                Col(1, new VerticalStackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Ada Lovelace", FontAttributes = FontAttributes.Bold, FontSize = 18, TextColor = Ink },
                        new Label { Text = "Resident  ·  East Quay  ·  HB-4418", FontSize = 13, TextColor = Mute }
                    }
                })
            }
        }));
        stack.Add(Group("Borough", m, "Office", "People", "Permit", "News", "Event"));
        stack.Add(Group("Your pass", m, "Wallet", "Ticket", "Alert", "Notify"));
        stack.Add(Group("Support", m, "Help", "Faq", "About", "What"));
        foreach (var row in m.Items)
        {
            stack.Add(InfoCard(row.Title, row.Subtitle, "icon_bell"));
        }

        return stack;
    }

    static View DetailBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(CivicTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 6,
            Children =
            {
                new Label { Text = m.Title, FontAttributes = FontAttributes.Bold, FontSize = 20, TextColor = Ink },
                new Label { Text = m.Subtitle, FontSize = 14, TextColor = Mute }
            }
        }));
        foreach (var row in m.Items)
        {
            stack.Add(CivicTheme.Card(Kv(row.Title, row.Subtitle), new Thickness(16, 4)));
        }

        return stack;
    }

    static View ListBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        if (!string.IsNullOrWhiteSpace(m.Subtitle))
        {
            stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        }

        if (string.Equals(m.Kind, "events", StringComparison.OrdinalIgnoreCase))
        {
            stack.Add(ChipRow(["This week", "Markets", "Library"], 0));
        }

        if (string.Equals(m.Kind, "news", StringComparison.OrdinalIgnoreCase))
        {
            stack.Add(ChipRow(["Borough", "Transit", "Waste"], 0));
        }

        foreach (var row in m.Items)
        {
            stack.Add(CivicTheme.Tap(InfoCard(row.Title, row.Subtitle, IconFor(m.Kind, row.Title)), First(m)));
        }

        foreach (var a in m.Actions.Where(x => !x.Primary).Take(2))
        {
            stack.Add(CivicTheme.Tap(InfoCard(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
        }

        return stack;
    }

    static View FormBody(CivicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        return stack;
    }

    static View AuthBody(CivicModel m)
    {
        var root = new Grid { BackgroundColor = Navy };
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 56, 24, 32), Spacing = 16 };
        stack.Add(new Label { Text = "CIVIC PULSE", TextColor = Gold, FontAttributes = FontAttributes.Bold, FontSize = 12 });
        stack.Add(new Label { Text = "Harbour borough", TextColor = Colors.White, FontSize = 28, FontAttributes = FontAttributes.Bold });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, TextColor = Colors.White.WithAlpha(0.72f) });

        var card = new VerticalStackLayout { Spacing = 12 };
        foreach (var row in m.Items)
        {
            card.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (p is not null)
        {
            card.Add(Btn(p.Label, p.Command, Pulse, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)))
        {
            card.Add(Link(extra.Label, extra.Command));
        }

        stack.Add(CivicTheme.Card(card, new Thickness(16)));
        stack.Add(new Label
        {
            Text = "Resident pass · East Quay · prototype seed",
            TextColor = Colors.White.WithAlpha(0.55f),
            FontSize = 12,
            HorizontalTextAlignment = TextAlignment.Center
        });
        root.Add(stack);
        return root;
    }

    static View TodayStrip(CivicModel m)
    {
        var row = new Grid { ColumnSpacing = 8 };
        row.ColumnDefinitions.Add(new(GridLength.Star));
        row.ColumnDefinitions.Add(new(GridLength.Star));
        row.ColumnDefinitions.Add(new(GridLength.Star));
        var tiles = m.Items.Take(3).ToArray();
        var fallback = new (string T, string S, string I, ICommand? C)[]
        {
            ("Bins", "Thu", "icon_bin", Find(m, "Service")),
            ("Bus 12", "4 min", "icon_transit", Find(m, "Transit")),
            ("Market", "18:00", "icon_calendar", Find(m, "Event"))
        };
        for (var i = 0; i < 3; i++)
        {
            var title = i < tiles.Length ? Short(tiles[i].Title) : fallback[i].T;
            var sub = i < tiles.Length ? ShortEta(tiles[i].Subtitle) : fallback[i].S;
            var icon = IconForItem(i < tiles.Length ? tiles[i].Title : fallback[i].T);
            var cmd = i < tiles.Length ? FirstFor(m, tiles[i].Title) : fallback[i].C;
            var cell = CivicTheme.Tap(CivicTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Spacing = 6,
                Children =
                {
                    CivicTheme.Glyph(icon, 36),
                    new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 13, TextColor = Ink, HorizontalTextAlignment = TextAlignment.Center },
                    new Label { Text = sub, FontSize = 11, TextColor = Mute, HorizontalTextAlignment = TextAlignment.Center }
                }
            }), cmd);
            Grid.SetColumn(cell, i);
            row.Add(cell);
        }

        return row;
    }

    static View ServiceTiles(CivicModel m)
    {
        var tiles = new (string L, string I, ICommand? C)[]
        {
            ("Bins", "icon_bin", Find(m, "Service", "Request")),
            ("Pothole", "icon_road", Find(m, "Service", "Request")),
            ("Permit", "icon_permit", Find(m, "Permit")),
            ("Council", "icon_council", Find(m, "Office", "People")),
            ("Library", "icon_library", Find(m, "Booking", "Office")),
            ("Help", "icon_help", Find(m, "Help", "You"))
        };
        var grid = new Grid { ColumnSpacing = 10, RowSpacing = 10 };
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.RowDefinitions.Add(new(GridLength.Auto));
        grid.RowDefinitions.Add(new(GridLength.Auto));
        for (var i = 0; i < tiles.Length; i++)
        {
            var t = tiles[i];
            var cell = CivicTheme.Tap(CivicTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Spacing = 8,
                Children =
                {
                    CivicTheme.Glyph(t.I, 40),
                    new Label { Text = t.L, FontSize = 12, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink, FontAttributes = FontAttributes.Bold }
                }
            }), t.C);
            Grid.SetColumn(cell, i % 3);
            Grid.SetRow(cell, i / 3);
            grid.Add(cell);
        }

        return grid;
    }

    static View EventBanner() =>
        CivicTheme.Card(new Grid
        {
            Padding = 16,
            ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) },
            Children =
            {
                new VerticalStackLayout
                {
                    Spacing = 4,
                    Children =
                    {
                        new Label { Text = "Harbour night market", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                        new Label { Text = "Thu 18:00  ·  Yard B  ·  42 stalls", FontSize = 13, TextColor = Mute }
                    }
                },
                Col(1, Badge("Tonight", true))
            }
        });

    static View PassCard()
    {
        var g = new Grid
        {
            BackgroundColor = Deep,
            HeightRequest = 188,
            Padding = 20
        };
        var stripe = new BoxView { Color = Gold, HeightRequest = 6, VerticalOptions = LayoutOptions.Start };
        var copy = new VerticalStackLayout { Spacing = 4, VerticalOptions = LayoutOptions.End };
        copy.Add(new Label { Text = "HARBOUR BOROUGH", TextColor = Gold, FontSize = 11, FontAttributes = FontAttributes.Bold });
        copy.Add(new Label { Text = "Ada Lovelace", TextColor = Colors.White, FontSize = 22, FontAttributes = FontAttributes.Bold });
        copy.Add(new Label { Text = "Resident pass  ·  East Quay  ·  HB-4418", TextColor = Colors.White.WithAlpha(0.7f), FontSize = 12 });
        g.Add(stripe);
        g.Add(copy);
        g.Add(new Border
        {
            WidthRequest = 56,
            HeightRequest = 56,
            BackgroundColor = Colors.White,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 8 },
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start,
            Content = CivicTheme.Icon("icon_qr", 36)
        });
        return new Border
        {
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 18 },
            Shadow = new Shadow { Brush = Colors.Black, Opacity = 0.16f, Radius = 16, Offset = new Point(0, 8) },
            Content = g
        };
    }

    static View BusCard(string line, string eta)
    {
        var badge = LineBadge(line);
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(badge);
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = line, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                new Label { Text = "Harbour Walk stop", FontSize = 12, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.End,
            Children =
            {
                new Label { Text = eta, FontSize = 18, FontAttributes = FontAttributes.Bold, TextColor = Pulse, HorizontalTextAlignment = TextAlignment.End },
                new Label { Text = "due", FontSize = 11, TextColor = Mute, HorizontalTextAlignment = TextAlignment.End }
            }
        }));
        return CivicTheme.Card(g);
    }

    static View RequestCard(string title, string subtitle)
    {
        var open = subtitle.Contains("Open", StringComparison.OrdinalIgnoreCase) || subtitle.Contains("Ready", StringComparison.OrdinalIgnoreCase);
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(CivicTheme.Glyph(IconForItem(title), 40));
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        g.Add(Col(2, Badge(open ? "Open" : "Scheduled", open)));
        return CivicTheme.Card(g);
    }

    static View InfoCard(string title, string subtitle, string icon)
    {
        var g = new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(CivicTheme.Glyph(icon, 36));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new Label { Text = "›", FontSize = 18, TextColor = Mute, VerticalOptions = LayoutOptions.Center }));
        return CivicTheme.Card(g);
    }

    static View LineBadge(string line)
    {
        var code = line.Contains(' ', StringComparison.Ordinal) ? line.Split(' ').Last() : line[..Math.Min(3, line.Length)];
        var ferry = line.Contains("Ferry", StringComparison.OrdinalIgnoreCase);
        return new Border
        {
            WidthRequest = 52,
            HeightRequest = 52,
            BackgroundColor = ferry ? Gold : Navy,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 10 },
            Content = new Label
            {
                Text = code,
                TextColor = ferry ? Deep : Colors.White,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        };
    }

    static View Dock(CivicModel m)
    {
        var tabs = m.Tabs is { Count: > 0 } listed
            ? listed
            : CivicTheme.Tabs(null, Find(m, "Service"), Find(m, "Transit"), Find(m, "Wallet"), Find(m, "You", "More", "Setting"));
        var selected = m.SelectedTab ?? "Home";
        var row = new Grid
        {
            BackgroundColor = Surface,
            Padding = new Thickness(4, 6, 4, 6),
            SafeAreaEdges = new SafeAreaEdges(SafeAreaRegions.None, SafeAreaRegions.None, SafeAreaRegions.None, SafeAreaRegions.Container)
        };
        for (var i = 0; i < tabs.Count; i++)
        {
            row.ColumnDefinitions.Add(new(GridLength.Star));
            var tab = tabs[i];
            var on = tab.Label == selected;
            var cell = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 4,
                Children =
                {
                    CivicTheme.Icon(tab.Icon ?? IconName(tab.Label), 22),
                    new Label
                    {
                        Text = tab.Label,
                        FontSize = 10,
                        FontAttributes = on ? FontAttributes.Bold : FontAttributes.None,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = on ? Pulse : Mute
                    }
                }
            };
            if (!on && tab.Command is { } cmd)
            {
                cell.GestureRecognizers.Add(new TapGestureRecognizer { Command = cmd });
            }

            Grid.SetColumn(cell, i);
            row.Add(cell);
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, row } };
    }

    static View ActionBar(CivicModel m)
    {
        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var s = new VerticalStackLayout { BackgroundColor = Surface, Padding = new Thickness(16, 10, 16, 22), Spacing = 8 };
        if (p is not null)
        {
            s.Add(Btn(p.Label, p.Command, Pulse, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)).Take(2))
        {
            s.Add(Link(extra.Label, extra.Command));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, s } };
    }

    static View Group(string title, CivicModel m, params string[] keys)
    {
        var box = new VerticalStackLayout();
        var added = 0;
        foreach (var a in m.Actions.Where(x => keys.Any(k => x.Label.Contains(k, StringComparison.OrdinalIgnoreCase))))
        {
            box.Add(CivicTheme.Tap(MenuRow(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
            added++;
        }

        if (added == 0)
        {
            return new BoxView { HeightRequest = 0 };
        }

        return new VerticalStackLayout
        {
            Spacing = 6,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 13, TextColor = Mute, Margin = new Thickness(4, 4, 0, 0) },
                CivicTheme.Card(box)
            }
        };
    }

    static View MenuRow(string title, string hint, string icon)
    {
        var g = new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(CivicTheme.Glyph(icon, 36));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontSize = 15, TextColor = Ink, FontAttributes = FontAttributes.Bold },
                new Label { Text = hint, FontSize = 11, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new Label { Text = "›", FontSize = 18, TextColor = Mute, VerticalOptions = LayoutOptions.Center }));
        return g;
    }

    static View ShortcutGrid((string L, string I, ICommand? C)[] items)
    {
        var grid = new Grid { ColumnSpacing = 10 };
        for (var i = 0; i < items.Length; i++)
        {
            grid.ColumnDefinitions.Add(new(GridLength.Star));
            var item = items[i];
            var cell = CivicTheme.Tap(CivicTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Spacing = 8,
                Children =
                {
                    CivicTheme.Glyph(item.I, 36),
                    new Label { Text = item.L, FontSize = 11, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink }
                }
            }), item.C);
            Grid.SetColumn(cell, i);
            grid.Add(cell);
        }

        return grid;
    }

    static View Section(string title, string? link, ICommand? cmd)
    {
        var g = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink });
        if (!string.IsNullOrWhiteSpace(link))
        {
            g.Add(Col(1, CivicTheme.Tap(new Label { Text = link, TextColor = Pulse, FontSize = 13, FontAttributes = FontAttributes.Bold }, cmd)));
        }

        return g;
    }

    static View Bell()
    {
        var g = new Grid { WidthRequest = 40, HeightRequest = 40 };
        g.Add(new Border
        {
            BackgroundColor = Colors.White.WithAlpha(0.12f),
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 20 },
            Content = CivicTheme.Icon("icon_bell", 18)
        });
        g.Add(new Border
        {
            WidthRequest = 9,
            HeightRequest = 9,
            BackgroundColor = Pulse,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 4.5 },
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 4, 4, 0)
        });
        return g;
    }

    static View SearchBox(string ph) =>
        CivicTheme.Card(new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 10,
            Children =
            {
                CivicTheme.Icon("icon_search", 18),
                Col(1, new Label { Text = ph, TextColor = Mute, FontSize = 14, VerticalOptions = LayoutOptions.Center })
            }
        });

    static View ChipRow(string[] labels, int selected)
    {
        var row = new ScrollView { Orientation = ScrollOrientation.Horizontal, HorizontalScrollBarVisibility = ScrollBarVisibility.Never };
        var chips = new HorizontalStackLayout { Spacing = 8 };
        for (var i = 0; i < labels.Length; i++)
        {
            var on = i == selected;
            chips.Add(new Border
            {
                BackgroundColor = on ? Soft : Surface,
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(on ? Navy : Line),
                StrokeShape = new RoundRectangle { CornerRadius = 16 },
                Padding = new Thickness(12, 7),
                Content = new Label { Text = labels[i], FontSize = 12, TextColor = on ? Navy : Ink, FontAttributes = on ? FontAttributes.Bold : FontAttributes.None }
            });
        }

        row.Content = chips;
        return row;
    }

    static View Badge(string text, bool ok) =>
        new Border
        {
            BackgroundColor = ok ? SoftGold : Soft,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 8 },
            Padding = new Thickness(8, 3),
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Content = new Label { Text = text, FontSize = 11, FontAttributes = FontAttributes.Bold, TextColor = ok ? Pulse : Mute }
        };

    static View Field(string label, string value, bool secret) =>
        new VerticalStackLayout
        {
            Spacing = 6,
            Children =
            {
                new Label { Text = label, FontSize = 12, TextColor = Mute },
                new Border
                {
                    BackgroundColor = Paper,
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Line),
                    Padding = new Thickness(12, 10),
                    StrokeShape = new RoundRectangle { CornerRadius = 10 },
                    Content = new Entry { Text = value, IsPassword = secret, BackgroundColor = Colors.Transparent, TextColor = Ink }
                }
            }
        };

    static View Btn(string text, ICommand? cmd, Color bg, Color fg)
    {
        var b = new Border
        {
            HeightRequest = 50,
            BackgroundColor = bg,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 12 },
            Content = new Label { Text = text, TextColor = fg, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }
        };
        return CivicTheme.Tap(b, cmd);
    }

    static View Link(string text, ICommand? cmd) =>
        CivicTheme.Tap(new Label { Text = text, TextColor = Pulse, HorizontalTextAlignment = TextAlignment.Center, Padding = 6, FontAttributes = FontAttributes.Bold }, cmd);

    static View Kv(string k, string v)
    {
        var g = new Grid { Padding = new Thickness(0, 10), ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = k, TextColor = Mute, FontSize = 13 });
        g.Add(Col(1, new Label { Text = v, TextColor = Ink, FontAttributes = FontAttributes.Bold, FontSize = 13 }));
        return g;
    }

    static View Col(int col, View v)
    {
        Grid.SetColumn(v, col);
        return v;
    }

    static ICommand? First(CivicModel m) => (m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault())?.Command;

    static ICommand? Find(CivicModel m, params string[] n) =>
        m.Actions.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command
        ?? m.Tabs?.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command;

    static ICommand? FirstFor(CivicModel m, string title)
    {
        var t = title.ToLowerInvariant();
        if (t.Contains("bus") || t.Contains("ferry") || t.Contains("night"))
        {
            return Find(m, "Transit") ?? First(m);
        }

        if (t.Contains("market") || t.Contains("event"))
        {
            return Find(m, "Event") ?? First(m);
        }

        if (t.Contains("bin") || t.Contains("pothole") || t.Contains("missed"))
        {
            return Find(m, "Service") ?? First(m);
        }

        return First(m);
    }

    static string Greeting()
    {
        var h = DateTime.Now.Hour;
        return h < 12 ? "Good morning" : h < 17 ? "Good afternoon" : "Good evening";
    }

    static string Short(string v) => v.Length <= 10 ? v : v.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

    static string ShortEta(string v)
    {
        var bit = v.Split('·', StringSplitOptions.TrimEntries).FirstOrDefault() ?? v;
        return bit.Length <= 12 ? bit : bit[..12];
    }

    static string IconName(string label)
    {
        var l = label.ToLowerInvariant();
        if (l.Contains("home")) return "icon_home";
        if (l.Contains("service") || l.Contains("request")) return "icon_services";
        if (l.Contains("transit") || l.Contains("bus") || l.Contains("ferry")) return "icon_transit";
        if (l.Contains("wallet") || l.Contains("pass") || l.Contains("point")) return "icon_wallet";
        if (l.Contains("you") || l.Contains("account") || l.Contains("setting")) return "icon_user";
        if (l.Contains("alert") || l.Contains("notify")) return "icon_bell";
        if (l.Contains("event") || l.Contains("market") || l.Contains("book")) return "icon_calendar";
        if (l.Contains("news") || l.Contains("story") || l.Contains("article")) return "icon_news";
        if (l.Contains("ticket") || l.Contains("rover")) return "icon_ticket";
        if (l.Contains("permit") || l.Contains("bay") || l.Contains("skip")) return "icon_permit";
        if (l.Contains("office") || l.Contains("hall") || l.Contains("library")) return "icon_office";
        if (l.Contains("people") || l.Contains("cllr") || l.Contains("desk")) return "icon_people";
        if (l.Contains("help") || l.Contains("faq")) return "icon_help";
        if (l.Contains("about") || l.Contains("what")) return "icon_council";
        if (l.Contains("bin") || l.Contains("waste")) return "icon_bin";
        if (l.Contains("pothole") || l.Contains("road")) return "icon_road";
        if (l.Contains("scan") || l.Contains("qr")) return "icon_qr";
        return "icon_services";
    }

    static string IconForItem(string title) => IconName(title);

    static string IconFor(string? kind, string title)
    {
        if (string.Equals(kind, "events", StringComparison.OrdinalIgnoreCase)) return "icon_calendar";
        if (string.Equals(kind, "news", StringComparison.OrdinalIgnoreCase)) return "icon_news";
        if (string.Equals(kind, "notifications", StringComparison.OrdinalIgnoreCase)) return "icon_bell";
        if (string.Equals(kind, "offices", StringComparison.OrdinalIgnoreCase)) return "icon_office";
        if (string.Equals(kind, "people", StringComparison.OrdinalIgnoreCase)) return "icon_people";
        if (string.Equals(kind, "permits", StringComparison.OrdinalIgnoreCase)) return "icon_permit";
        return IconName(title);
    }
}
