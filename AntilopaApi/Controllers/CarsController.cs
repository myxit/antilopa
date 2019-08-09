using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AntilopaApi.Data;
using AntilopaApi.Models;
using AntilopaApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AntilopaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CarService carService;

        public CarsController(ApplicationDbContext context, CarService carService)
        {
            _context = context;
            this.carService = carService;
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
        public async Task<ActionResult<Car>> Post([FromQuery] int id, [FromBody] CarInputModel inputModel)
        {
            var readResult = await this.carService.MakeForUpdate(id, inputModel);
            if (!readResult.isSuccess) {
                return BadRequest();
            }

            var car = readResult.Item2;
            this._context.Cars.Add(readResult.Item2);
            // await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

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
