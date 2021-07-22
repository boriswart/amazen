using System;
using System.Collections.Generic;
using amazen.Models;
using amazen.Repositories;

namespace amazen.Services
{

  public class ContractsService
  {
    private readonly ContractsRepository _cRepo;
    private readonly ContractBidsRepository _cbRepo;


    public ContractsService(ContractsRepository contractsRepo, ContractBidsRepository contractBidsRepo)
    {
      _cRepo = contractsRepo;
      _cbRepo = contractBidsRepo;
    }


    internal List<Contract> GetContracts()
    {
      return _cRepo.GetAll();
    }

    internal List<Contract> GetContractById(int id)
    {
      return _cRepo.GetContractById(id);
    }

    internal List<ContractBid> GetContracBids(int id)
    {
      throw new NotImplementedException();
    }
  }
}