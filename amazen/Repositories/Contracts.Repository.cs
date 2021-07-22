
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using amazen.Interfaces;
using amazen.Models;
using Dapper;

namespace amazen.Repositories
{

  public class ContractsRepository : IRepo<Contract>
  {
    private readonly IDbConnection _db;

    public ContractsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Contract Create(Contract data)
    {
      var sql = @"
            INSERT INTO contracts(name, description, img, creatorId)
            VALUES(@Name, @Description, @Img, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public List<Contract> GetAll()
    {
      string sql = @"
                SELECT 
                    c.*,
                    a.*
                FROM contracts c
                JOIN Accounts a ON c.creatorId = a.id;
            ";
      // Returning a list with just one element of type Contract Model
      // The join requires a Query wheras 
      // [{c:Contract, p: profile}].map(({c,p}) => c.creator = p) // mapping using virtual creator of type Profile
      return _db.Query<Contract, Profile, Contract>(sql, (c, p) =>
      {
        c.Creator = p;
        return c;
      }, splitOn: "id").ToList();    // needed above complex return to satisfy Dapper confusion
    }

    public Contract GetById(int id)
    {
      string sql = @"
                SELECT 
                    c.*,
                    a.*
                FROM contracts c
                JOIN Accounts a ON c.creatorId = a.id
                WHERE c.id = @id;
            ";

      return _db.Query<Contract, Profile, Contract>(sql, (c, p) =>
        {
          c.Creator = p;
          return c;
        }, new { id }).FirstOrDefault();
    }

    public Contract Update(Contract data)
    {
      var sql = @"
                UPDATE contracts
                    SET
                    name = @Name,
                    img = @Img,
                    description = @Description
                WHERE id = @Id;
            ";
      var rowsAffected = _db.Execute(sql, data);
      if (rowsAffected > 1)
      {
        throw new Exception("Ahhhhh that was probably really bad");
      }
      if (rowsAffected < 1)
      {
        throw new Exception("woops update didn't work no idea why probably a bad id");
      }
      return data;
    }

  }

}