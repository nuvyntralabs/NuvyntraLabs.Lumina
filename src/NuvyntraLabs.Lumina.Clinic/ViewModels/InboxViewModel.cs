using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("inbox")]
public partial class InboxViewModel : PageViewModel
{

    public InboxViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenConversationAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ConversationViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInCallAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InCallViewModel>(cancellationToken);

}
