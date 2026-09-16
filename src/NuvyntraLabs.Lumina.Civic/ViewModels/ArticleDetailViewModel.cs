using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("articledetail")]
public partial class ArticleDetailViewModel : PageViewModel
{

    public ArticleDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenNewsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NewsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransitViewModel>(cancellationToken);

}
