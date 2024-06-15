namespace SportStore.Domen.Models;

public class User
{
    public int Id { get; set; }
    public string Surname { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string? Patronymic { get; set; } = String.Empty;
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public string? Image { get; set; } = String.Empty;
    public int RoleId { get; set; }
    public Role? Role { get; set; }

    public ImageAction ImageAction { get; set; }

    public List<WaypointDto>? Waypoints { get; set; } = new List<WaypointDto>();

    public List<Item> Items { get; set; } = new List<Item>();

}

public record WaypointDto(int Id, decimal Latitude, decimal Longitude);

public enum ImageAction
{
    None,
    Add,
    Remove
}



