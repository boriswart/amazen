


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using amazen.Models;
using Dapper;

namespace amazen.Repositories
{

  public class ContractsRepository
  {
    private readonly IDbConnection _db;

    public ContractsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contract> GetAll()
    {
      string sql = @"
                SELECT 
                    c.*,
                    a.*
                FROM contracts c
                JOIN Accounts a ON c.creatorId = a.id;
                           ";
      // [{g:Group, p: profile}].map(({g,p}) => g.creator = p)
      return _db.Query<Contract, Profile, Contract>(sql, (c, p) =>
            {
              c.Creator = p;
              return c;
            }, splitOn: "id").ToList();
    }
  }


}