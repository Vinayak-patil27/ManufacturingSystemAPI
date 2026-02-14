using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineManufacturerController : ControllerBase
    {
        private readonly WebDbContext _WebDbContext;
        public MachineManufacturerController(WebDbContext WebDbContext)
        {
            _WebDbContext = WebDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_WebDbContext.MachineManufacturers.AsNoTracking().ToList());
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _WebDbContext.MachineManufacturers.Where(x => x.ManufacturerId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpPost]
        public IActionResult Post(MachineManufacturer machineManufacturer)
        {
            try
            {
                _WebDbContext.MachineManufacturers.Add(machineManufacturer);
                _WebDbContext.SaveChanges();
                return Ok("Record Save Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(MachineManufacturer machineManufacturer, int id)
        {
            try
            {
                var data = _WebDbContext.MachineManufacturers.Where(x => x.ManufacturerId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.MachineManufacturers.Update(machineManufacturer);
                    _WebDbContext.SaveChanges();
                    return Ok("Record Update Successfully");
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _WebDbContext.MachineManufacturers.Where(x => x.ManufacturerId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.MachineManufacturers.Remove(data);
                    _WebDbContext.SaveChanges();
                    return Ok("Record Delete Successfully");
                }
                else
                {
                    return BadRequest("Record Not Found");
                }
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
        }

    }
}
