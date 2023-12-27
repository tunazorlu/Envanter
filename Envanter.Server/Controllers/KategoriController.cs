using Envanter.Server.Data;
using Envanter.Server.Service;
using Envanter.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Envanter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //C# 12.0 first constructor kullanımı
    public class KategoriController(EnvanterDbContext context, KategoriDtoConverter kategoriDtoConverter) : ControllerBase
    {
        private readonly EnvanterDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly KategoriDtoConverter _kategoriDtoConverter = kategoriDtoConverter ?? throw new ArgumentNullException(nameof(kategoriDtoConverter));

        [HttpGet]
        public IActionResult GetKategoriAsJson()
        {
            var kategoriler = _context.Categories.ToList();
            var kategoriDTOs = kategoriler.Select(_kategoriDtoConverter.MapToCategoryDTO).ToList();
            return Ok(kategoriDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetKategoriById(Guid id)
        {
            var kategori = _context.Categories.Find(id);
            if (kategori == null)
            {
                return NotFound();
            }

            var kategoriDTO = _kategoriDtoConverter.MapToCategoryDTO(kategori);

            return Ok(kategoriDTO);
        }

        [HttpPost]
        public IActionResult PostKategori([FromBody] CategoryDTO kategoriDTO)
        {
            if (kategoriDTO == null)
            {
                return BadRequest();
            }

            var kategori = _kategoriDtoConverter.MapToCategory(kategoriDTO);

            _context.Categories.Add(kategori);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetKategoriById), new { id = kategori.Id }, kategoriDTO);
        }

        [HttpPut("{id}")]
        public IActionResult PutKategori(Guid id, [FromBody] CategoryDTO kategoriDTO)
        {
            if (kategoriDTO == null || kategoriDTO.Id != id)
            {
                return BadRequest();
            }

            var updatedKategori = _kategoriDtoConverter.MapToCategory(kategoriDTO);
            updatedKategori.UpdatedDate = DateTime.Now;

            _context.Categories.Update(updatedKategori);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKategori(Guid id)
        {
            var kategori = _context.Categories.Find(id);

            if (kategori == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(kategori);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
