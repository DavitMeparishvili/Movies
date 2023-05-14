namespace Movies.Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public string UserName { get; set; }

    public List<WatchList> MyProperty { get; set; }
}
