namespace SportStore.Domen.Models;

public  class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public IEnumerable<User>? Users { get; set;}

}
