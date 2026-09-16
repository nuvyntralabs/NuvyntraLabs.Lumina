using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("whatsnew")]
public partial class WhatsNewViewModel : PageViewModel
{

    public WhatsNewViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAboutAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AboutViewModel>(cancellationToken);

}
