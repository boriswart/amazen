using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
// using System.Linq;
using Dapper;
// using amazen.Interfaces;
using amazen.Models;

namespace amazen.Repositories
{
  public class ContractBidsRepository
  {
    private readonly IDbConnection _db;

    public ContractBidsRepository(IDbConnection db)
    {
      _db = db;
    }

    public ContractBid Create(ContractBid cb)
    {
      string sql = @"
            INSERT INTO 
                contract_bids(accountId, contractId, bid_amount, description)
            VALUES(@ContractorId, @ContractId, @Amount, @Description);
            SELECT LAST_INSERT_ID();
            ";
      cb.Id = _db.ExecuteScalar<int>(sql, cb);
      return cb;
    }

    public void Create(string contractorId, int contractId, int bid_amount, string description)
    {
      string sql = @"
            INSERT INTO 
                contract_bids(contractorId, contractId, bid_amount)
            VALUES(@contractorId, @contractId, @bid_amount, @description);
            ";
      _db.ExecuteScalar<int>(sql, new { contractorId, contractId, bid_amount, description });
    }

    internal List<ContractBid> GetBidsByContractId(int id)
    {
      // REVIEW joining data and mapping to two classes
      string sql = @"
            SELECT *
            FROM contract_bids cb
            JOIN accounts a ON a.id = cb.contractorId
            WHERE contractId = @id; 
            ";
      //               vv c         vv p     vv return type of the entire Query
      return _db.Query<ContractBid, Profile, ContractBid>(sql, (c, p) =>
      {
        c.Profile = p;
        return c;
      }, new { id }).ToList();
    }
  }
}