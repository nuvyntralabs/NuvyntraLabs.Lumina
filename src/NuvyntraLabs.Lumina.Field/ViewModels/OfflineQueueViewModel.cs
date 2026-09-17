using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("offlinequeue")]
public partial class OfflineQueueViewModel : PageViewModel
{
    public OfflineQueueViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {
    }

    [AsyncModelCommand]
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<JobsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAssetsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<AssetsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenOfflineQueueAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<OfflineQueueViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenConflictsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ConflictsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenEvidenceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EvidenceViewModel>(cancellationToken);
}
