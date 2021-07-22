using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using amazen.Services;
using amazen.Models;
using System.Collections.Generic;
using System.Linq;

namespace amazen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractsController : ControllerBase
  {

    private readonly ContractsService _cs;

    public ContractsController(ContractsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Contract>> Get()
    {
      try
      {
        List<Contract> contracts = _cs.GetContracts().ToList();
        return Ok(contracts);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contract> GetOne(int id)
    {
      try
      {
        Contract contract = _cs.GetContractById(id);
        return Ok(contract);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/bids")]
    public ActionResult<List<ContractBid>> GetContractBids(int id)
    {
      try
      {
        List<ContractBid> bids = _cs.GetContractBids(id);
        return Ok(bids);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }









  }

}