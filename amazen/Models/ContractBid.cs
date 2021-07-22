namespace amazen.Models
{
  public class ContractBid
  {
    public int Id { get; set; }
    public int ContractId { get; set; }
    public int ContractorId { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }

    public Contract Contract { get; set; } // how to get multiple groups
    public Profile Profile { get; set; }

  }

}
