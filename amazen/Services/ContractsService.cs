using System;
using System.Collections.Generic;
using amazen.Models;
using amazen.Repositories;

namespace amazen.Services
{

  public class ContractsService
  {
    private readonly ContractsRepository _contractsRepo;
    // private readonly ContractBidsRepository _cbRepo;


    public ContractsService(ContractsRepository contractsRepo) //, ContractBidsRepository )
    {
      _contractsRepo = contractsRepo;
    }


    internal List<Contract> GetContracts()
    {
      return _contractsRepo.GetAll();
    }
  }
}