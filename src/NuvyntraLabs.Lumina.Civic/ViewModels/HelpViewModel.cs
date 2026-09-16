using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("help")]
public partial class HelpViewModel : PageViewModel
{

    public HelpViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenFaqAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<FaqViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenContactAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ContactViewModel>(cancellationToken);

}
