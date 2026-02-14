using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly WebDbContext _WebDbContext;
        public MachineController(WebDbContext WebDbContext)
        {
            _WebDbContext = WebDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_WebDbContext.MachineMasters.AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                 var data = _WebDbContext.MachineMasters.Where(x => x.MachineId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {                    
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        public IActionResult Post(MachineMaster machine)
        {
            try
            {
                _WebDbContext.MachineMasters.Add(machine);
                _WebDbContext.SaveChanges();
               return Ok("Record Save Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(MachineMaster machine, int id)
        {
            try
            {
                var data = _WebDbContext.MachineMasters.Where(x => x.MachineId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.MachineMasters.Update(machine);
                    _WebDbContext.SaveChanges();
               return Ok("Record Update Successfully");
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _WebDbContext.MachineMasters.Where(x => x.MachineId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.MachineMasters.Remove(data);
                     _WebDbContext.SaveChanges();
               return Ok("Record Delete Successfully");
                }
                else
                {
                    return BadRequest("Data Not Found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

    }
}
