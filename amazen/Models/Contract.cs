namespace amazen.Models
{

  public class Contract
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string CreatorId { get; set; }
    // virtual
    public Profile Creator { get; set; }

  }

}