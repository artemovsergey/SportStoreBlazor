using Microsoft.AspNetCore.SignalR;
using SportStore.Domen.Models;

namespace SportStore.API.Hubs;

public class UserHub : Hub
{
    private static readonly List<User> allUsers = new List<User>();
    private readonly ILogger<UserHub> logger;
    public UserHub(ILogger<UserHub> logger)
    {
        this.logger = logger;
    }

    public async Task GetAllSegments()
    {
        this.logger.LogInformation($"{nameof(GetAllSegments)} - {allUsers.Count}");
        await Clients.Caller.SendAsync("InitSegments", allUsers);
    }

    public async Task SendSegments(IEnumerable<User> segments)
    {
        this.logger.LogInformation(nameof(SendSegments));
        allUsers.AddRange(segments);
        await Clients.Others.SendAsync("AddSegments", segments);
    }

}
