namespace BrennansWebsite.Models;

public class Gardener
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    //nav props
    public Gardens? Garden { get; set; }
    public ICollection<ClaimedBy> ClaimedBy { get; set; }
}