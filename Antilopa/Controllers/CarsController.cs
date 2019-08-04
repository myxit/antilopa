using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AntilopaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AntilopaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AntilopaDbContext _context;

        public CarsController(AntilopaDbContext context)
        {
            _context = context;

            if (_context.Cars.Count() == 0)
            {
                _context.Cars.Add(new Car { Id = 1, Nickname = "white lightning"} );
                _context.Cars.Add(new Car { Id = 2, Nickname = "carrot"} );
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await _context.Cars.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var data = await _context.Cars.FindAsync(id);
            if (data == null) {
                return NotFound();
            }

            return data;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            this._context.Cars.Add(car);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var findRes = await _context.Cars.FindAsync(id);
            if (findRes == null) {
                return NotFound();
            }

            _context.Cars.Remove(findRes);
            return NoContent();            
        }
    }
}
