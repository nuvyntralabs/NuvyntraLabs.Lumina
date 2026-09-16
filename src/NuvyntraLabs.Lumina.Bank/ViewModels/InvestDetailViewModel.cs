using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("investdetail")]
public partial class InvestDetailViewModel : PageViewModel
{

    public InvestDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenInvestAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvestViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenStatementsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StatementsViewModel>(cancellationToken);

}
