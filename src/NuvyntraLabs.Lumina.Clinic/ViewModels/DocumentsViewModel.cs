using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("documents")]
public partial class DocumentsViewModel : PageViewModel
{

    public DocumentsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenVisitDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<VisitDetailViewModel>(cancellationToken);

}
