using api.Data;
using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotorcyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _context.Motorcycles.ToListAsync();

            var dtos = models.Select(m => m.ToGetDTO());

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await _context.Motorcycles.FindAsync(id);

            return model == null ? NotFound() : Ok(model.ToGetDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotorcyclePostDTO dto)
        {
            var model = dto.FromPostDTO();

            await _context.Motorcycles.AddAsync(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToGetDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] MotorcyclePutDTO dto)
        {
            var model = await _context.Motorcycles.FindAsync(id);

            if (model == null) return NotFound();

            _context.Entry(model).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return Ok(model.ToGetDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await _context.Motorcycles.FindAsync(id);

            if (model == null) return NotFound();

            _context.Motorcycles.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
