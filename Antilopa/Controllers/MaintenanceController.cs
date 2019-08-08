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
    public class MaintenanceController : ControllerBase
    {
        private readonly AntilopaDbContext _context;

        public MaintenanceController(AntilopaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> Get()
        {
            return await _context.Maintenance.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maintenance>> Get(int id)
        {
            var data = await _context.Maintenance.FindAsync(id);
            if (data == null) {
                return NotFound();
            }

            return data;
        }

        // [HttpPost]
        // public async Task<ActionResult<Maintenance>> Post([FromBody] Maintenance instance)
        // {
        //     this._context.Maintenance.Add(instance);
        //     await this._context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
        // }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var findRes = await _context.Maintenance.FindAsync(id);
            if (findRes == null) {
                return NotFound();
            }

            _context.Maintenance.Remove(findRes);
            return NoContent();            
        }
    }
}
