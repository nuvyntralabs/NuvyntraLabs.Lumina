using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

/// <summary>Practo-inspired care chrome for Nuvexa Clinic. Tabs, search, and booking live here.</summary>
internal static class ClinicUi
{
    static Color Teal => ClinicTheme.Teal;
    static Color Deep => ClinicTheme.Deep;
    static Color Mint => ClinicTheme.Mint;
    static Color Paper => ClinicTheme.Paper;
    static Color Surface => ClinicTheme.Surface;
    static Color Ink => ClinicTheme.Ink;
    static Color Mute => ClinicTheme.Mute;
    static Color Line => ClinicTheme.Line;
    static Color Amber => ClinicTheme.Amber;
    static Color Success => ClinicTheme.Success;
    static Color Coral => ClinicTheme.Coral;

    public static View Home(ClinicModel m) => Page(HomeBody(m), Dock(m), hideTitle: true);
    public static View Doctors(ClinicModel m) => Page(DoctorList(m), Dock(m), "Doctors", tab: true);
    public static View Visits(ClinicModel m) => Page(VisitsBody(m), Dock(m), "Appointments", tab: true);
    public static View Records(ClinicModel m) => Page(RecordsBody(m), Dock(m), "Records", tab: true);
    public static View Account(ClinicModel m) => Page(AccountBody(m), Dock(m), "Account", tab: true);
    public static View Profile(ClinicModel m) => Page(ProfileBody(m), BookBar(m), m.Title);
    public static View Booking(ClinicModel m) => Page(BookingBody(m), ActionBar(m), "Book appointment");
    public static View Auth(ClinicModel m) => AuthBody(m);
    public static View Walkthrough(ClinicModel m) => WalkBody(m);
    public static View Chat(ClinicModel m) => Page(ChatBody(m), Composer(m), m.Title);
    public static View Inbox(ClinicModel m) => Page(InboxBody(m), ActionBar(m), m.Title);
    public static View Call(ClinicModel m) => CallBody(m);
    public static View Form(ClinicModel m) => Page(FormBody(m), ActionBar(m), m.Title);
    public static View Detail(ClinicModel m) => Page(DetailBody(m), ActionBar(m), m.Title);
    public static View List(ClinicModel m) => Page(ListBody(m), ActionBar(m), m.Title);

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
            header = new BoxView { HeightRequest = 0, Color = Deep };
        }
        else
        {
            var bar = new Grid
            {
                BackgroundColor = Surface,
                Padding = new Thickness(tab ? 16 : 4, 6, 16, 10),
                MinimumHeightRequest = 48,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
            };
            if (!tab)
            {
                bar.Add(ClinicTheme.BackButton());
            }

            var titleLabel = new Label
            {
                Text = title ?? "Nuvexa Clinic",
                TextColor = Ink,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(tab ? 0 : 4, 0, 0, 0)
            };
            Grid.SetColumn(titleLabel, tab ? 0 : 1);
            if (tab)
            {
                Grid.SetColumnSpan(titleLabel, 3);
            }

            bar.Add(titleLabel);
            header = new VerticalStackLayout { Children = { bar, new BoxView { HeightRequest = 1, Color = Line } } };
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

    static View HomeBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Spacing = 0 };
        var hero = new Grid
        {
            BackgroundColor = Deep,
            Padding = new Thickness(20, 14, 20, 28)
        };
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
                        ClinicTheme.Icon("icon_pin", 14),
                        new Label { Text = "Harbour, London", TextColor = Colors.White.WithAlpha(0.8f), FontSize = 12, VerticalOptions = LayoutOptions.Center }
                    }
                },
                new Label { Text = $"{Greeting()}, Ada", TextColor = Colors.White, FontSize = 22, FontAttributes = FontAttributes.Bold },
                new Label { Text = "Find doctors, clinics and labs", TextColor = Colors.White.WithAlpha(0.7f), FontSize = 13 }
            }
        });
        var bell = ClinicTheme.Tap(Bell(), Find(m, "Alert", "Notify"));
        Grid.SetColumn(bell, 1);
        top.Add(bell);
        hero.Add(top);
        stack.Add(hero);

        var body = new VerticalStackLayout { BackgroundColor = Paper, Padding = new Thickness(16, 0, 16, 20), Spacing = 14, Margin = new Thickness(0, -16, 0, 0) };
        body.Add(ClinicTheme.Tap(SearchBox("Search symptoms, doctors, specialties"), Find(m, "Doctor")));
        body.Add(ServiceGrid(m));
        body.Add(Section("Specialties", "See all", Find(m, "Doctor")));
        body.Add(SpecialtyRow(m));

        var next = m.Items.FirstOrDefault();
        if (next is not null)
        {
            body.Add(Section("Upcoming appointment", "All visits", Find(m, "Visit", "Appoint")));
            body.Add(ClinicTheme.Tap(ApptCard(next.Title, next.Subtitle, upcoming: true), Find(m, "Visit", "Appoint")));
        }

        body.Add(Section("Doctors near you", "View all", Find(m, "Doctor")));
        foreach (var doc in FeaturedDoctors())
        {
            body.Add(ClinicTheme.Tap(DoctorCard(doc), Find(m, "Doctor")));
        }

        stack.Add(body);
        return stack;
    }

    static View DoctorList(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(ClinicTheme.Tap(SearchBox("Doctors, clinics, hospitals"), Find(m, "Doctor", "Book")));
        stack.Add(FilterRow());
        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Tap(DoctorCard(DoctorFor(row.Title, row.Subtitle)), First(m)));
        }

        return stack;
    }

    static View VisitsBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        stack.Add(ChipRow(["Upcoming", "Past"], 0));
        var first = true;
        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Tap(ApptCard(row.Title, row.Subtitle, upcoming: first), Find(m, "Visit") ?? First(m)));
            first = false;
        }

        var book = Find(m, "Book");
        if (book is not null)
        {
            stack.Add(ClinicTheme.Tap(ClinicTheme.Card(new VerticalStackLayout
            {
                Padding = 16,
                Spacing = 6,
                Children =
                {
                    new Label { Text = "Need a new slot?", FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                    new Label { Text = "Book a clinic visit or video consult.", FontSize = 13, TextColor = Mute }
                }
            }), book));
        }

        return stack;
    }

    static View RecordsBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(VitalsStrip(m));
        stack.Add(Section("Lab reports", "All", First(m)));
        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Tap(RecordRow(row.Title, row.Subtitle, "icon_lab"), First(m)));
        }

        stack.Add(Section("Health files", null, null));
        stack.Add(ShortcutGrid(
        [
            ("Prescriptions", "icon_pill", Find(m, "Prescription")),
            ("Documents", "icon_doc", Find(m, "Document")),
            ("Pharmacy", "icon_clinic", Find(m, "Pharmacy")),
            ("Medications", "icon_pill", Find(m, "Medication"))
        ]));
        return stack;
    }

    static View AccountBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(ClinicTheme.Card(new Grid
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
                        new Label { Text = "O+  ·  Harbour Plus  ·  36", FontSize = 13, TextColor = Mute }
                    }
                })
            }
        }));
        stack.Add(Group("Your care", m, "Health", "Vital", "Insurance"));
        stack.Add(Group("Records", m, "Lab", "Prescription", "Document", "Pharmacy", "Medication"));
        stack.Add(Group("Support", m, "Inbox", "Help", "Alert", "Notify", "Department"));
        foreach (var row in m.Items)
        {
            stack.Add(RecordRow(row.Title, row.Subtitle, "icon_records"));
        }

        return stack;
    }

    static View ProfileBody(ClinicModel m)
    {
        var doc = DoctorFor(m.Title, m.Subtitle);
        var stack = new VerticalStackLayout { Spacing = 0 };
        stack.Add(new VerticalStackLayout
        {
            BackgroundColor = Surface,
            Padding = new Thickness(20, 16, 20, 20),
            Spacing = 10,
            Children =
            {
                Disc(doc.Initials, 84, Teal),
                new Label { Text = doc.Name, FontSize = 22, FontAttributes = FontAttributes.Bold, TextColor = Ink, HorizontalTextAlignment = TextAlignment.Center },
                new Label { Text = $"{doc.Specialty}  ·  {doc.Years} years experience", FontSize = 14, TextColor = Mute, HorizontalTextAlignment = TextAlignment.Center },
                new Label { Text = doc.Clinic, FontSize = 13, TextColor = Teal, HorizontalTextAlignment = TextAlignment.Center },
                Stars(doc.Rating, doc.Stories)
            }
        });
        var stats = new Grid { Padding = new Thickness(16, 12), ColumnSpacing = 8 };
        stats.ColumnDefinitions.Add(new(GridLength.Star));
        stats.ColumnDefinitions.Add(new(GridLength.Star));
        stats.ColumnDefinitions.Add(new(GridLength.Star));
        stats.Add(StatTile("£" + doc.Fee, "Consult"));
        stats.Add(Col(1, StatTile(doc.Next, "Next slot")));
        stats.Add(Col(2, StatTile(doc.Rating, "Rating")));
        stack.Add(stats);

        var about = new VerticalStackLayout { BackgroundColor = Surface, Margin = new Thickness(0, 4, 0, 0), Padding = 16, Spacing = 0 };
        about.Add(new Label { Text = "About", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink, Margin = new Thickness(0, 0, 0, 8) });
        about.Add(new Label
        {
            Text = $"{doc.Name} sees patients at {doc.Clinic}. Languages and next available slot are below.",
            FontSize = 14,
            TextColor = Mute,
            Margin = new Thickness(0, 0, 0, 8)
        });
        foreach (var row in m.Items)
        {
            about.Add(Kv(row.Title, row.Subtitle));
        }

        stack.Add(about);
        stack.Add(new VerticalStackLayout
        {
            BackgroundColor = Surface,
            Margin = new Thickness(0, 8, 0, 16),
            Padding = 16,
            Spacing = 10,
            Children =
            {
                new Label { Text = "Today's slots", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                ChipRow(["09:30", "10:15", "11:00", "14:20", "16:45"], 0)
            }
        });
        return stack;
    }

    static View BookingBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 14 };
        stack.Add(ClinicTheme.Card(new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 4,
            Children =
            {
                new Label { Text = "Dr. Priya Iyer", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                new Label { Text = "Cardiology  ·  Harbour Heart  ·  £85", FontSize = 13, TextColor = Mute }
            }
        }));
        stack.Add(new Label { Text = "Pick a day", FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink });
        stack.Add(DateStrip());
        stack.Add(new Label { Text = "Morning", FontAttributes = FontAttributes.Bold, FontSize = 14, TextColor = Ink });
        stack.Add(ChipRow(["09:00", "09:30", "10:15", "11:00"], 1));
        stack.Add(new Label { Text = "Afternoon", FontAttributes = FontAttributes.Bold, FontSize = 14, TextColor = Ink });
        stack.Add(ChipRow(["14:00", "14:20", "16:45", "17:30"], -1));
        var box = new VerticalStackLayout { Padding = 4 };
        foreach (var row in m.Items)
        {
            box.Add(Kv(row.Title, row.Subtitle));
        }

        stack.Add(ClinicTheme.Card(box, new Thickness(16, 8)));
        return stack;
    }

    static View ListBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        if (!string.IsNullOrWhiteSpace(m.Subtitle))
        {
            stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        }

        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Tap(RecordRow(row.Title, row.Subtitle, IconFor(m.Kind, row.Title)), First(m)));
        }

        return stack;
    }

    static View FormBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 13, TextColor = Mute });
        var box = new VerticalStackLayout { Padding = 4 };
        foreach (var row in m.Items)
        {
            box.Add(Kv(row.Title, row.Subtitle));
        }

        stack.Add(ClinicTheme.Card(box, new Thickness(16, 8)));
        return stack;
    }

    static View DetailBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 12 };
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, TextColor = Mute });
        if (string.Equals(m.Kind, "vitals", StringComparison.OrdinalIgnoreCase))
        {
            var row = new Grid { ColumnSpacing = 8 };
            var i = 0;
            foreach (var item in m.Items.Take(3))
            {
                row.ColumnDefinitions.Add(new(GridLength.Star));
                var tile = StatTile(item.Subtitle, item.Title);
                Grid.SetColumn(tile, i++);
                row.Add(tile);
            }

            stack.Add(row);
            return stack;
        }

        var box = new VerticalStackLayout();
        foreach (var item in m.Items)
        {
            box.Add(Kv(item.Title, item.Subtitle));
        }

        stack.Add(ClinicTheme.Card(box, new Thickness(16, 8)));
        return stack;
    }

    static View InboxBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 10 };
        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Tap(RecordRow(row.Title, row.Subtitle, "icon_chat"), First(m)));
        }

        return stack;
    }

    static View ChatBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = 16, Spacing = 8 };
        foreach (var row in m.Items)
        {
            var mine = row.Title.Contains("You", StringComparison.OrdinalIgnoreCase) || row.Title.Contains("Ada", StringComparison.OrdinalIgnoreCase);
            stack.Add(Bubble(row.Title, row.Subtitle, mine));
        }

        return stack;
    }

    static View AuthBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 56, 24, 24), Spacing = 14, BackgroundColor = Colors.White };
        stack.Add(ClinicTheme.Glyph("icon_plus", 64, Mint));
        stack.Add(new Label { Text = "NUVEXA CLINIC", FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Teal, CharacterSpacing = 1.2 });
        stack.Add(new Label { Text = m.Title, FontSize = 28, FontAttributes = FontAttributes.Bold, TextColor = Ink });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 14, TextColor = Mute });
        foreach (var row in m.Items)
        {
            stack.Add(Field(row.Title, row.Subtitle, row.Title.Contains("password", StringComparison.OrdinalIgnoreCase)));
        }

        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        if (p is not null)
        {
            stack.Add(Btn(p.Label, p.Command, Teal, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)))
        {
            stack.Add(Link(extra.Label, extra.Command));
        }

        return stack;
    }

    static View WalkBody(ClinicModel m)
    {
        var stack = new VerticalStackLayout { Padding = new Thickness(24, 64, 24, 32), Spacing = 18, BackgroundColor = Colors.White };
        stack.Add(new Label { Text = "Care that feels close.", FontSize = 30, FontAttributes = FontAttributes.Bold, TextColor = Deep });
        stack.Add(new Label { Text = m.Subtitle, FontSize = 15, TextColor = Mute });
        var icons = new[] { "icon_doctor", "icon_records", "icon_video" };
        var i = 0;
        foreach (var row in m.Items)
        {
            stack.Add(ClinicTheme.Card(new Grid
            {
                Padding = 16,
                ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
                ColumnSpacing = 12,
                Children =
                {
                    ClinicTheme.Glyph(icons[i % icons.Length], 48),
                    Col(1, new VerticalStackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Label { Text = row.Title, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink },
                            new Label { Text = row.Subtitle, FontSize = 13, TextColor = Mute }
                        }
                    })
                }
            }));
            i++;
        }

        var go = m.Actions.FirstOrDefault();
        if (go is not null)
        {
            stack.Add(Btn(go.Label, go.Command, Teal, Colors.White));
        }

        return stack;
    }

    static View CallBody(ClinicModel m)
    {
        var peer = m.Items.FirstOrDefault(x => x.Title.Contains("Peer", StringComparison.OrdinalIgnoreCase))?.Subtitle ?? "Dr. Iyer";
        var quality = m.Items.FirstOrDefault(x => x.Title.Contains("Quality", StringComparison.OrdinalIgnoreCase))?.Subtitle ?? "Good";
        var duration = m.Items.FirstOrDefault(x => x.Title.Contains("Duration", StringComparison.OrdinalIgnoreCase))?.Subtitle ?? "00:12:04";
        var root = new Grid { BackgroundColor = Color.FromArgb("#0B1C1B") };
        var stack = new VerticalStackLayout
        {
            Padding = new Thickness(24, 72, 24, 32),
            Spacing = 16,
            VerticalOptions = LayoutOptions.Center
        };
        stack.Add(new Label { Text = "Video consult", TextColor = Colors.White.WithAlpha(0.65f), FontSize = 13, HorizontalTextAlignment = TextAlignment.Center });
        var disc = Disc(Initials(peer), 104, Teal);
        disc.HorizontalOptions = LayoutOptions.Center;
        stack.Add(disc);
        stack.Add(new Label { Text = peer, TextColor = Colors.White, FontSize = 24, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center });
        stack.Add(new Label { Text = $"On hold  ·  {quality}  ·  {duration}", TextColor = Colors.White.WithAlpha(0.65f), HorizontalTextAlignment = TextAlignment.Center });
        var go = m.Actions.FirstOrDefault();
        if (go is not null)
        {
            stack.Add(Btn("Leave room", go.Command, Coral, Colors.White));
        }

        root.Add(stack);
        return root;
    }

    static View ServiceGrid(ClinicModel m)
    {
        var tiles = new (string Label, string Hint, string Icon, Color Fill, ICommand? Cmd)[]
        {
            ("Video consult", "Talk now", "icon_video", Color.FromArgb("#FFE8E4"), Find(m, "Call", "Inbox", "Video")),
            ("Find doctors", "Book a slot", "icon_doctor", Mint, Find(m, "Doctor")),
            ("Medicines", "Harbour Rx", "icon_pill", Color.FromArgb("#FFF3DC"), Find(m, "Pharmacy")),
            ("Lab tests", "Home collection", "icon_lab", Color.FromArgb("#E8F0FF"), Find(m, "Lab", "Record"))
        };
        var grid = new Grid { ColumnSpacing = 10, RowSpacing = 10 };
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.ColumnDefinitions.Add(new(GridLength.Star));
        grid.RowDefinitions.Add(new(GridLength.Auto));
        grid.RowDefinitions.Add(new(GridLength.Auto));
        for (var i = 0; i < tiles.Length; i++)
        {
            var t = tiles[i];
            var cell = ClinicTheme.Tap(ClinicTheme.Card(new VerticalStackLayout
            {
                Padding = 14,
                Spacing = 8,
                Children =
                {
                    ClinicTheme.Glyph(t.Icon, 44, t.Fill),
                    new Label { Text = t.Label, FontAttributes = FontAttributes.Bold, FontSize = 14, TextColor = Ink },
                    new Label { Text = t.Hint, FontSize = 12, TextColor = Mute }
                }
            }), t.Cmd);
            Grid.SetColumn(cell, i % 2);
            Grid.SetRow(cell, i / 2);
            grid.Add(cell);
        }

        return grid;
    }

    static View SpecialtyRow(ClinicModel m)
    {
        var specs = new (string Name, string Icon)[]
        {
            ("Heart", "icon_heart"),
            ("Physio", "icon_physio"),
            ("GP", "icon_doctor"),
            ("Labs", "icon_lab"),
            ("Skin", "icon_skin"),
            ("Dental", "icon_tooth"),
            ("Child", "icon_child"),
            ("Mind", "icon_mind")
        };
        var row = new ScrollView { Orientation = ScrollOrientation.Horizontal, HorizontalScrollBarVisibility = ScrollBarVisibility.Never };
        var chips = new HorizontalStackLayout { Spacing = 12 };
        var open = Find(m, "Doctor");
        foreach (var spec in specs)
        {
            chips.Add(ClinicTheme.Tap(new VerticalStackLayout
            {
                Spacing = 6,
                WidthRequest = 68,
                Children =
                {
                    ClinicTheme.Glyph(spec.Icon, 56),
                    new Label { Text = spec.Name, FontSize = 11, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink }
                }
            }, open));
        }

        row.Content = chips;
        return row;
    }

    static View DoctorCard(Doc doc)
    {
        var grid = new Grid
        {
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 12,
            Padding = 14
        };
        grid.Add(Disc(doc.Initials, 58, Teal));
        var copy = new VerticalStackLayout { Spacing = 3 };
        copy.Add(new Label { Text = doc.Name, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Ink });
        copy.Add(new Label { Text = $"{doc.Specialty}  ·  {doc.Years} yrs exp", FontSize = 13, TextColor = Mute });
        copy.Add(new Label { Text = doc.Clinic, FontSize = 12, TextColor = Mute });
        copy.Add(Stars(doc.Rating, doc.Stories));
        copy.Add(new HorizontalStackLayout
        {
            Spacing = 10,
            Margin = new Thickness(0, 4, 0, 0),
            Children =
            {
                new Label { Text = $"£{doc.Fee} consult", FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Ink, VerticalOptions = LayoutOptions.Center },
                Badge(doc.Available ? "Available today" : "Next " + doc.Next, doc.Available)
            }
        });
        copy.Add(new Label { Text = "Book clinic visit  ›", FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Teal, Margin = new Thickness(0, 4, 0, 0) });
        Grid.SetColumn(copy, 1);
        grid.Add(copy);
        return ClinicTheme.Card(grid);
    }

    static View ApptCard(string when, string who, bool upcoming)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 12
        };
        g.Add(new Border
        {
            WidthRequest = 64,
            BackgroundColor = upcoming ? Mint : Paper,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 12 },
            Padding = new Thickness(6, 10),
            Content = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label { Text = when.Contains(' ') ? when.Split(' ')[0] : "Thu", FontSize = 12, TextColor = Teal, HorizontalTextAlignment = TextAlignment.Center },
                    new Label { Text = when.Contains(' ') ? when.Split(' ').Last() : when, FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Deep, HorizontalTextAlignment = TextAlignment.Center }
                }
            }
        });
        g.Add(Col(1, new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Spacing = 3,
            Children =
            {
                new Label { Text = who, FontAttributes = FontAttributes.Bold, FontSize = 15, TextColor = Ink },
                new Label { Text = "Harbour Clinic  ·  Floor 3", FontSize = 12, TextColor = Mute },
                Badge(upcoming ? "Confirmed" : "Completed", upcoming)
            }
        }));
        return ClinicTheme.Card(g);
    }

    static View RecordRow(string title, string subtitle, string icon)
    {
        var g = new Grid
        {
            Padding = 14,
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star), new(GridLength.Auto) }
        };
        g.Add(ClinicTheme.Glyph(icon, 42));
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
        return ClinicTheme.Card(g);
    }

    static View VitalsStrip(ClinicModel m)
    {
        var grid = new Grid { ColumnSpacing = 8 };
        var tiles = new (string V, string K)[] { ("118/74", "BP"), ("72", "HR"), ("64.2", "kg") };
        for (var i = 0; i < tiles.Length; i++)
        {
            grid.ColumnDefinitions.Add(new(GridLength.Star));
            grid.Add(Col(i, StatTile(tiles[i].V, tiles[i].K)));
        }

        _ = m;
        return grid;
    }

    static View ShortcutGrid((string Label, string Icon, ICommand? Cmd)[] items)
    {
        var grid = new Grid { ColumnSpacing = 8 };
        for (var i = 0; i < items.Length; i++)
        {
            grid.ColumnDefinitions.Add(new(GridLength.Star));
            var item = items[i];
            var cell = ClinicTheme.Tap(ClinicTheme.Card(new VerticalStackLayout
            {
                Padding = 12,
                Spacing = 8,
                Children =
                {
                    ClinicTheme.Glyph(item.Icon, 40),
                    new Label { Text = item.Label, FontSize = 11, HorizontalTextAlignment = TextAlignment.Center, TextColor = Ink }
                }
            }), item.Cmd);
            Grid.SetColumn(cell, i);
            grid.Add(cell);
        }

        return grid;
    }

    static View Dock(ClinicModel m)
    {
        var tabs = m.Tabs is { Count: > 0 } listed
            ? listed
            : ClinicTheme.Tabs(null, Find(m, "Doctor"), Find(m, "Visit", "Appoint"), Find(m, "Lab", "Record"), Find(m, "You", "Account"));
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
                    ClinicTheme.Icon(tab.Icon ?? IconName(tab.Label), 22),
                    new Label
                    {
                        Text = tab.Label,
                        FontSize = 10,
                        FontAttributes = on ? FontAttributes.Bold : FontAttributes.None,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = on ? Teal : Mute
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

    static View BookBar(ClinicModel m)
    {
        var book = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var video = m.Actions.FirstOrDefault(x => !ReferenceEquals(x, book));
        var row = new Grid
        {
            BackgroundColor = Surface,
            Padding = new Thickness(16, 10, 16, 20),
            ColumnDefinitions = { new(GridLength.Star), new(GridLength.Star) },
            ColumnSpacing = 10
        };
        row.Add(Btn(book?.Label ?? "Book clinic visit", book?.Command, Teal, Colors.White));
        if (video is not null)
        {
            row.Add(Col(1, Btn(video.Label, video.Command, Mint, Deep)));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, row } };
    }

    static View ActionBar(ClinicModel m)
    {
        var p = m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault();
        var s = new VerticalStackLayout { BackgroundColor = Surface, Padding = new Thickness(16, 10, 16, 22), Spacing = 8 };
        if (p is not null)
        {
            s.Add(Btn(p.Label, p.Command, Teal, Colors.White));
        }

        foreach (var extra in m.Actions.Where(x => !ReferenceEquals(x, p)).Take(2))
        {
            s.Add(Link(extra.Label, extra.Command));
        }

        return new VerticalStackLayout { Children = { new BoxView { HeightRequest = 1, Color = Line }, s } };
    }

    static View Composer(ClinicModel m)
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
            Content = new Label { Text = "Message your doctor", TextColor = Mute }
        });
        var b = Btn("Send", send?.Command, Teal, Colors.White);
        b.WidthRequest = 84;
        Grid.SetColumn(b, 1);
        g.Add(b);
        return g;
    }

    static View Group(string title, ClinicModel m, params string[] keys)
    {
        var box = new VerticalStackLayout();
        var added = 0;
        foreach (var a in m.Actions.Where(x => keys.Any(k => x.Label.Contains(k, StringComparison.OrdinalIgnoreCase))))
        {
            box.Add(ClinicTheme.Tap(MenuRow(a.Label, a.Hint ?? "Open", a.Icon ?? IconName(a.Label)), a.Command));
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
                ClinicTheme.Card(box)
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
        g.Add(ClinicTheme.Glyph(icon, 36));
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
            g.Add(Col(1, ClinicTheme.Tap(new Label { Text = link, TextColor = Teal, FontSize = 13, FontAttributes = FontAttributes.Bold }, cmd)));
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
            Content = ClinicTheme.Icon("icon_bell", 18)
        });
        g.Add(new Border
        {
            WidthRequest = 9,
            HeightRequest = 9,
            BackgroundColor = Coral,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 4.5 },
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 4, 4, 0)
        });
        return g;
    }

    static View SearchBox(string ph) =>
        ClinicTheme.Card(new Grid
        {
            Padding = new Thickness(14, 12),
            ColumnDefinitions = { new(GridLength.Auto), new(GridLength.Star) },
            ColumnSpacing = 10,
            Children =
            {
                ClinicTheme.Icon("icon_search", 18),
                Col(1, new Label { Text = ph, TextColor = Mute, FontSize = 14, VerticalOptions = LayoutOptions.Center })
            }
        });

    static View FilterRow() =>
        ChipRow(["Available today", "Video", "£60 max", "Harbour"], 0);

    static View DateStrip()
    {
        var days = new[] { ("Thu", "18"), ("Fri", "19"), ("Sat", "20"), ("Sun", "21"), ("Mon", "22") };
        var row = new HorizontalStackLayout { Spacing = 8 };
        for (var i = 0; i < days.Length; i++)
        {
            var on = i == 0;
            row.Add(new Border
            {
                WidthRequest = 58,
                BackgroundColor = on ? Teal : Surface,
                StrokeThickness = on ? 0 : 1,
                Stroke = new SolidColorBrush(Line),
                StrokeShape = new RoundRectangle { CornerRadius = 12 },
                Padding = new Thickness(6, 10),
                Content = new VerticalStackLayout
                {
                    Children =
                    {
                        new Label { Text = days[i].Item1, FontSize = 11, TextColor = on ? Colors.White : Mute, HorizontalTextAlignment = TextAlignment.Center },
                        new Label { Text = days[i].Item2, FontSize = 16, FontAttributes = FontAttributes.Bold, TextColor = on ? Colors.White : Ink, HorizontalTextAlignment = TextAlignment.Center }
                    }
                }
            });
        }

        return row;
    }

    static View ChipRow(string[] labels, int selected)
    {
        var row = new ScrollView { Orientation = ScrollOrientation.Horizontal, HorizontalScrollBarVisibility = ScrollBarVisibility.Never };
        var chips = new HorizontalStackLayout { Spacing = 8 };
        for (var i = 0; i < labels.Length; i++)
        {
            var on = i == selected;
            chips.Add(new Border
            {
                BackgroundColor = on ? Mint : Surface,
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(on ? Teal : Line),
                StrokeShape = new RoundRectangle { CornerRadius = 16 },
                Padding = new Thickness(12, 7),
                Content = new Label { Text = labels[i], FontSize = 12, TextColor = on ? Deep : Ink, FontAttributes = on ? FontAttributes.Bold : FontAttributes.None }
            });
        }

        row.Content = chips;
        return row;
    }

    static View Stars(string rating, string stories) =>
        new HorizontalStackLayout
        {
            Spacing = 6,
            Children =
            {
                new Label { Text = "★ " + rating, FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Amber },
                new Label { Text = stories + " patient stories", FontSize = 12, TextColor = Mute, VerticalOptions = LayoutOptions.Center }
            }
        };

    static View Badge(string text, bool ok) =>
        new Border
        {
            BackgroundColor = ok ? Mint : Paper,
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = 8 },
            Padding = new Thickness(8, 3),
            HorizontalOptions = LayoutOptions.Start,
            Content = new Label { Text = text, FontSize = 11, FontAttributes = FontAttributes.Bold, TextColor = ok ? Success : Mute }
        };

    static View StatTile(string value, string label) =>
        ClinicTheme.Card(new VerticalStackLayout
        {
            Padding = 12,
            Children =
            {
                new Label { Text = value, FontAttributes = FontAttributes.Bold, FontSize = 16, TextColor = Deep, HorizontalTextAlignment = TextAlignment.Center },
                new Label { Text = label, FontSize = 11, TextColor = Mute, HorizontalTextAlignment = TextAlignment.Center }
            }
        });

    static View Bubble(string who, string text, bool mine)
    {
        var bg = mine ? Teal : Surface;
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
                    new Label { Text = who, FontSize = 11, TextColor = mine ? Colors.White.WithAlpha(0.75f) : Mute },
                    new Label { Text = text, FontSize = 14, TextColor = fg }
                }
            }
        };
    }

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
        return ClinicTheme.Tap(b, cmd);
    }

    static View Link(string text, ICommand? cmd) =>
        ClinicTheme.Tap(new Label { Text = text, TextColor = Teal, HorizontalTextAlignment = TextAlignment.Center, Padding = 6, FontAttributes = FontAttributes.Bold }, cmd);

    static View Kv(string k, string v)
    {
        var g = new Grid { Padding = new Thickness(0, 10), ColumnDefinitions = { new(GridLength.Star), new(GridLength.Auto) } };
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
            Content = new Label
            {
                Text = text,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = size * 0.32,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }
        };

    static View Col(int col, View v)
    {
        Grid.SetColumn(v, col);
        return v;
    }

    static ICommand? First(ClinicModel m) => (m.Actions.FirstOrDefault(x => x.Primary) ?? m.Actions.FirstOrDefault())?.Command;

    static ICommand? Find(ClinicModel m, params string[] n) =>
        m.Actions.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command
        ?? m.Tabs?.FirstOrDefault(x => n.Any(s => x.Label.Contains(s, StringComparison.OrdinalIgnoreCase)))?.Command;

    static string Greeting()
    {
        var h = DateTime.Now.Hour;
        return h < 12 ? "Good morning" : h < 17 ? "Good afternoon" : "Good evening";
    }

    static string Initials(string v)
    {
        var p = v.Replace("Dr.", "", StringComparison.OrdinalIgnoreCase).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return p.Length >= 2 ? $"{p[0][0]}{p[^1][0]}" : v[..Math.Min(2, v.Length)];
    }

    static string IconName(string label)
    {
        var l = label.ToLowerInvariant();
        if (l.Contains("home")) return "icon_home";
        if (l.Contains("doctor") || l.Contains("clinician")) return "icon_doctor";
        if (l.Contains("visit") || l.Contains("appoint") || l.Contains("book")) return "icon_calendar";
        if (l.Contains("record") || l.Contains("lab")) return "icon_lab";
        if (l.Contains("you") || l.Contains("account") || l.Contains("health")) return "icon_user";
        if (l.Contains("alert") || l.Contains("notify")) return "icon_bell";
        if (l.Contains("inbox") || l.Contains("chat") || l.Contains("message")) return "icon_chat";
        if (l.Contains("video") || l.Contains("call")) return "icon_video";
        if (l.Contains("pharmacy") || l.Contains("prescription") || l.Contains("medication") || l.Contains("pill")) return "icon_pill";
        if (l.Contains("document") || l.Contains("invoice")) return "icon_doc";
        if (l.Contains("insurance")) return "icon_shield";
        if (l.Contains("help") || l.Contains("faq")) return "icon_help";
        if (l.Contains("vital")) return "icon_heart";
        if (l.Contains("department") || l.Contains("clinic")) return "icon_clinic";
        return "icon_records";
    }

    static string IconFor(string? kind, string title)
    {
        if (string.Equals(kind, "pharmacy", StringComparison.OrdinalIgnoreCase)) return "icon_pill";
        if (string.Equals(kind, "prescriptions", StringComparison.OrdinalIgnoreCase)) return "icon_pill";
        if (string.Equals(kind, "labs", StringComparison.OrdinalIgnoreCase)) return "icon_lab";
        if (string.Equals(kind, "documents", StringComparison.OrdinalIgnoreCase)) return "icon_doc";
        if (string.Equals(kind, "notifications", StringComparison.OrdinalIgnoreCase)) return "icon_bell";
        if (string.Equals(kind, "medications", StringComparison.OrdinalIgnoreCase)) return "icon_pill";
        if (string.Equals(kind, "departments", StringComparison.OrdinalIgnoreCase)) return "icon_clinic";
        if (string.Equals(kind, "inbox", StringComparison.OrdinalIgnoreCase)) return "icon_chat";
        return IconName(title);
    }

    sealed record Doc(string Name, string Specialty, string Years, string Rating, string Stories, string Fee, string Clinic, string Next, bool Available, string Initials);

    static IEnumerable<Doc> FeaturedDoctors() =>
    [
        DoctorFor("Dr. Priya Iyer", "Cardiology · 4.9"),
        DoctorFor("Lin Park", "Physio · 4.8")
    ];

    static Doc DoctorFor(string name, string meta)
    {
        if (name.Contains("Iyer", StringComparison.OrdinalIgnoreCase))
        {
            return new("Dr. Priya Iyer", "Cardiology", "12", "4.9", "214", "85", "Harbour Heart, 3F", "Thu 09:30", true, "PI");
        }

        if (name.Contains("Park", StringComparison.OrdinalIgnoreCase))
        {
            return new("Lin Park", "Physiotherapy", "8", "4.8", "96", "60", "Harbour Physio, G", "Mon 14:00", true, "LP");
        }

        if (name.Contains("Adeyemi", StringComparison.OrdinalIgnoreCase) || name.Contains("Noah", StringComparison.OrdinalIgnoreCase))
        {
            return new("Noah Adeyemi", "General Practice", "15", "4.7", "340", "45", "Harbour GP, 1F", "Fri 11:00", false, "NA");
        }

        var bits = meta.Split('·', StringSplitOptions.TrimEntries);
        return new(name, bits.ElementAtOrDefault(0) ?? "Clinic", "8", bits.ElementAtOrDefault(1) ?? "4.8", "40", "70", "Harbour Clinic", "Tomorrow", true, Initials(name));
    }
}
