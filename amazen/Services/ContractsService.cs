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


    internal Contract CreateContract(Contract contractData)
    {
      Contract contract = _cRepo.Create(contractData);
      _cRepo.Create(contractData);
      return contract;
    }


    internal List<Contract> GetContracts()
    {
      return _cRepo.GetAll();
    }

    internal Contract GetContractById(int id)
    {
      return _cRepo.GetById(id);
    }

    internal List<ContractBid> GetContractBids(int id)
    {
      List<ContractBid> bids = _cbRepo.GetBidsByContractId(id);
      return bids;
    }
  }
}