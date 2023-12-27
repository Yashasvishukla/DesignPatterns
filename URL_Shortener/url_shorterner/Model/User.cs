namespace url_shorterner.Model;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastLogin { get; set; }
}