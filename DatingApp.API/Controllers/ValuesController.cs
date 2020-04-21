using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase     //controller base sınıfından inherit ediyoruz.
    {
        private readonly DataContext _context; //dbContexte erişiyoruz
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()//taskı asenkron için kullanıyoruz aynı anda birden fazla istek geldiğinde servis karşılasın diye
        {
            //throw new Exception("Test Exception");
           var values=await _context.Values.ToListAsync();
           return  Ok(values);
        }

        [AllowAnonymous]
        // GET api/values/5 //create record
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var value=await _context.Values.FirstOrDefaultAsync(x=>x.Id==id);

           return Ok(value);
           
        }

        // POST api/values  //add arecord
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}