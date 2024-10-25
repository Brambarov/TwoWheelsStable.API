using api.Data;
using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
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
            var dtos = await _context.Motorcycles
                .Select(m => m.ToGetDTO())
                .ToListAsync();

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

            model.FromPutDTO(dto);

            _context.Motorcycles.Update(model);
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
