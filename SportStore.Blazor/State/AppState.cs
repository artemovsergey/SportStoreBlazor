using SportStore.Domen.Models;

namespace SportStore.Blazor.State;

public class AppState
{

    public AppState()
    {
        Console.WriteLine("Хранитель состояния создан!");
    }

    public User _unsavedNewUser { get; set; } = new();
    public User GetUser() => _unsavedNewUser;
    public void SaveUser(User User) => _unsavedNewUser = User;
    public void ClearUser() => _unsavedNewUser = new();
}
