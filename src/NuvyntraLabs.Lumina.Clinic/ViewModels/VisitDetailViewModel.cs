using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("visitdetail")]
public partial class VisitDetailViewModel : PageViewModel
{

    public VisitDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPrescriptionsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrescriptionsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenDocumentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DocumentsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInvoiceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvoiceViewModel>(cancellationToken);

}
