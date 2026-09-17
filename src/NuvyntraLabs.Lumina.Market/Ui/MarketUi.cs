using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

/// <summary>Flipkart-inspired commerce chrome for Harbour Market. Tabs, search, and buy bars live here.</summary>
internal static class MarketUi
{
    static Color Blue => MarketTheme.Blue;
    static Color Deep => MarketTheme.Deep;
    static Color Paper => MarketTheme.Paper;
    static Color Surface => MarketTheme.Surface;
    static Color Ink => MarketTheme.Ink;
    static Color Mute => MarketTheme.Mute;
    static Color Line => MarketTheme.Line;
    static Color Buy => MarketTheme.Buy;
    static Color Amber => MarketTheme.Amber;
    static Color Star => MarketTheme.Star;
    static Color Ice => MarketTheme.Ice;

    public static View Home(MarketModel m) => Page(HomeBody(m), Dock(m), hideTitle: true);
    public static View Catalog(MarketModel m) => Page(CatalogBody(m), Dock(m), "Shop", tab: true);
    public static View Cart(MarketModel m) => Page(CartBody(m), CartDock(m), "My cart", tab: true);
    public static View Orders(MarketModel m) => Page(OrdersBody(m), Dock(m), "Orders", tab: true);
    public static View Account(MarketModel m) => Page(AccountBody(m), Dock(m), "Account", tab: true);
    public static View Product(MarketModel m) => Page(ProductBody(m), BuyBar(m), m.Title);
    public static View Search(MarketModel m) => Page(SearchBody(m), ActionBar(m), "Search");
    public static View Auth(MarketModel m) => AuthBody(m);
    public static View Walkthrough(MarketModel m) => WalkBody(m);
    public static View Chat(MarketModel m) => Page(ChatBody(m), Composer(m), m.Title);
    public static View Result(MarketModel m) => Page(ResultBody(m), ActionBar(m), m.Title);
    public static View Form(MarketModel m) => Page(FormBody(m), ActionBar(m), m.Title);
    public static View List(MarketModel m) => Page(ListBody(m), ActionBar(m), m.Title);

