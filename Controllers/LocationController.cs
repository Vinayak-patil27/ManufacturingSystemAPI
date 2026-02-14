using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly WebDbContext _WebDbContext;
        public LocationController(WebDbContext WebDbContext)
        {
            _WebDbContext = WebDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_WebDbContext.Locations.AsNoTracking().ToList());
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
                var data = _WebDbContext.Locations.Where(x => x.LocationId == id).AsNoTracking().FirstOrDefault();
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
        public IActionResult Post(Location location)
        {
            try
            {
                _WebDbContext.Locations.Add(location);
                 _WebDbContext.SaveChanges();
               return Ok("Record Save Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
         }

         [HttpPut("{id}")]
         public IActionResult Put(Location location, int id)
         {
            try
            {
                var data = _WebDbContext.Locations.Where(x => x.LocationId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.Locations.Update(location);
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
                var data = _WebDbContext.Locations.Where(x => x.LocationId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.Locations.Remove(data);
                     _WebDbContext.SaveChanges();
               return Ok("Record Delete Successfully");
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

    }
}
