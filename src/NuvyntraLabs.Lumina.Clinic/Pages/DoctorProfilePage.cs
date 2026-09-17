using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DoctorProfilePage : ContentPage
{
    public DoctorProfilePage(DoctorProfileViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Dr. Priya Iyer";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Profile(new ClinicModel
        {
            Title = "Dr. Priya Iyer",
            Subtitle = "Cardiology at Harbour Heart.",
            Items = SeedRows.For(ClinicSeed.Items, "DoctorProfile"),
            Kind = "profile",
            Actions =
            [
                new ClinicNav("Book clinic visit", vm.OpenBookingCommand, true, "icon_calendar"),
                new ClinicNav("Video consult", vm.OpenInCallCommand, false, "icon_video"),
                new ClinicNav("Inbox", vm.OpenInboxCommand, false, "icon_chat")
            ]
        });
    }
}
