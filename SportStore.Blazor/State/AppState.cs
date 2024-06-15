using Blazored.LocalStorage;
using SportStore.Domen.Models;

namespace SportStore.Blazor.State;

public class AppState
{
    private bool _isInitialized;
    public FavoriteUsersState FavoriteUsersState { get; }

    public AppState(ILocalStorageService localStorageService)
    {
        Console.WriteLine("Хранитель состояния создан!");
        FavoriteUsersState = new FavoriteUsersState(localStorageService);
    }

    public User _unsavedNewUser { get; set; } = new();
    public User GetUser() => _unsavedNewUser;
    public void SaveUser(User User) => _unsavedNewUser = User;
    public void ClearUser() => _unsavedNewUser = new();

    public async Task Initialize()
    {
        if (!_isInitialized)
        {
            await FavoriteUsersState.Initialize();
            _isInitialized = true;
        }
    }

}
