using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

/// <summary>Crew-board chrome for Harbour Fields. Tabs, jobs, NFC, and queue live here.</summary>
internal static class FieldUi
{
    static Color Slate => FieldTheme.Slate;
    static Color Deep => FieldTheme.Deep;
    static Color Orange => FieldTheme.Orange;
    static Color Amber => FieldTheme.Amber;
    static Color SoftOrange => FieldTheme.SoftOrange;
    static Color Soft => FieldTheme.Soft;
    static Color Paper => FieldTheme.Paper;
    static Color Surface => FieldTheme.Surface;
    static Color Ink => FieldTheme.Ink;
    static Color Mute => FieldTheme.Mute;
    static Color Line => FieldTheme.Line;
    static Color Go => FieldTheme.Go;

    public static View Home(FieldModel m) => Page(HomeBody(m), Dock(m), hideTitle: true);
    public static View Jobs(FieldModel m) => Page(JobsBody(m), Dock(m), "Jobs", tab: true);
    public static View Assets(FieldModel m) => Page(AssetsBody(m), Dock(m), "Assets", tab: true);
    public static View Queue(FieldModel m) => Page(QueueBody(m), Dock(m), "Queue", tab: true);
    public static View Account(FieldModel m) => Page(AccountBody(m), Dock(m), "You", tab: true);
    public static View Job(FieldModel m) => Page(JobDetail(m), ActionBar(m), m.Title);
    public static View Scan(FieldModel m) => ScanBody(m);
    public static View Auth(FieldModel m) => AuthBody(m);
    public static View Form(FieldModel m) => Page(FormBody(m), ActionBar(m), m.Title);
    public static View List(FieldModel m) => Page(ListBody(m), ActionBar(m), m.Title);

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
            header = new BoxView { HeightRequest = 0, Color = Slate };
        }
        else
        {
            var bar = new Grid
            {
                BackgroundColor = Slate,
                Padding = new Thickness(tab ? 16 : 4, 6, 16, 10),
                MinimumHeightRequest = 48,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
            };
            if (!tab)
            {
                bar.Add(FieldTheme.BackButton());
            }

            var titleLabel = new Label
            {
                Text = title ?? "Harbour Fields",
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

    static View HomeBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Spacing = 0 };
        var hero = new Grid { BackgroundColor = Slate, Padding = new Thickness(20, 14, 20, 28) };
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
                        FieldTheme.Icon("icon_pin", 14),
                        new Label { Text = DayLine(), TextColor = Colors.White.WithAlpha(0.75f), FontSize = 12, VerticalOptions = LayoutOptions.Center }
                    }
                },
                new Label { Text = $"{Greeting()}, Nia", TextColor = Colors.White, FontSize = 24, FontAttributes = FontAttributes.Bold },
                new Label { Text = "Crew HF-441 · Harbour district", TextColor = Orange, FontSize = 13, FontAttributes = FontAttributes.Bold }
            }
        });
        var bell = FieldTheme.Tap(Bell(), Find(m, "Alert", "Notify"));
        Grid.SetColumn(bell, 1);
        top.Add(bell);
        hero.Add(top);
        stack.Add(hero);

        var body = new VerticalStackLayout { BackgroundColor = Paper, Padding = new Thickness(16, 0, 16, 20), Spacing = 14, Margin = new Thickness(0, -16, 0, 0) };
        body.Add(StatStrip());
        body.Add(Section("Next on the board", "All jobs", Find(m, "Job")));
        var first = m.Items.FirstOrDefault();
        if (first is not null)
        {
            body.Add(FieldTheme.Tap(JobCard(first.Title, first.Subtitle, "En route", hero: true), Find(m, "Job") ?? First(m)));
        }

        foreach (var row in m.Items.Skip(1))
        {
            body.Add(FieldTheme.Tap(JobCard(row.Title, row.Subtitle, StatusFor(row.Title)), FirstFor(m, row.Title)));
        }

        body.Add(Section("On the van", null, null));
        body.Add(ShortcutGrid(
        [
            ("Scan", "icon_nfc", Find(m, "Scan", "Nfc", "Asset")),
            ("Route", "icon_route", Find(m, "Route", "Site")),
            ("Safety", "icon_safety", Find(m, "Safety", "Check")),
            ("Time", "icon_time", Find(m, "Time", "Continue", "Dash"))
        ]));
        stack.Add(body);
        return stack;
    }

    static View JobsBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(FieldTheme.Tap(SearchBox("Job id, site, or SLA"), First(m)));
        stack.Add(ChipRow(["Today", "En route", "On site", "Print"], 0));
        var i = 0;
        var statuses = new[] { "En route", "On site", "Scheduled" };
        foreach (var row in m.Items)
        {
            stack.Add(FieldTheme.Tap(JobCard(row.Title, row.Subtitle, statuses[i % statuses.Length]), First(m)));
            i++;
        }

        var route = Find(m, "Route");
        if (route is not null)
        {
            stack.Add(FieldTheme.Tap(FieldTheme.Card(new VerticalStackLayout
            {
                Padding = 16,
                Spacing = 4,
                Children =
                {
                    new Label { Text = "Cedar → Pier 3 → desk", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                    new Label { Text = "Three stops. Open the run sheet.", FontSize = 13, TextColor = Mute }
                }
            }), route));
        }

        return stack;
    }

    static View AssetsBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(FieldTheme.Tap(SearchBox("Pump, generator, radio"), First(m)));
        stack.Add(ChipRow(["Yard", "Due", "Van"], 0));
        foreach (var row in m.Items)
        {
            stack.Add(FieldTheme.Tap(AssetCard(row.Title, row.Subtitle), First(m)));
        }

        var scan = Find(m, "Scan", "Nfc");
        if (scan is not null)
        {
            stack.Add(FieldTheme.Tap(FieldTheme.Card(new Grid
            {
                Padding = 16,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
                ColumnSpacing = 12,
                Children =
                {
                    FieldTheme.Glyph("icon_nfc", 44),
                    Col(1, new VerticalStackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Label { Text = "Hold to plate", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                            new Label { Text = "NFC write and last service.", FontSize = 13, TextColor = Mute }
                        }
                    })
                }
            }), scan));
        }

        return stack;
    }

    static View QueueBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(FieldTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 4,
            Children =
            {
                new Label { Text = "Waiting on radio", FontSize = 12, TextColor = Mute },
                new Label { Text = $"{m.Items.Count} items queued", FontAttributes = FontAttributes.Bold, FontSize = 20, TextColor = Ink },
                new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        foreach (var row in m.Items)
        {
            stack.Add(FieldTheme.Tap(QueueCard(row.Title, row.Subtitle), First(m)));
        }

        var conflict = Find(m, "Conflict");
        if (conflict is not null)
        {
            stack.Add(FieldTheme.Tap(FieldTheme.Card(new VerticalStackLayout
            {
                Padding = 16,
                Spacing = 4,
                Children =
                {
                    new Label { Text = "Gasket replace vs gasket OK", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                    new Label { Text = "Desk and van disagree. Pick a side.", FontSize = 13, TextColor = Mute }
                }
            }), conflict));
        }

        return stack;
    }

    static View AccountBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(FieldTheme.Card(new Grid
        {
            Padding = 16,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 12,
            Children =
            {
                new Image { Source = "avatar_nia.png", WidthRequest = 56, HeightRequest = 56 },
                Col(1, new VerticalStackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Nia Okonkwo", FontAttributes = FontAttributes.Bold, FontSize = 18, TextColor = Ink },
                        new Label { Text = "Crew HF-441  ·  Lead  ·  Van 3", FontSize = 13, TextColor = Mute }
                    }
                })
            }
        }));
        stack.Add(Group("Board", m, "Dash", "Job", "Time", "Route", "Site"));
        stack.Add(Group("On site", m, "Safety", "Check", "File", "Print", "Team"));
        stack.Add(Group("Van", m, "Alert", "Notify", "Queue", "Offline"));
        foreach (var row in m.Items)
        {
            stack.Add(InfoCard(row.Title, row.Subtitle, "icon_settings"));
        }

        return stack;
    }

    static View JobDetail(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(FieldTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 8,
            Children =
            {
                Pill("En route", Go),
                new Label { Text = m.Title, FontAttributes = FontAttributes.Bold, FontSize = 22, TextColor = Ink },
                new Label { Text = m.Subtitle, FontSize = 14, TextColor = Mute }
            }
        }));
        stack.Add(FieldTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 6,
            Children =
            {
                new Label { Text = "Cedar Yard · Bay B", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                new Label { Text = "SLA today 16:00  ·  Nia on site", FontSize = 13, TextColor = Mute }
            }
        }));
        foreach (var row in m.Items)
        {
            stack.Add(FieldTheme.Card(Kv(row.Title, row.Subtitle), new Thickness(16, 4)));
        }

        return stack;
    }

    static View ListBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        if (!string.IsNullOrWhiteSpace(m.Subtitle))
        {
            stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        }

        if (string.Equals(m.Kind, "route", StringComparison.OrdinalIgnoreCase))
        {
            var step = 1;
            foreach (var row in m.Items)
            {
                stack.Add(FieldTheme.Tap(RouteStop(step++, row.Subtitle.Length > 0 ? row.Subtitle : row.Title, row.Title), First(m)));
            }

            return stack;
        }

        foreach (var row in m.Items)
        {
            stack.Add(FieldTheme.Tap(InfoCard(row.Title, row.Subtitle, IconFor(m.Kind, row.Title)), First(m)));
        }

        foreach (var a in m.Actions.Where(x => !x.Primary).Take(2))
        {
            stack.Add(FieldTheme.Tap(InfoCard(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
        }

        return stack;
    }

    static View FormBody(FieldModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(CheckRow(row.Title, row.Subtitle));
        }

        return stack;
    }

    static View ScanBody(FieldModel m)
    {
        var root = new Grid { BackgroundColor = Deep };
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 48, 24, 32), Spacing = 16 };
        stack.Add(FieldTheme.BackButton());
        stack.Add(new Label { Text = "NFC ASSET", TextColor = Orange, FontAttributes = FontAttributes.Bold, FontSize = 12, HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new Label { Text = m.Title, TextColor = Colors.White, FontSize = 26, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new Label { Text = m.Subtitle, TextColor = Colors.White.WithAlpha(0.7f), HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new Border
        {
            HeightRequest = 220,
            WidthRequest = 220,
            HorizontalOptions = LayoutOptions.Center,
            Stroke = new SolidColorBrush(Orange),
            StrokeThickness = 3,
            StrokeShape = new RoundRectangle { CornerRadius = 110 },
            BackgroundColor = Colors.White.WithAlpha(0.04f),
            Content = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 8,
                Children =
                {
                    FieldTheme.Icon("icon_nfc", 48),
                    new Label { Text = "Hold to plate", TextColor = Orange, HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Bold }
                }
            }
        });
        foreach (var row in m.Items)
        {
            stack.Add(new Label { Text = $"{row.Title}  ·  {row.Subtitle}", TextColor = Colors.White.WithAlpha(0.85f), HorizontalTextAlignment = TextAlignment.Center });
        }

        var go = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (go is not null)
        {
            stack.Add(Btn(go.Label, go.Command, Orange, Colors.White));
        }

        root.Add(stack);
        return root;
    }

    static View AuthBody(FieldModel m)
    {
        var root = new Grid { BackgroundColor = Deep };
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 56, 24, 32), Spacing = 16 };
        stack.Add(new Label { Text = "HARBOUR FIELDS", TextColor = Orange, FontAttributes = FontAttributes.Bold, FontSize = 12 });
        stack.Add(new Label { Text = "Crew gate", TextColor = Colors.White, FontSize = 28, FontAttributes = FontAttributes.Bold });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, TextColor = Colors.White.WithAlpha(0.72f) });

        var card = new VerticalStackLayout { Spacing = 12 };
        foreach (var row in m.Items)
        {
            card.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (p is not null)
        {
            card.Add(Btn(p.Label, p.Command, Orange, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)))
        {
            card.Add(Link(extra.Label, extra.Command));
        }

        stack.Add(FieldTheme.Card(card, new Thickness(16)));
        stack.Add(new Label
        {
            Text = "Van 3 · PIN on the tablet · prototype seed",
            TextColor = Colors.White.WithAlpha(0.55f),
            FontSize = 12,
            HorizontalTextAlignment = TextAlignment.Center
        });
        root.Add(stack);
        return root;
    }

    static View StatStrip()
    {
        var row = new Grid { ColumnSpacing = 8 };
        row.ColumnDefinitions.Add(new(GridLength.Star));
        row.ColumnDefinitions.Add(new(GridLength.Star));
        row.ColumnDefinitions.Add(new(GridLength.Star));
        var tiles = new (string V, string L)[] { ("3", "Open"), ("0", "Overdue"), ("2", "Queued") };
        for (var i = 0; i < tiles.Length; i++)
        {
            var cell = FieldTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Children =
                {
                    new Label { Text = tiles[i].V, FontAttributes = FontAttributes.Bold, FontSize = 22, TextColor = i == 2 ? Orange : Ink, HorizontalTextAlignment = TextAlignment.Center },
                    new Label { Text = tiles[i].L, FontSize = 11, TextColor = Mute, HorizontalTextAlignment = TextAlignment.Center }
                }
            });
            Grid.SetColumn(cell, i);
            row.Add(cell);
        }

        return row;
    }

    static View JobCard(string title, string subtitle, string? status, bool hero = false)
    {
        var g = new Grid
        {
            Padding = hero ? 16 : 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(FieldTheme.Glyph(IconName(title + " " + subtitle), hero ? 48 : 40));
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = hero ? 17 : 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        if (status is not null)
        {
            g.Add(Col(2, Pill(status, StatusColor(status))));
        }

        return FieldTheme.Card(g);
    }

    static View AssetCard(string title, string subtitle)
    {
        var due = subtitle.Contains("due", StringComparison.OrdinalIgnoreCase);
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(FieldTheme.Glyph("icon_asset", 40));
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        g.Add(Col(2, Pill(due ? "Due" : "OK", due ? Amber : Go)));
        return FieldTheme.Card(g);
    }

    static View QueueCard(string title, string subtitle)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(FieldTheme.Glyph("icon_queue", 40, Soft));
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute }
            }
        }));
        g.Add(Col(2, Pill("Retry", Amber)));
        return FieldTheme.Card(g);
    }

    static View RouteStop(int n, string place, string order)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 12
        };
        g.Add(new Border
        {
            WidthRequest = 36,
            HeightRequest = 36,
            BackgroundColor = n == 1 ? Orange : Soft,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 18 },
            Content = new Label
            {
                Text = n.ToString(),
                TextColor = n == 1 ? Colors.White : Ink,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        });
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = place, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = $"Stop {order}", FontSize = 12, TextColor = Mute }
            }
        }));
        return FieldTheme.Card(g);
    }

    static View InfoCard(string title, string subtitle, string icon)
    {
        var g = new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(FieldTheme.Glyph(icon, 36));
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
        return FieldTheme.Card(g);
    }

    static View CheckRow(string title, string value)
    {
        var ok = value.Equals("OK", StringComparison.OrdinalIgnoreCase)
                 || value.Equals("On", StringComparison.OrdinalIgnoreCase)
                 || value.Equals("Replace", StringComparison.OrdinalIgnoreCase)
                 || value.Equals("Nia", StringComparison.OrdinalIgnoreCase);
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 10
        };
        g.Add(new Border
        {
            WidthRequest = 24,
            HeightRequest = 24,
            BackgroundColor = ok ? Go : Surface,
            Stroke = new SolidColorBrush(ok ? Go : Line),
            StrokeThickness = ok ? 0 : 2,
            StrokeShape = new RoundRectangle { CornerRadius = 6 },
            Content = new Label { Text = ok ? "✓" : "", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, TextColor = Colors.White, FontAttributes = FontAttributes.Bold }
        });
        g.Add(Col(1, new Label { Text = title, FontSize = 15, TextColor = Ink, VerticalOptions = LayoutOptions.Center }));
        g.Add(Col(2, new Label { Text = value, FontSize = 13, TextColor = Mute, VerticalOptions = LayoutOptions.Center }));
        return FieldTheme.Card(g);
    }

    static View Dock(FieldModel m)
    {
        var tabs = m.Tabs is { Count: > 0 } listed
            ? listed
            : FieldTheme.Tabs(null, Find(m, "Job"), Find(m, "Asset"), Find(m, "Queue"), Find(m, "You", "More", "Setting"));
        var selected = m.SelectedTab ?? "Today";
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
                    FieldTheme.Icon(tab.Icon ?? IconName(tab.Label), 22),
                    new Label
                    {
                        Text = tab.Label,
                        FontSize = 10,
                        FontAttributes = on ? FontAttributes.Bold : FontAttributes.None,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = on ? Orange : Mute
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

    static View ActionBar(FieldModel m)
    {
        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var s = new VerticalStackLayout { BackgroundColor = Surface, Padding = new Thickness(16, 10, 16, 22), Spacing = 8 };
        if (p is not null)
        {
            s.Add(Btn(p.Label, p.Command, Orange, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)).Take(2))
        {
            s.Add(Link(extra.Label, extra.Command));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, s } };
    }

    static View Group(string title, FieldModel m, params string[] keys)
    {
        var box = new VerticalStackLayout();
        var added = 0;
        foreach (var a in m.Actions.Where(x => keys.Any(k => x.Label.Contains(k, StringComparison.OrdinalIgnoreCase))))
        {
            box.Add(FieldTheme.Tap(MenuRow(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
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
                FieldTheme.Card(box)
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
        g.Add(FieldTheme.Glyph(icon, 36));
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
            var cell = FieldTheme.Tap(FieldTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Spacing = 8,
                Children =
                {
                    FieldTheme.Glyph(item.I, 36),
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
            g.Add(Col(1, FieldTheme.Tap(new Label { Text = link, TextColor = Orange, FontSize = 13, FontAttributes = FontAttributes.Bold }, cmd)));
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
            Content = FieldTheme.Icon("icon_bell", 18)
        });
        g.Add(new Border
        {
            WidthRequest = 9,
            HeightRequest = 9,
            BackgroundColor = Orange,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 4.5 },
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 4, 4, 0)
        });
        return g;
    }

    static View SearchBox(string ph) =>
        FieldTheme.Card(new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 10,
            Children =
            {
                FieldTheme.Icon("icon_search", 18),
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
                BackgroundColor = on ? SoftOrange : Surface,
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(on ? Orange : Line),
                StrokeShape = new RoundRectangle { CornerRadius = 16 },
                Padding = new Thickness(12, 7),
                Content = new Label { Text = labels[i], FontSize = 12, TextColor = on ? Slate : Ink, FontAttributes = on ? FontAttributes.Bold : FontAttributes.None }
            });
        }

        row.Content = chips;
        return row;
    }

    static View Pill(string text, Color bg) =>
        new Border
        {
            Padding = new Thickness(10, 4),
            BackgroundColor = bg,
            StrokeThickness = 0,
            VerticalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle { CornerRadius = 10 },
            Content = new Label { Text = text, TextColor = Colors.White, FontSize = 11, FontAttributes = FontAttributes.Bold }
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
        return FieldTheme.Tap(b, cmd);
    }

    static View Link(string text, ICommand? cmd) =>
        FieldTheme.Tap(new Label { Text = text, TextColor = Orange, HorizontalTextAlignment = TextAlignment.Center, Padding = 6, FontAttributes = FontAttributes.Bold }, cmd);

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

    static ICommand? First(FieldModel m) => (m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault())?.Command;

    static ICommand? Find(FieldModel m, params string[] n) =>
        m.Actions.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command
        ?? m.Tabs?.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command;

    static ICommand? FirstFor(FieldModel m, string title)
    {
        var t = title.ToLowerInvariant();
        if (t.Contains("queue") || t.Contains("photo"))
        {
            return Find(m, "Queue") ?? First(m);
        }

        if (t.Contains("nfc") || t.Contains("scan") || t.Contains("asset"))
        {
            return Find(m, "Asset", "Scan") ?? First(m);
        }

        return Find(m, "Job") ?? First(m);
    }

    static string Greeting()
    {
        var h = DateTime.Now.Hour;
        return h < 12 ? "Good morning" : h < 17 ? "Good afternoon" : "Good evening";
    }

    static string DayLine() => $"{DateTime.Now:dddd} · Harbour district";

    static string StatusFor(string title)
    {
        var t = title.ToLowerInvariant();
        if (t.Contains("queue")) return "Queued";
        if (t.Contains("188") || t.Contains("nfc")) return "On site";
        return "Waiting";
    }

    static Color StatusColor(string status) =>
        status is "En route" or "OK" ? Go : status is "On site" or "Scheduled" ? Slate : Amber;

    static string IconName(string label)
    {
        var l = label.ToLowerInvariant();
        if (l.Contains("today") || l.Contains("home")) return "icon_home";
        if (l.Contains("job") || l.Contains("hf-") || l.Contains("inspect") || l.Contains("print")) return "icon_jobs";
        if (l.Contains("asset") || l.Contains("pump") || l.Contains("gen") || l.Contains("radio")) return "icon_asset";
        if (l.Contains("queue") || l.Contains("offline") || l.Contains("retry") || l.Contains("photo")) return "icon_queue";
        if (l.Contains("you") || l.Contains("setting") || l.Contains("crew")) return "icon_user";
        if (l.Contains("alert") || l.Contains("notify") || l.Contains("sla") || l.Contains("fence")) return "icon_bell";
        if (l.Contains("site") || l.Contains("yard") || l.Contains("pier") || l.Contains("geo")) return "icon_pin";
        if (l.Contains("route") || l.Contains("stop") || l.Contains("travel")) return "icon_route";
        if (l.Contains("scan") || l.Contains("nfc") || l.Contains("tag")) return "icon_nfc";
        if (l.Contains("safety") || l.Contains("ppe") || l.Contains("gas") || l.Contains("permit")) return "icon_safety";
        if (l.Contains("time") || l.Contains("hour")) return "icon_time";
        if (l.Contains("print") || l.Contains("zebra") || l.Contains("receipt")) return "icon_print";
        if (l.Contains("file") || l.Contains("pdf") || l.Contains("plan")) return "icon_file";
        if (l.Contains("team") || l.Contains("nia") || l.Contains("spotter")) return "icon_team";
        if (l.Contains("check")) return "icon_check";
        if (l.Contains("dash") || l.Contains("continue")) return "icon_dash";
        if (l.Contains("conflict")) return "icon_conflict";
        if (l.Contains("evidence") || l.Contains("jpg")) return "icon_camera";
        return "icon_jobs";
    }

    static string IconFor(string? kind, string title)
    {
        if (string.Equals(kind, "sites", StringComparison.OrdinalIgnoreCase) || string.Equals(kind, "geofences", StringComparison.OrdinalIgnoreCase)) return "icon_pin";
        if (string.Equals(kind, "queue", StringComparison.OrdinalIgnoreCase)) return "icon_queue";
        if (string.Equals(kind, "files", StringComparison.OrdinalIgnoreCase)) return "icon_file";
        if (string.Equals(kind, "safety", StringComparison.OrdinalIgnoreCase) || string.Equals(kind, "checklist", StringComparison.OrdinalIgnoreCase)) return "icon_safety";
        if (string.Equals(kind, "team", StringComparison.OrdinalIgnoreCase)) return "icon_team";
        if (string.Equals(kind, "notifications", StringComparison.OrdinalIgnoreCase)) return "icon_bell";
        if (string.Equals(kind, "printers", StringComparison.OrdinalIgnoreCase)) return "icon_print";
        if (string.Equals(kind, "conflicts", StringComparison.OrdinalIgnoreCase)) return "icon_conflict";
        if (string.Equals(kind, "dashboard", StringComparison.OrdinalIgnoreCase)) return "icon_dash";
        if (string.Equals(kind, "timesheet", StringComparison.OrdinalIgnoreCase)) return "icon_time";
        if (string.Equals(kind, "evidence", StringComparison.OrdinalIgnoreCase)) return "icon_camera";
        if (string.Equals(kind, "assets", StringComparison.OrdinalIgnoreCase)) return "icon_asset";
        return IconName(title);
    }
}
