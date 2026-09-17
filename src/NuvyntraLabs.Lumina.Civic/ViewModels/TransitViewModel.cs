using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("transit")]
public partial class TransitViewModel : PageViewModel
{
    public TransitViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {
    }

    [AsyncModelCommand]
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<ServicesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<TransitViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenWalletAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<WalletViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTicketDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TicketDetailViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);
}
