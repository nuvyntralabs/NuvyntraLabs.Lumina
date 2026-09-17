using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

/// <summary>Retail-bank chrome for Aether. Tabs, pay hub, and More live here.</summary>
internal static class BankUi
{
    static Color Burgundy => BankTheme.Burgundy;
    static Color Wine => BankTheme.Wine;
    static Color Gold => BankTheme.Gold;
    static Color SoftGold => BankTheme.SoftGold;
    static Color Paper => BankTheme.Paper;
    static Color Surface => BankTheme.Surface;
    static Color Ink => BankTheme.Ink;
    static Color Mute => BankTheme.Mute;
    static Color Line => BankTheme.Line;
    static Color Credit => BankTheme.Credit;

    public static View Dashboard(BankModel m) => Page(DashBody(m), Dock(m), hideTitle: true);
    public static View Accounts(BankModel m) => Page(AccountList(m), Dock(m), "Accounts", tab: true);
    public static View Cards(BankModel m) => Page(CardDeck(m), Dock(m), "Cards", tab: true);
    public static View Pay(BankModel m) => Page(PayBody(m), Dock(m), "Pay", tab: true);
    public static View More(BankModel m) => Page(MoreBody(m), Dock(m), "More", tab: true);
    public static View Auth(BankModel m) => AuthBody(m);
    public static View Lock(BankModel m) => LockBody(m);
    public static View Form(BankModel m) => Page(FormBody(m), ActionBar(m), m.Title);
    public static View Detail(BankModel m) => Page(DetailBody(m), ActionBar(m), m.Title);
    public static View List(BankModel m) => Page(ListBody(m), ActionBar(m), m.Title);
    public static View Inbox(BankModel m) => Page(InboxBody(m), ActionBar(m), m.Title);

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
            header = new BoxView { HeightRequest = 0, Color = Burgundy };
        }
        else
        {
            var bar = new Grid
            {
                BackgroundColor = Burgundy,
                Padding = new Thickness(tab ? 16 : 4, 6, 16, 8),
                MinimumHeightRequest = 48,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
            };
            if (!tab)
            {
                bar.Add(BankTheme.BackButton());
            }

            var titleLabel = new Label
            {
                Text = title ?? "Aether",
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

    static View DashBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Spacing = 0 };
        var hero = new Grid
        {
            BackgroundColor = Burgundy,
            Padding = new Thickness(20, 12, 20, 20)
        };
        var top = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto), new(GridLength.Auto) } };
        top.Add(new VerticalStackLayout
        {
            Spacing = 2,
            Children =
            {
                new Label { Text = Greeting(), TextColor = Colors.White.WithAlpha(0.75f), FontSize = 13 },
                new Label { Text = "Ada Cole", TextColor = Colors.White, FontSize = 22, FontAttributes = FontAttributes.Bold }
            }
        });
        var bell = BankTheme.Tap(Bell(), Find(m, "Alerts", "Notify"));
        Grid.SetColumn(bell, 1);
        var avatar = BankTheme.Tap(new Image { Source = "avatar_ada.png", WidthRequest = 40, HeightRequest = 40, Margin = new Thickness(10, 0, 0, 0) }, Find(m, "You", "More"));
        Grid.SetColumn(avatar, 2);
        top.Add(bell);
        top.Add(avatar);

        var heroStack = new VerticalStackLayout { Spacing = 10 };
        heroStack.Add(top);
        heroStack.Add(new Label { Text = "Total available", TextColor = Gold, FontSize = 12, Margin = new Thickness(0, 14, 0, 0) });
        heroStack.Add(new Label { Text = "£23,252.20", TextColor = Colors.White, FontSize = 36, FontAttributes = FontAttributes.Bold });
        heroStack.Add(new Label { Text = "Current · Savings · USD travel", TextColor = Colors.White.WithAlpha(0.65f), FontSize = 12 });
        heroStack.Add(QuickActions(m));
        hero.Add(heroStack);
        stack.Add(hero);

        var body = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        body.Add(SpendCard());
        body.Add(Section("Accounts", "See all", Find(m, "Account")));
        foreach (var row in m.Items.Where(x => x.Group is "Dashboard" or "Accounts").Take(3))
        {
            body.Add(BankTheme.Tap(AccountTile(row.Title, row.Subtitle, AccountIcon(row.Title)), Find(m, "Account")));
        }

        body.Add(Section("Recent activity", "Statements", Find(m, "Statement")));
        foreach (var txn in Activity())
        {
            body.Add(Txn(txn.Name, txn.When, txn.Amount, txn.Icon));
        }

        stack.Add(body);
        return stack;
    }

    static View AccountList(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        stack.Add(BankTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 4,
            Children =
            {
                new Label { Text = "Across sterling books", FontSize = 12, TextColor = Mute },
                new Label { Text = "£23,252.20", FontSize = 26, FontAttributes = FontAttributes.Bold, TextColor = Ink }
            }
        }, new Thickness(16)));
        foreach (var row in m.Items)
        {
            stack.Add(BankTheme.Tap(AccountTile(row.Title, row.Subtitle, AccountIcon(row.Title), "Available"), First(m)));
        }

        return stack;
    }

    static View CardDeck(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 16 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var i = 0;
        foreach (var row in m.Items)
        {
            stack.Add(BankTheme.Tap(Plastic(row.Title, row.Subtitle, i++ == 0), First(m)));
        }

        stack.Add(Hint("Tap a card for limits, freeze, and PIN."));
        return stack;
    }

    static View PayBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(new Label { Text = "Move money", FontAttributes = FontAttributes.Bold, FontSize = 20, TextColor = Ink });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var grid = new Grid { ColumnSpacing = 10, RowSpacing = 10 };
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        var tiles = new (string L, string H, string I, ICommand? C)[]
        {
            ("Send", "UK payee", "icon_send", Find(m, "Payee", "Send")),
            ("Bills", "Due soon", "icon_bill", Find(m, "Bill")),
            ("International", "SWIFT / IBAN", "icon_globe", Find(m, "Beneficiar")),
            ("Scan", "Pay by QR", "icon_scan", Find(m, "Payee"))
        };
        for (var i = 0; i < tiles.Length; i++)
        {
            var t = tiles[i];
            var cell = BankTheme.Tap(BankTheme.Card(new VerticalStackLayout
            {
                Padding = 14,
                Spacing = 8,
                Children =
                {
                    BankTheme.Glyph(t.I, 40),
                    new Label { Text = t.L, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                    new Label { Text = t.H, FontSize = 11, TextColor = Mute }
                }
            }, new Thickness(0)), t.C);
            Grid.SetColumn(cell, i % 2);
            Grid.SetRow(cell, i / 2);
            if (i % 2 == 0)
            {
                grid.RowDefinitions.Add(new(GridLength.Auto));
            }

            grid.Add(cell);
        }

        stack.Add(grid);
        stack.Add(new Label { Text = "New transfer", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink, Margin = new Thickness(0, 8, 0, 0) });
        var box = new VerticalStackLayout { Spacing = 0 };
        foreach (var row in m.Items)
        {
            box.Add(Field(row.Title, row.Subtitle, false));
        }

        stack.Add(BankTheme.Card(box, new Thickness(12)));
        return stack;
    }

    static View MoreBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(BankTheme.Tap(BankTheme.Card(new Grid
        {
            Padding = 16,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            Children =
            {
                new Image { Source = "avatar_ada.png", WidthRequest = 56, HeightRequest = 56 },
                Col(1, new VerticalStackLayout
                {
                    Margin = new Thickness(12, 0, 0, 0),
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Ada Cole", FontAttributes = FontAttributes.Bold, FontSize = 18, TextColor = Ink },
                        new Label { Text = "Member ··4418  ·  Premier", FontSize = 12, TextColor = Mute }
                    }
                }),
                Col(2, new Label { Text = "›", FontSize = 22, TextColor = Mute, VerticalOptions = LayoutOptions.Center })
            }
        }), Find(m, "Verify", "Kyc")));

        stack.Add(Group("Money", m, "Account", "Card", "Send", "Bill", "Payee", "Beneficiar"));
        stack.Add(Group("Grow", m, "Invest", "Loan", "Reward"));
        stack.Add(Group("Documents", m, "Statement", "Invoice"));
        stack.Add(Group("Security", m, "Lock", "Verify", "Kyc"));
        stack.Add(Group("Help", m, "Support", "Alert", "Notify"));

        if (m.Items.Count > 0)
        {
            stack.Add(new Label { Text = "Preferences", FontAttributes = FontAttributes.Bold, FontSize = 13, TextColor = Mute, Margin = new Thickness(4, 8, 0, 0) });
            foreach (var row in m.Items)
            {
                stack.Add(KvRow(row.Title, row.Subtitle));
            }
        }

        return stack;
    }

    static View DetailBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var box = new VerticalStackLayout();
        foreach (var row in m.Items)
        {
            box.Add(KvRow(row.Title, row.Subtitle));
        }

        stack.Add(BankTheme.Card(box));
        if (string.Equals(m.Kind, "account", StringComparison.OrdinalIgnoreCase))
        {
            stack.Add(new Label { Text = "Recent on this book", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink, Margin = new Thickness(0, 8, 0, 0) });
            foreach (var txn in Activity().Take(3))
            {
                stack.Add(Txn(txn.Name, txn.When, txn.Amount, txn.Icon));
            }
        }

        return stack;
    }

    static View ListBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(BankTheme.Tap(PersonRow(row.Title, row.Subtitle, IconFor(m.Kind, row.Title)), First(m)));
        }

        return stack;
    }

    static View FormBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var box = new VerticalStackLayout { Padding = 4 };
        foreach (var row in m.Items)
        {
            box.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        stack.Add(BankTheme.Card(box, new Thickness(12)));
        return stack;
    }

    static View InboxBody(BankModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var mine = false;
        foreach (var row in m.Items)
        {
            stack.Add(Bubble(row.Title, row.Subtitle, mine));
            mine = !mine;
        }

        return stack;
    }

    static View AuthBody(BankModel m)
    {
        var root = new Grid
        {
            BackgroundColor = Burgundy,
            SafeAreaEdges = new SafeAreaEdges(SafeAreaRegions.None, SafeAreaRegions.Container, SafeAreaRegions.None, SafeAreaRegions.None)
        };
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 28, 24, 32), Spacing = 14 };
        stack.Add(new Image { Source = "logo_aether.png", WidthRequest = 56, HeightRequest = 56, HorizontalOptions = LayoutOptions.Start });
        stack.Add(new Label { Text = "AETHER BANK", TextColor = Gold, FontSize = 12, FontAttributes = FontAttributes.Bold, CharacterSpacing = 1.4 });
        stack.Add(new Label { Text = m.Title, TextColor = Colors.White, FontSize = 30, FontAttributes = FontAttributes.Bold });
        stack.Add(new Label { Text = m.Subtitle, TextColor = Colors.White.WithAlpha(0.72f), FontSize = 14 });
        foreach (var row in m.Items)
        {
            stack.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase), light: true));
        }

        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (p is not null)
        {
            stack.Add(Btn(p.Label, p.Command, Gold, Ink));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)))
        {
            stack.Add(BankTheme.Tap(new HorizontalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 8,
                Padding = 8,
                Children =
                {
                    BankTheme.Icon(extra.Icon ?? "icon_shield", 18),
                    new Label { Text = extra.Label, TextColor = Colors.White, VerticalOptions = LayoutOptions.Center }
                }
            }, extra.Command));
        }

        stack.Add(new Label
        {
            Text = "Demo password  ·  secret",
            TextColor = Colors.White.WithAlpha(0.45f),
            FontSize = 11,
            HorizontalTextAlignment = TextAlignment.Center,
            Margin = new Thickness(0, 12, 0, 0)
        });
        root.Add(stack);
        return root;
    }

    static View LockBody(BankModel m)
    {
        var stack = new VerticalStackLayout
        {
            Padding = new Thickness(24, 28, 24, 24),
            Spacing = 16,
            BackgroundColor = Burgundy,
            SafeAreaEdges = new SafeAreaEdges(SafeAreaRegions.None, SafeAreaRegions.Container, SafeAreaRegions.None, SafeAreaRegions.None)
        };
        stack.Add(new Image { Source = "logo_aether.png", WidthRequest = 48, HeightRequest = 48, HorizontalOptions = LayoutOptions.Center });
        stack.Add(new Label { Text = "AETHER", TextColor = Gold, HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Bold, CharacterSpacing = 2 });
        stack.Add(new Label { Text = m.Title, TextColor = Colors.White, FontSize = 24, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new Label { Text = m.Subtitle, TextColor = Colors.White.WithAlpha(0.7f), HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 12,
            Children = { PinDot(), PinDot(), PinDot(), PinDot(), PinDot(), PinDot() }
        });
        var keys = new Grid { RowSpacing = 12, ColumnSpacing = 12 };
        for (var c = 0; c < 3; c++)
        {
            keys.ColumnDefinitions.Add(new(GridLength.Star));
        }

        var labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "", "0", "⌫" };
        for (var i = 0; i < labels.Length; i++)
        {
            if (i % 3 == 0)
            {
                keys.RowDefinitions.Add(new(GridLength.Auto));
            }

            var key = new Border
            {
                HeightRequest = 58,
                BackgroundColor = Colors.White.WithAlpha(0.08f),
                StrokeThickness = 0,
                StrokeShape = new RoundRectangle { CornerRadius = 29 },
                Content = new Label { Text = labels[i], TextColor = Colors.White, FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }
            };
            Grid.SetColumn(key, i % 3);
            Grid.SetRow(key, i / 3);
            keys.Add(key);
        }

        stack.Add(keys);
        var go = m.Actions.FirstOrDefault();
        if (go is not null)
        {
            stack.Add(Btn(go.Label, go.Command, Gold, Ink));
        }

        return stack;
    }

    static View QuickActions(BankModel m)
    {
        var acts = m.Actions.Where(a => a.Icon is not null || IsQuick(a.Label)).Take(4).ToList();
        if (acts.Count == 0)
        {
            acts = m.Actions.Take(4).ToList();
        }

        var row = new Grid { Margin = new Thickness(0, 16, 0, 0), ColumnSpacing = 8 };
        for (var i = 0; i < acts.Count; i++)
        {
            row.ColumnDefinitions.Add(new(GridLength.Star));
            var a = acts[i];
            var cell = BankTheme.Tap(new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 6,
                Children =
                {
                    new Border
                    {
                        WidthRequest = 52,
                        HeightRequest = 52,
                        BackgroundColor = Colors.White.WithAlpha(0.12f),
                        StrokeThickness = 0,
                        StrokeShape = new RoundRectangle { CornerRadius = 26 },
                        Content = BankTheme.Icon(a.Icon ?? IconName(a.Label), 22)
                    },
                    new Label { Text = a.Label, TextColor = Colors.White, FontSize = 11, HorizontalTextAlignment = TextAlignment.Center }
                }
            }, a.Command);
            Grid.SetColumn(cell, i);
            row.Add(cell);
        }

        return row;
    }

    static View Plastic(string title, string meta, bool gold)
    {
        var face = new Grid { HeightRequest = 196 };
        var bg = new Border
        {
            BackgroundColor = gold ? Wine : Burgundy,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 18 },
            Padding = 20
        };
        var inner = new Grid { RowDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) } };
        var top = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        top.Add(new Label { Text = "AETHER", TextColor = Gold, FontSize = 13, FontAttributes = FontAttributes.Bold, CharacterSpacing = 1.2 });
        var contact = BankTheme.Icon("icon_contactless", 22);
        Grid.SetColumn(contact, 1);
        top.Add(contact);
        inner.Add(top);
        var mid = new HorizontalStackLayout
        {
            Spacing = 10,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                BankTheme.Icon("icon_chip", 28),
                new Label { Text = title, TextColor = Colors.White, FontSize = 18, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center }
            }
        };
        Grid.SetRow(mid, 1);
        inner.Add(mid);
        var bottom = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        bottom.Add(new VerticalStackLayout
        {
            Children =
            {
                new Label { Text = meta, TextColor = Colors.White.WithAlpha(0.8f), FontSize = 14 },
                new Label { Text = gold ? "DEBIT  ·  VALID 09/28" : "METAL  ·  LOCKED", TextColor = Colors.White.WithAlpha(0.5f), FontSize = 11 }
            }
        });
        var badge = new Label { Text = gold ? "Active" : "Frozen", TextColor = gold ? SoftGold : Colors.White, FontSize = 11, VerticalOptions = LayoutOptions.End };
        Grid.SetColumn(badge, 1);
        bottom.Add(badge);
        Grid.SetRow(bottom, 2);
        inner.Add(bottom);
        bg.Content = inner;
        face.Add(bg);
        return face;
    }

    static View AccountTile(string title, string value, string icon, string hint = "Available")
    {
        var g = new Grid
        {
            Padding = 16,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(BankTheme.Glyph(icon, 44));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = hint, FontSize = 11, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = value, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink, HorizontalTextAlignment = TextAlignment.End },
                new Label { Text = "›", FontSize = 16, TextColor = Mute, HorizontalTextAlignment = TextAlignment.End }
            }
        }));
        return BankTheme.Card(g);
    }

    static View Txn(string name, string when, string amt, string icon)
    {
        var g = new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(BankTheme.Glyph(icon, 40, Color.FromArgb("#F3EBE4")));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = name, FontSize = 14, TextColor = Ink, FontAttributes = FontAttributes.Bold },
                new Label { Text = when, FontSize = 11, TextColor = Mute }
            }
        }));
        var a = new Label
        {
            Text = amt,
            FontSize = 14,
            FontAttributes = FontAttributes.Bold,
            TextColor = amt.StartsWith('+') ? Credit : Ink,
            VerticalOptions = LayoutOptions.Center
        };
        Grid.SetColumn(a, 2);
        g.Add(a);
        return BankTheme.Card(g);
    }

    static View PersonRow(string title, string value, string icon)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(BankTheme.Glyph(icon, 42));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = value, FontSize = 12, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new Label { Text = "›", FontSize = 20, TextColor = Mute, VerticalOptions = LayoutOptions.Center }));
        return BankTheme.Card(g);
    }

    static View SpendCard()
    {
        var bar = new Grid { HeightRequest = 8, BackgroundColor = Line };
        var fill = new BoxView { Color = Gold, HorizontalOptions = LayoutOptions.Start, WidthRequest = 168, HeightRequest = 8 };
        bar.Add(new Border { StrokeThickness = 0, StrokeShape = new RoundRectangle { CornerRadius = 4 }, Content = fill });
        return BankTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 8,
            Children =
            {
                new Label { Text = "Spent this month", FontSize = 12, TextColor = Mute },
                new Label { Text = "£842.60  of  £2,000", FontAttributes = FontAttributes.Bold, FontSize = 18, TextColor = Ink },
                bar,
                new Label { Text = "Groceries · Travel · Council", FontSize = 11, TextColor = Mute }
            }
        }, new Thickness(16));
    }

    static View Dock(BankModel m)
    {
        var tabs = m.Tabs is { Count: > 0 } listed
            ? listed
            : BankTheme.Tabs(null, Find(m, "Account"), Find(m, "Send", "Pay", "Transfer"), Find(m, "Card"), Find(m, "More", "You"));
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
                    BankTheme.Icon(tab.Icon ?? IconName(tab.Label), 22),
                    new Label
                    {
                        Text = tab.Label,
                        FontSize = 10,
                        FontAttributes = on ? FontAttributes.Bold : FontAttributes.None,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = on ? Burgundy : Mute
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

    static View ActionBar(BankModel m)
    {
        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var s = new VerticalStackLayout { BackgroundColor = Surface, Padding = new Thickness(16, 10, 16, 22), Spacing = 8 };
        if (p is not null)
        {
            s.Add(Btn(p.Label, p.Command, Burgundy, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)).Take(2))
        {
            s.Add(BankTheme.Tap(new Label { Text = extra.Label, TextColor = Burgundy, HorizontalTextAlignment = TextAlignment.Center, Padding = 6, FontAttributes = FontAttributes.Bold }, extra.Command));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, s } };
    }

    static View Group(string title, BankModel m, params string[] keys)
    {
        var box = new VerticalStackLayout();
        var added = 0;
        foreach (var a in m.Actions.Where(x => keys.Any(k => x.Label.Contains(k, StringComparison.OrdinalIgnoreCase))))
        {
            box.Add(BankTheme.Tap(MenuRow(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
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
                BankTheme.Card(box)
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
        g.Add(BankTheme.Glyph(icon, 36));
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

    static View Section(string title, string link, ICommand? cmd)
    {
        var g = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink });
        g.Add(Col(1, BankTheme.Tap(new Label { Text = link, TextColor = Burgundy, FontSize = 13, FontAttributes = FontAttributes.Bold }, cmd)));
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
            Content = BankTheme.Icon("icon_bell", 18)
        });
        g.Add(new Border
        {
            WidthRequest = 9,
            HeightRequest = 9,
            BackgroundColor = Gold,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 4.5 },
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 4, 4, 0)
        });
        return g;
    }

    static View Bubble(string who, string text, bool mine)
    {
        var bg = mine ? Burgundy : Surface;
        var fg = mine ? Colors.White : Ink;
        return new Border
        {
            BackgroundColor = bg,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 16 },
            Padding = 14,
            HorizontalOptions = mine ? LayoutOptions.End : LayoutOptions.Start,
            WidthRequest = 300,
            Content = new VerticalStackLayout
            {
                Children =
                {
                    new Label { Text = who, FontSize = 11, TextColor = mine ? Gold : Mute },
                    new Label { Text = text, FontSize = 14, TextColor = fg }
                }
            }
        };
    }

    static View Field(string label, string value, bool secret, bool light = false) =>
        new VerticalStackLayout
        {
            Spacing = 6,
            Padding = new Thickness(0, 6),
            Children =
            {
                new Label { Text = label, FontSize = 12, TextColor = light ? Colors.White.WithAlpha(0.7f) : Mute },
                new Border
                {
                    BackgroundColor = light ? Colors.White.WithAlpha(0.1f) : Paper,
                    StrokeThickness = light ? 0 : 1,
                    Stroke = new SolidColorBrush(Line),
                    Padding = new Thickness(12, 10),
                    StrokeShape = new RoundRectangle { CornerRadius = 10 },
                    Content = new Entry { Text = value, IsPassword = secret, TextColor = light ? Colors.White : Ink, BackgroundColor = Colors.Transparent }
                }
            }
        };

    static View Btn(string text, ICommand? cmd, Color bg, Color fg)
    {
        var b = new Border
        {
            HeightRequest = 52,
            BackgroundColor = bg,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 12 },
            Content = new Label { Text = text, TextColor = fg, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }
        };
        return BankTheme.Tap(b, cmd);
    }

    static View KvRow(string k, string v)
    {
        var g = new Grid { Padding = new Thickness(16, 12), ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = k, TextColor = Mute, FontSize = 13 });
        g.Add(Col(1, new Label { Text = v, TextColor = Ink, FontAttributes = FontAttributes.Bold, FontSize = 13 }));
        return g;
    }

    static View Hint(string t) => new Label { Text = t, FontSize = 12, TextColor = Mute, Margin = new Thickness(4, 0, 4, 0) };
    static View PinDot() => new Border { WidthRequest = 12, HeightRequest = 12, BackgroundColor = Colors.White.WithAlpha(0.35f), StrokeThickness = 0, StrokeShape = new RoundRectangle { CornerRadius = 6 } };
    static View Col(int col, View v) { Grid.SetColumn(v, col); return v; }

    static ICommand? First(BankModel m) => (m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault())?.Command;
    static ICommand? Find(BankModel m, params string[] n) =>
        m.Actions.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command
        ?? m.Tabs?.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command;

    static bool IsQuick(string label) =>
        label is "Send" or "Cards" or "Invest" or "Bills" or "Rewards" or "Payees";

    static string IconName(string label)
    {
        var l = label.ToLowerInvariant();
        if (l.Contains("home")) return "icon_home";
        if (l.Contains("account")) return "icon_wallet";
        if (l.Contains("card")) return "icon_card";
        if (l.Contains("send") || l.Contains("pay") || l.Contains("transfer")) return "icon_send";
        if (l.Contains("bill")) return "icon_bill";
        if (l.Contains("invest")) return "icon_chart";
        if (l.Contains("reward")) return "icon_gift";
        if (l.Contains("loan")) return "icon_loan";
        if (l.Contains("statement") || l.Contains("invoice")) return "icon_statement";
        if (l.Contains("lock") || l.Contains("pin")) return "icon_shield";
        if (l.Contains("support")) return "icon_support";
        if (l.Contains("kyc") || l.Contains("verify")) return "icon_kyc";
        if (l.Contains("beneficiar") || l.Contains("people")) return "icon_globe";
        if (l.Contains("payee")) return "icon_people";
        if (l.Contains("alert") || l.Contains("notify")) return "icon_bell";
        if (l.Contains("scan")) return "icon_scan";
        if (l.Contains("more") || l.Contains("you")) return "icon_more";
        return "icon_wallet";
    }

    static string AccountIcon(string title)
    {
        if (title.Contains("USD", StringComparison.OrdinalIgnoreCase) || title.Contains("travel", StringComparison.OrdinalIgnoreCase)) return "icon_globe";
        if (title.Contains("Saving", StringComparison.OrdinalIgnoreCase)) return "icon_gift";
        return "icon_wallet";
    }

    static string IconFor(string? kind, string title)
    {
        if (string.Equals(kind, "bills", StringComparison.OrdinalIgnoreCase)) return "icon_bill";
        if (string.Equals(kind, "payees", StringComparison.OrdinalIgnoreCase)) return "icon_people";
        if (string.Equals(kind, "beneficiaries", StringComparison.OrdinalIgnoreCase)) return "icon_globe";
        if (string.Equals(kind, "statements", StringComparison.OrdinalIgnoreCase)) return "icon_statement";
        if (string.Equals(kind, "invest", StringComparison.OrdinalIgnoreCase)) return "icon_chart";
        if (string.Equals(kind, "loans", StringComparison.OrdinalIgnoreCase)) return "icon_loan";
        if (string.Equals(kind, "rewards", StringComparison.OrdinalIgnoreCase)) return "icon_gift";
        if (string.Equals(kind, "notifications", StringComparison.OrdinalIgnoreCase)) return "icon_bell";
        return IconName(title);
    }

    static string Greeting()
    {
        var h = DateTime.Now.Hour;
        return h < 12 ? "Good morning" : h < 17 ? "Good afternoon" : "Good evening";
    }

    static IEnumerable<(string Name, string When, string Amount, string Icon)> Activity() =>
    [
        ("Harbour Market", "Today · Groceries", "− £20.80", "merchant_shop"),
        ("Padhy Studio", "Today · Salary", "+ £3,200.00", "merchant_salary"),
        ("Council tax", "10 Sep · Bills", "− £142.00", "merchant_tax"),
        ("Aurora Coffee", "9 Sep · Card", "− £4.60", "merchant_coffee")
    ];
}
