﻿using api.Data;
using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly IMotorcyclesRepository _motorcyclesRepository;

        public MotorcyclesController(IMotorcyclesRepository motorcyclesRepository)
        {
            _motorcyclesRepository = motorcyclesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _motorcyclesRepository.GetAllAsync();

            var dtos = models.Select(m => m.ToGetDTO());

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            return model == null ? NotFound() : Ok(model.ToGetDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotorcyclePostDTO dto)
        {
            var model = dto.FromPostDTO();

            await _motorcyclesRepository.CreateAsync(model);

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToGetDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] MotorcyclePutDTO dto)
        {
            var model = await _motorcyclesRepository.UpdateAsync(id, dto);

            if (model == null) return NotFound();

            return Ok(model.ToGetDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _motorcyclesRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
