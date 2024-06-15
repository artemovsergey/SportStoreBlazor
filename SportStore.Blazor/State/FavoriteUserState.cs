using Blazored.LocalStorage;
using SportStore.Domen.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace SportStore.Blazor.State;

public class FavoriteUsersState
{
    private const string FavouriteUsersKey = "favoriteUsers";
    private bool _isInitialized;
    private List<User> _favoriteUsers = new();
    private readonly ILocalStorageService _localStorageService;
    public IReadOnlyList<User> FavoriteUsers => _favoriteUsers.AsReadOnly();
 
    public event Action? OnChange;
    public FavoriteUsersState(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public async Task Initialize()
    {
        if (!_isInitialized)
        {
            _favoriteUsers = await _localStorageService.GetItemAsync<List<User>>(FavouriteUsersKey)?? new List<User>();
            _isInitialized = true;
            NotifyStateHasChanged();
        }
    }
    public async Task AddFavorite(User User)
    {
        if (_favoriteUsers.Any(_ => _.Id == User.Id)) return;
        _favoriteUsers.Add(User);
        await _localStorageService.SetItemAsync(FavouriteUsersKey, _favoriteUsers);
        NotifyStateHasChanged();
    }
    public async Task RemoveFavorite(User User)
    {
        var existingUser = _favoriteUsers.SingleOrDefault(_ => _.Id == User.Id);
        if (existingUser is null) return;
        _favoriteUsers.Remove(existingUser);
        await _localStorageService.SetItemAsync(FavouriteUsersKey, _favoriteUsers);
        NotifyStateHasChanged();
    }
    public bool IsFavorite(User User) => _favoriteUsers.Any(_ => _.Id == User.Id);
    private void NotifyStateHasChanged() => OnChange?.Invoke();
}
