namespace amazen.Models
{

  public class Contract
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public string description { get; set; }
    public string location { get; set; }
    public string CreatorId { get; set; }
    // virtual
    public Profile Creator { get; set; }

  }

}