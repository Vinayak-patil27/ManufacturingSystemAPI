using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly WebDbContext _WebDbContext;
        public CustomerController(WebDbContext WebDbContext)
        {
            _WebDbContext = WebDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_WebDbContext.Customers.AsNoTracking().ToList());
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
                
                var data = _WebDbContext.Customers.Where(x => x.CustomerId == id).AsNoTracking().FirstOrDefault();
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
        public IActionResult Post(Customer customer)
        {
            try
            {
                _WebDbContext.Customers.Add(customer);
                 _WebDbContext.SaveChanges();
               return Ok("Record Save Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Can't Take Any Actions Due To Server Problem");
            }
         }

         [HttpPut("{id}")]
         public IActionResult Put(Customer customer, long id)
         {
             try
            {
                var data = _WebDbContext.Customers.Where(x => x.CustomerId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.Customers.Update(customer);
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
                var data = _WebDbContext.Customers.Where(x => x.CustomerId == id).AsNoTracking().FirstOrDefault();
                if (data != null)
                {
                    _WebDbContext.Customers.Remove(data);
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
