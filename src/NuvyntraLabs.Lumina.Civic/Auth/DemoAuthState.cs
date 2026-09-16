using System.ComponentModel;
using Plugin.Maui.MVVMExpress.Auth;
using Result = Plugin.Maui.MVVMExpress.Outcome.Outcome;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class DemoAuthState : IAuthState, INotifyPropertyChanged
{
    public const string DemoPassword = "secret";

    public bool IsAuthenticated { get; private set; }
    public string? UserName { get; private set; }
    public string? Email { get; private set; }
    public string? DisplayName => UserName;
    public event EventHandler? Changed;
    public event PropertyChangedEventHandler? PropertyChanged;

    public Task<Result> SignInAsync(string userName, string password, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (password != DemoPassword)
        {
            return Task.FromResult(Result.Failure("E_AUTH", "Invalid credentials — use password secret"));
        }

        IsAuthenticated = true;
        UserName = userName.Trim();
        Email = UserName.Contains('@', StringComparison.Ordinal) ? UserName : null;
        Raise();
        return Task.FromResult(Result.Success());
    }

    public Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IsAuthenticated = false;
        UserName = null;
        Email = null;
        Raise();
        return Task.CompletedTask;
    }

    void Raise()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthenticated)));
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
