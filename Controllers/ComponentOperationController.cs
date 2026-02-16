using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentOperationController : ControllerBase
    {
        private readonly WebDbContext _WebDbContext;
        public ComponentOperationController(WebDbContext WebDbContext)
        {
            _WebDbContext = WebDbContext;
        }
        [HttpGet("OperationDetails")]
        public IActionResult GetCustomersWithComponentOperations(string? search)
        {
            try
            {
                var result = from cust in _WebDbContext.Customers.AsNoTracking()
                             join compo in _WebDbContext.ComponentMasters.AsNoTracking()
                                 on cust.CustomerId equals compo.CustomerId into componentGroup
                         
                             from compgrp in componentGroup.DefaultIfEmpty()
                             join compOpr in _WebDbContext.ComponentOperationMasters.AsNoTracking()
                                 on compgrp.ComponentId equals compOpr.ComponentId into operationGroup
                             from op in operationGroup.DefaultIfEmpty()
                             join machine in _WebDbContext.MachineMasters.AsNoTracking()
                                 on (op == null ? (long?)null : op.MachineId) equals machine.MachineId into machineGroup
                             from mach in machineGroup.DefaultIfEmpty()
                             select new OperationDetailsViewModel
                             {
                                 CustomerId = cust.CustomerId,
                                 CustomerName = cust.CustomerName,
                                 ComponentId = compgrp == null ? (long?)null : compgrp.ComponentId,
                                 ComponentName = compgrp == null ? null : compgrp.ComponentName,
                                 PartNo = compgrp == null ? null : compgrp.PartNo,
                                 ECN = compgrp == null ? null : compgrp.ENC,
                                 TrNo = op == null ? (long?)null : op.TrNo,
                                 OperationCode = op == null ? null : op.OperationCode,
                                 OperationName = op == null ? null : op.OperationName,
                                 OperationDescription = op == null ? null : op.OperationDescription,
                                 OperationType = op == null ? (int?)null : op.OperationType,
                                 MachineId = op == null ? (long?)null : op.MachineId,
                                 MachineName = mach == null ? null : mach.MachineName
                             };

                if (!string.IsNullOrWhiteSpace(search))
                {
                    result = result.Where(x => (x.CustomerName != null && x.CustomerName.Contains(search)) ||
                                          (x.ComponentName != null && x.ComponentName.Contains(search)) ||
                                          (x.OperationCode != null && x.OperationCode.Contains(search)) ||
                                          (x.OperationName != null && x.OperationName.Contains(search)));
                }
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_WebDbContext.ComponentOperationMasters.AsNoTracking().ToList());
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            { 
                var data = _WebDbContext.ComponentOperationMasters.Where(x => x.TrNo == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    return Ok(data); 
                }
                else
                {
                    return BadRequest("Data Not Found");
                }
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }
        
        [HttpPost]
        public IActionResult Post(ComponentOperationMaster Component)
        {
            try
            {
                _WebDbContext.ComponentOperationMasters.Add(Component);
                _WebDbContext.SaveChanges();
               return Ok("Record Save Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
         }

         [HttpPut("{id}")]
         public IActionResult Put(ComponentOperationMaster Component, long id)
         {
             try
            {
                var data = _WebDbContext.ComponentOperationMasters.Where(x => x.TrNo == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.ComponentOperationMasters.Update(Component);
                     _WebDbContext.SaveChanges();
               return Ok("Record Update Successfully");
                }
                else
                {
                    return BadRequest("Data Not Found");
                }
             }
             catch (Exception)
             {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
             }
          }

          [HttpDelete("{id}")]
          public IActionResult Delete(long id)
          {
              try
            {
                var data = _WebDbContext.ComponentOperationMasters.Where(x => x.TrNo == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.ComponentOperationMasters.Remove(data);
                     _WebDbContext.SaveChanges();
               return Ok("Record Delete Successfully");
                }
                else
                {
                    return BadRequest("Data Not Found");
                }
              }
              catch (Exception)
              {
                 return BadRequest("Can't Take Any Actions Due To Server Problem");
              }
           }

    }
}