    static View Page(View body, View? footer, string? title = null, bool hideTitle = false, bool tab = false)
    {
        var grid = new Grid
        {
            BackgroundColor = hideTitle ? Blue : Paper,
            RowDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            SafeAreaEdges = new SafeAreaEdges(SafeAreaRegions.None, SafeAreaRegions.Container, SafeAreaRegions.None, SafeAreaRegions.None)
        };
        View header;
        if (hideTitle)
        {
            header = new BoxView { HeightRequest = 0, Color = Blue };
        }
        else
        {
            var bar = new Grid
            {
                BackgroundColor = Blue,
                Padding = new Thickness(tab ? 16 : 4, 6, 16, 10),
                MinimumHeightRequest = 48,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
            };
            if (!tab)
            {
                bar.Add(MarketTheme.BackButton());
            }

            var titleLabel = new Label
            {
                Text = title ?? "Harbour Market",
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

        var scroll = new ScrollView { Content = body, BackgroundColor = Paper };
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

    static View HomeBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Spacing = 0 };
        var hero = new Grid { BackgroundColor = Blue, Padding = new Thickness(16, 12, 16, 16) };
        var top = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto), new(GridLength.Auto) } };
        top.Add(new VerticalStackLayout
        {
            Spacing = 2,
            Children =
            {
                new Label { Text = "Deliver to", TextColor = Colors.White.WithAlpha(0.75f), FontSize = 11 },
                new HorizontalStackLayout
                {
                    Spacing = 4,
                    Children =
                    {
                        MarketTheme.Icon("icon_pin", 14),
                        new Label { Text = "Harbour Walk, London  ▾", TextColor = Colors.White, FontAttributes = FontAttributes.Bold, FontSize = 15, VerticalOptions = LayoutOptions.Center }
                    }
                }
            }
        });
        var bell = MarketTheme.Tap(IconHit("icon_bell"), Find(m, "Alert", "Notify"));
        var cart = MarketTheme.Tap(IconHit("icon_cart"), Find(m, "Cart"));
        Grid.SetColumn(bell, 1);
        Grid.SetColumn(cart, 2);
        top.Add(bell);
        top.Add(cart);
        var heroStack = new VerticalStackLayout { Spacing = 12 };
        heroStack.Add(top);
        heroStack.Add(MarketTheme.Tap(SearchBox("Search for products, brands and more"), Find(m, "Search")));
        hero.Add(heroStack);
        stack.Add(hero);

        var body = new VerticalStackLayout { BackgroundColor = Paper, Padding = new Thickness(12, 12, 12, 20), Spacing = 14 };
        body.Add(CategoryGrid(m));
        body.Add(MarketTheme.Tap(Banner(m), Find(m, "Shop", "Aisles")));
        body.Add(Section("Deals of the day", "View all", Find(m, "Shop", "Catalog")));
        body.Add(ProductGrid(m.Items.Select(GoodsFor).ToList(), Find(m, "Shop", "Aisles", "View") ?? First(m)));
        stack.Add(body);
        return stack;
    }

    static View CatalogBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 12 };
        stack.Add(MarketTheme.Tap(SearchBox("Search this aisle"), Find(m, "Search", "Filter")));
        stack.Add(FilterRow(["Sort", "Filters", "Rating 4★", "Under £80"]));
        stack.Add(ProductGrid(m.Items.Select(GoodsFor).ToList(), First(m)));
        return stack;
    }

    static View CartBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 10 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(CartLine(row.Title, row.Subtitle));
        }

        stack.Add(MarketTheme.Card(new VerticalStackLayout
        {
            Padding = 14,
            Spacing = 6,
            Children =
            {
                new Label { Text = "Price details", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                Kv("Items (3)", "£20.80"),
                Kv("Delivery", "FREE"),
                Kv("Total", "£20.80")
            }
        }, new Thickness(4)));
        return stack;
    }

    static View OrdersBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 10 };
        stack.Add(FilterRow(["All", "Packing", "Shipped", "Delivered"]));
        foreach (var row in m.Items)
        {
            var packing = row.Subtitle.Contains("Packing", StringComparison.OrdinalIgnoreCase);
            stack.Add(MarketTheme.Tap(MarketTheme.Card(new VerticalStackLayout
            {
                Padding = 14,
                Spacing = 6,
                Children =
                {
                    new Grid
                    {
                        ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) },
                        Children =
                        {
                            new Label { Text = row.Title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                            Col(1, Badge(packing ? "Packing" : "Delivered", packing ? Amber : Star))
                        }
                    },
                    new Label { Text = row.Subtitle, FontSize = 13, TextColor = Mute },
                    new Label { Text = packing ? "Track courier  ›" : "Buy again  ›", FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Blue }
                }
            }), First(m)));
        }

        return stack;
    }

    static View AccountBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 14 };
        stack.Add(MarketTheme.Card(new Grid
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
                        new Label { Text = "Aurora Plus  ·  Harbour Walk", FontSize = 13, TextColor = Mute }
                    }
                })
            }
        }));
        stack.Add(Group("Orders & wishlist", m, "Order", "Wish", "Track"));
        stack.Add(Group("Payments & address", m, "Card", "Address", "Member"));
        stack.Add(Group("Support", m, "Help", "Store", "Alert", "Notify"));
        foreach (var row in m.Items)
        {
            stack.Add(LineRow(row.Title, row.Subtitle, "icon_orders"));
        }

        return stack;
    }

    static View ProductBody(MarketModel m)
    {
        var goods = GoodsFor(new CatalogItem { Title = m.Title, Subtitle = PriceOf(m) });
        var stack = new VerticalStackLayout { Spacing = 0 };
        stack.Add(new Grid
        {
            HeightRequest = 260,
            BackgroundColor = goods.Swatch,
            Children =
            {
                new Label
                {
                    Text = goods.Mark,
                    FontSize = 42,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Colors.White.WithAlpha(0.9f),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }
            }
        });
        var copy = new VerticalStackLayout { Padding = 16, Spacing = 8, BackgroundColor = Surface };
        copy.Add(new Label { Text = goods.Name, FontSize = 20, FontAttributes = FontAttributes.Bold, TextColor = Ink });
        copy.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        copy.Add(new HorizontalStackLayout
        {
            Spacing = 10,
            Children =
            {
                Badge("★ " + goods.Rating, Star),
                new Label { Text = goods.Reviews + " ratings", TextColor = Mute, FontSize = 12, VerticalOptions = LayoutOptions.Center },
                Badge("Aurora", Blue)
            }
        });
        copy.Add(new HorizontalStackLayout
        {
            Spacing = 10,
            Children =
            {
                new Label { Text = goods.Price, FontSize = 26, FontAttributes = FontAttributes.Bold, TextColor = Ink },
                new Label
                {
                    Text = goods.Was,
                    FontSize = 14,
                    TextColor = Mute,
                    TextDecorations = TextDecorations.Strikethrough,
                    VerticalOptions = LayoutOptions.Center
                },
                new Label { Text = goods.Off, FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Star, VerticalOptions = LayoutOptions.Center }
            }
        });
        copy.Add(new Label { Text = "Inclusive of taxes  ·  Free delivery today", FontSize = 12, TextColor = Star });
        stack.Add(copy);
        if (m.Items.Count > 0)
        {
            var specs = new VerticalStackLayout { Padding = 16, Spacing = 0, BackgroundColor = Surface, Margin = new Thickness(0, 8, 0, 16) };
            specs.Add(new Label { Text = "Highlights", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink, Margin = new Thickness(0, 0, 0, 8) });
            foreach (var row in m.Items)
            {
                specs.Add(Kv(row.Title, row.Subtitle));
            }

            stack.Add(specs);
        }

        return stack;
    }

    static View SearchBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 10 };
        stack.Add(SearchBox("Search pears, oak, ramen"));
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(MarketTheme.Tap(LineRow(row.Title, row.Subtitle, "icon_search"), First(m)));
        }

        return stack;
    }

    static View ListBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 12, Spacing = 8 };
        if (!string.IsNullOrWhiteSpace(m.Subtitle))
        {
            stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        }

        foreach (var row in m.Items)
        {
            stack.Add(MarketTheme.Tap(LineRow(row.Title, row.Subtitle, IconFor(m.Kind, row.Title)), First(m)));
        }

        return stack;
    }

    static View FormBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var box = new VerticalStackLayout { Padding = 4 };
        foreach (var row in m.Items)
        {
            box.Add(Kv(row.Title, row.Subtitle));
        }

        stack.Add(MarketTheme.Card(box, new Thickness(16, 8)));
        return stack;
    }

    static View ChatBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 8 };
        foreach (var row in m.Items)
        {
            var mine = row.Title.Contains("You", StringComparison.OrdinalIgnoreCase);
            stack.Add(new Border
            {
                HorizontalOptions = mine ? LayoutOptions.End : LayoutOptions.Start,
                BackgroundColor = mine ? Color.FromArgb("#DCF8C6") : Surface,
                Padding = 14,
                StrokeThickness = 0,
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                WidthRequest = 300,
                Content = new VerticalStackLayout
                {
                    Children =
                    {
                        new Label { Text = row.Title, FontSize = 11, TextColor = Mute },
                        new Label { Text = row.Subtitle, FontSize = 14, TextColor = Ink }
                    }
                }
            });
        }

        return stack;
    }

    static View ResultBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = 24, Spacing = 12 };
        var disc = Disc("✓", 72, Star);
        disc.HorizontalOptions = LayoutOptions.Center;
        stack.Add(disc);
        stack.Add(new Label { Text = m.Title, FontSize = 22, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, HorizontalTextAlignment = TextAlignment.Center, TextColor = Mute });
        var box = new VerticalStackLayout { Padding = 4 };
        foreach (var row in m.Items)
        {
            box.Add(Kv(row.Title, row.Subtitle));
        }

        stack.Add(MarketTheme.Card(box, new Thickness(16, 8)));
        return stack;
    }

    static View AuthBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 56, 24, 24), Spacing = 14, BackgroundColor = Colors.White };
        stack.Add(MarketTheme.Glyph("icon_shop", 64, Ice));
        stack.Add(new Label { Text = "HARBOUR MARKET", FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Blue, CharacterSpacing = 1.1 });
        stack.Add(new Label { Text = m.Title, FontSize = 28, FontAttributes = FontAttributes.Bold, TextColor = Ink });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (p is not null)
        {
            stack.Add(Btn(p.Label, p.Command, Buy));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)))
        {
            stack.Add(Link(extra.Label, extra.Command));
        }

        return stack;
    }

    static View WalkBody(MarketModel m)
    {
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 64, 24, 32), Spacing = 18, BackgroundColor = Colors.White };
        stack.Add(new Label { Text = "HARBOUR MARKET", FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Blue });
        stack.Add(new Label { Text = "Groceries, home and dinner in one bag.", FontSize = 28, FontAttributes = FontAttributes.Bold, TextColor = Ink });
        var icons = new[] { "icon_shop", "icon_truck", "icon_card" };
        var i = 0;
        foreach (var row in m.Items)
        {
            stack.Add(MarketTheme.Card(new Grid
            {
                Padding = 16,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
                ColumnSpacing = 12,
                Children =
                {
                    MarketTheme.Glyph(icons[i % icons.Length], 48),
                    Col(1, new VerticalStackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Label { Text = row.Title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                            new Label { Text = row.Subtitle.Trim(), FontSize = 13, TextColor = Mute }
                        }
                    })
                }
            }));
            i++;
        }

        var go = m.Actions.FirstOrDefault();
        if (go is not null)
        {
            stack.Add(Btn(go.Label, go.Command, Buy));
        }

        return stack;
    }

    static View CategoryGrid(MarketModel m)
    {
        var aisles = new List<(string Title, string Icon, Color Fill)>();
        foreach (var row in m.Aisles.Take(4))
        {
            aisles.Add((row.Title, AisleIcon(row.Title), Ice));
        }

        aisles.AddRange(
        [
            ("Pantry", "icon_shop", Color.FromArgb("#FFF3E0")),
            ("Beauty", "icon_heart", Color.FromArgb("#FCE4EC")),
            ("Kids", "icon_star", Color.FromArgb("#E8F5E9")),
            ("More", "icon_shop", Color.FromArgb("#EDE7F6"))
        ]);
        var grid = new Grid { ColumnSpacing = 8, RowSpacing = 12 };
        for (var c = 0; c < 4; c++)
        {
            grid.ColumnDefinitions.Add(new(GridLength.Star));
        }

        grid.RowDefinitions.Add(new(GridLength.Auto));
        grid.RowDefinitions.Add(new(GridLength.Auto));
        var open = Find(m, "Aisles", "Shop");
        for (var i = 0; i < Math.Min(8, aisles.Count); i++)
        {
            var item = aisles[i];
            var cell = MarketTheme.Tap(new VerticalStackLayout
            {
                Spacing = 6,
                Children =
                {
                    MarketTheme.Glyph(item.Icon, 52, item.Fill),
                    new Label { Text = item.Title, FontSize = 11, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink, LineBreakMode = LineBreakMode.TailTruncation }
                }
            }, open);
            Grid.SetColumn(cell, i % 4);
            Grid.SetRow(cell, i / 4);
            grid.Add(cell);
        }

        return MarketTheme.Card(grid, new Thickness(12), 12);
    }

    static View ProductGrid(IReadOnlyList<Goods> items, ICommand? open)
    {
        var grid = new Grid { ColumnSpacing = 10, RowSpacing = 10 };
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        for (var i = 0; i < items.Count; i++)
        {
            if (i % 2 == 0)
            {
                grid.RowDefinitions.Add(new(GridLength.Auto));
            }

            var item = items[i];
            var card = MarketTheme.Tap(MarketTheme.Card(new VerticalStackLayout
            {
                Spacing = 6,
                Children =
                {
                    new BoxView { HeightRequest = 108, Color = item.Swatch },
                    new VerticalStackLayout
                    {
                        Padding = new Thickness(10, 0, 10, 10),
                        Spacing = 3,
                        Children =
                        {
                            new Label { Text = item.Name, FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Ink, LineBreakMode = LineBreakMode.TailTruncation },
                            new HorizontalStackLayout
                            {
                                Spacing = 6,
                                Children =
                                {
                                    new Label { Text = item.Price, FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Ink },
                                    new Label { Text = item.Off, FontSize = 11, TextColor = Star, VerticalOptions = LayoutOptions.Center }
                                }
                            },
                            new Label { Text = "★ " + item.Rating + "   Free delivery", FontSize = 11, TextColor = Star }
                        }
                    }
                }
            }, radius: 8), open);
            Grid.SetColumn(card, i % 2);
            Grid.SetRow(card, i / 2);
            grid.Add(card);
        }

        return grid;
    }

    static View Banner(MarketModel m) =>
        new Border
        {
            HeightRequest = 132,
            StrokeThickness = 0,
            BackgroundColor = Deep,
            StrokeShape = new RoundRectangle { CornerRadius = 10 },
            Padding = 16,
            Content = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.End,
                Spacing = 4,
                Children =
                {
                    new Label { Text = "SAME-DAY DROP", TextColor = Color.FromArgb("#FFD54F"), FontSize = 11, FontAttributes = FontAttributes.Bold },
                    new Label { Text = "Harbour Studio · until 19:00", TextColor = Colors.White, FontSize = 20, FontAttributes = FontAttributes.Bold },
                    new Label { Text = m.Subtitle, TextColor = Colors.White.WithAlpha(0.8f), FontSize = 13 }
                }
            }
        };

    static View CartLine(string title, string subtitle)
    {
        var g = new Grid
        {
            Padding = 12,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 12
        };
        g.Add(new Border
        {
            WidthRequest = 64,
            HeightRequest = 64,
            BackgroundColor = GoodsFor(new CatalogItem { Title = title, Subtitle = subtitle }).Swatch,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 8 }
        });
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 14, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 13, TextColor = Mute },
                new Label { Text = "Qty 1  ·  Remove", FontSize = 12, TextColor = Blue }
            }
        }));
        return MarketTheme.Card(g);
    }

    static View LineRow(string title, string subtitle, string icon)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(MarketTheme.Glyph(icon, 40));
        g.Add(Col(1, new VerticalStackLayout
        {
            Margin = new Thickness(12, 0, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = subtitle, FontSize = 12, TextColor = Mute }
            }
        }));
        g.Add(Col(2, new Label { Text = "›", FontSize = 20, TextColor = Mute, VerticalOptions = LayoutOptions.Center }));
        return MarketTheme.Card(g);
    }

    static View Dock(MarketModel m)
    {
        var tabs = m.Tabs is { Count: > 0 } listed
            ? listed
            : MarketTheme.Tabs(null, Find(m, "Shop", "Aisles"), Find(m, "Cart"), Find(m, "Order"), Find(m, "You", "Account"));
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
                    MarketTheme.Icon(tab.Icon ?? IconName(tab.Label), 22),
                    new Label
                    {
                        Text = tab.Label,
                        FontSize = 10,
                        FontAttributes = on ? FontAttributes.Bold : FontAttributes.None,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = on ? Blue : Mute
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

    static View CartDock(MarketModel m)
    {
        var go = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var pay = new Grid
        {
            BackgroundColor = Surface,
            Padding = new Thickness(16, 10, 16, 10),
            ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) }
        };
        pay.Add(new VerticalStackLayout
        {
            Children =
            {
                new Label { Text = "Total", FontSize = 11, TextColor = Mute },
                new Label { Text = "£20.80", FontSize = 18, FontAttributes = FontAttributes.Bold, TextColor = Ink }
            }
        });
        var btn = Btn(go?.Label ?? "Place order", go?.Command, Buy);
        btn.WidthRequest = 168;
        Grid.SetColumn(btn, 1);
        pay.Add(btn);
        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, pay, Dock(m) } };
    }

    static View BuyBar(MarketModel m)
    {
        var cart = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var more = m.Actions.FirstOrDefault(x => !ReferenceEquals(x, cart));
        var grid = new Grid
        {
            BackgroundColor = Surface,
            Padding = new Thickness(12, 10, 12, 20),
            ColumnDefinitions = { new(GridLength.Star), new(GridLength.Star) },
            ColumnSpacing = 10
        };
        grid.Add(Btn(more?.Label ?? "Add to cart", more?.Command, Amber));
        grid.Add(Col(1, Btn(cart?.Label ?? "Buy now", cart?.Command, Buy)));
        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, grid } };
    }

    static View ActionBar(MarketModel m)
    {
        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var s = new VerticalStackLayout { BackgroundColor = Surface, Padding = new Thickness(16, 10, 16, 22), Spacing = 8 };
        if (p is not null)
        {
            s.Add(Btn(p.Label, p.Command, Buy));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)).Take(2))
        {
            s.Add(Link(extra.Label, extra.Command));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, s } };
    }

    static View Composer(MarketModel m)
    {
        var send = m.Actions.FirstOrDefault();
        var g = new Grid
        {
            BackgroundColor = Surface,
            Padding = new Thickness(12, 8, 12, 18),
            ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) },
            ColumnSpacing = 8
        };
        g.Add(new Border
        {
            BackgroundColor = Paper,
            Padding = 12,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 18 },
            Content = new Label { Text = "Message the kitchen", TextColor = Mute }
        });
        var b = Btn("Send", send?.Command, Blue);
        b.WidthRequest = 84;
        Grid.SetColumn(b, 1);
        g.Add(b);
        return g;
    }

    static View Group(string title, MarketModel m, params string[] keys)
    {
        var box = new VerticalStackLayout();
        var added = 0;
        foreach (var a in m.Actions.Where(x => keys.Any(k => x.Label.Contains(k, StringComparison.OrdinalIgnoreCase))))
        {
            box.Add(MarketTheme.Tap(MenuRow(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
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
                MarketTheme.Card(box)
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
        g.Add(MarketTheme.Glyph(icon, 36));
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

    static View Section(string title, string? link, ICommand? cmd)
    {
        var g = new Grid { ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink });
        if (!string.IsNullOrWhiteSpace(link))
        {
            g.Add(Col(1, MarketTheme.Tap(new Label { Text = link, TextColor = Blue, FontSize = 13, FontAttributes = FontAttributes.Bold }, cmd)));
        }

        return g;
    }

    static View SearchBox(string ph) =>
        MarketTheme.Card(new Grid
        {
            Padding = new Thickness(12, 11),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 10,
            Children =
            {
                MarketTheme.Icon("icon_search", 18),
                Col(1, new Label { Text = ph, TextColor = Mute, FontSize = 14, VerticalOptions = LayoutOptions.Center })
            }
        }, radius: 6);

    static View FilterRow(string[] labels)
    {
        var row = new ScrollView { Orientation = ScrollOrientation.Horizontal, HorizontalScrollBarVisibility = ScrollBarVisibility.Never };
        var chips = new HorizontalStackLayout { Spacing = 8 };
        for (var i = 0; i < labels.Length; i++)
        {
            var on = i == 0;
            chips.Add(new Border
            {
                BackgroundColor = on ? Ice : Surface,
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(on ? Blue : Line),
                StrokeShape = new RoundRectangle { CornerRadius = 16 },
                Padding = new Thickness(12, 7),
                Content = new Label { Text = labels[i], FontSize = 12, TextColor = on ? Blue : Ink, FontAttributes = on ? FontAttributes.Bold : FontAttributes.None }
            });
        }

        row.Content = chips;
        return row;
    }

    static View IconHit(string name) =>
        new Border
        {
            WidthRequest = 40,
            HeightRequest = 40,
            BackgroundColor = Colors.White.WithAlpha(0.12f),
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 20 },
            Margin = new Thickness(6, 0, 0, 0),
            Content = MarketTheme.Icon(name, 18)
        };

    static View Badge(string text, Color bg) =>
        new Border
        {
            BackgroundColor = bg,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 4 },
            Padding = new Thickness(8, 3),
            HorizontalOptions = LayoutOptions.Start,
            Content = new Label { Text = text, FontSize = 11, FontAttributes = FontAttributes.Bold, TextColor = Colors.White }
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
                    StrokeShape = new RoundRectangle { CornerRadius = 6 },
                    Content = new Entry { Text = value, IsPassword = secret, BackgroundColor = Colors.Transparent, TextColor = Ink }
                }
            }
        };

    static View Btn(string text, ICommand? cmd, Color bg)
    {
        var b = new Border
        {
            HeightRequest = 48,
            BackgroundColor = bg,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 6 },
            Content = new Label
            {
                Text = text.ToUpperInvariant(),
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        };
        return MarketTheme.Tap(b, cmd);
    }

    static View Link(string text, ICommand? cmd) =>
        MarketTheme.Tap(new Label { Text = text, TextColor = Blue, HorizontalTextAlignment = TextAlignment.Center, Padding = 6, FontAttributes = FontAttributes.Bold }, cmd);

    static View Kv(string k, string v)
    {
        var g = new Grid { Padding = new Thickness(0, 8), ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
        g.Add(new Label { Text = k, TextColor = Mute, FontSize = 13 });
        g.Add(Col(1, new Label { Text = v, TextColor = Ink, FontAttributes = FontAttributes.Bold, FontSize = 13 }));
        return g;
    }

    static Border Disc(string text, double size, Color bg) =>
        new()
        {
            WidthRequest = size,
            HeightRequest = size,
            BackgroundColor = bg,
            StrokeThickness = 0,
            HorizontalOptions = LayoutOptions.Center,
            StrokeShape = new RoundRectangle { CornerRadius = size / 2 },
            Content = new Label { Text = text, TextColor = Colors.White, FontAttributes = FontAttributes.Bold, FontSize = size * 0.32, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center }
        };

    static View Col(int col, View v)
    {
        Grid.SetColumn(v, col);
        return v;
    }

    static ICommand? First(MarketModel m) => (m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault())?.Command;

    static ICommand? Find(MarketModel m, params string[] n) =>
        m.Actions.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command
        ?? m.Tabs?.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command;

    static string PriceOf(MarketModel m) =>
        m.Items.Select(x => x.Subtitle).FirstOrDefault(x => x.Contains('£')) ?? "£186";

    static string IconName(string label)
    {
        var l = label.ToLowerInvariant();
        if (l.Contains("home")) return "icon_home";
        if (l.Contains("shop") || l.Contains("aisle") || l.Contains("catalog")) return "icon_shop";
        if (l.Contains("cart")) return "icon_cart";
        if (l.Contains("order") || l.Contains("track")) return "icon_orders";
        if (l.Contains("you") || l.Contains("account")) return "icon_user";
        if (l.Contains("search")) return "icon_search";
        if (l.Contains("alert") || l.Contains("notify")) return "icon_bell";
        if (l.Contains("wish") || l.Contains("saved") || l.Contains("heart")) return "icon_heart";
        if (l.Contains("card") || l.Contains("pay")) return "icon_card";
        if (l.Contains("address")) return "icon_pin";
        if (l.Contains("store")) return "icon_store";
        if (l.Contains("help") || l.Contains("member")) return "icon_help";
        if (l.Contains("filter")) return "icon_filter";
        return "icon_shop";
    }

    static string IconFor(string? kind, string title)
    {
        if (string.Equals(kind, "wishlist", StringComparison.OrdinalIgnoreCase)) return "icon_heart";
        if (string.Equals(kind, "orders", StringComparison.OrdinalIgnoreCase)) return "icon_orders";
        if (string.Equals(kind, "notifications", StringComparison.OrdinalIgnoreCase)) return "icon_bell";
        if (string.Equals(kind, "addresses", StringComparison.OrdinalIgnoreCase)) return "icon_pin";
        if (string.Equals(kind, "cards", StringComparison.OrdinalIgnoreCase)) return "icon_card";
        return IconName(title);
    }

    static string AisleIcon(string title)
    {
        if (title.Contains("Produce", StringComparison.OrdinalIgnoreCase)) return "icon_star";
        if (title.Contains("Kitchen", StringComparison.OrdinalIgnoreCase) || title.Contains("eat", StringComparison.OrdinalIgnoreCase)) return "icon_shop";
        if (title.Contains("Home", StringComparison.OrdinalIgnoreCase)) return "icon_store";
        return "icon_shop";
    }

    sealed record Goods(string Name, string Price, string Was, string Off, string Rating, string Reviews, Color Swatch, string Mark);

    static Goods GoodsFor(CatalogItem row)
    {
        var name = row.Title;
        if (name.Contains("pear", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£3.40", "£4.20", "19% off", "4.6", "84", Color.FromArgb("#C8E6C9"), "🍐");
        }

        if (name.Contains("chair", StringComparison.OrdinalIgnoreCase) || name.Contains("lounge", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£186", "£240", "22% off", "4.8", "216", Color.FromArgb("#D7CCC8"), "🪑");
        }

        if (name.Contains("ramen", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£14", "£16", "12% off", "4.7", "128", Color.FromArgb("#FFE0B2"), "🍜");
        }

        if (name.Contains("lamp", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£42", "£55", "23% off", "4.5", "61", Color.FromArgb("#BBDEFB"), "💡");
        }

        if (name.Contains("mug", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£18", "£22", "18% off", "4.4", "40", Color.FromArgb("#F8BBD0"), "☕");
        }

        if (name.Contains("throw", StringComparison.OrdinalIgnoreCase) || name.Contains("linen", StringComparison.OrdinalIgnoreCase))
        {
            return new(name, "£64", "£80", "20% off", "4.9", "73", Color.FromArgb("#D1C4E9"), "🧺");
        }

        return new(name, row.Subtitle.Contains('£') ? row.Subtitle.Split('·')[0].Trim() : row.Subtitle, "", "", "4.5", "24", Color.FromArgb("#BBDEFB"), name[..1]);
    }
}
