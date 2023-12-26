using Envanter.Server.Data;
using Envanter.Shared.DTOs;
using Envanter.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Envanter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //C# 12.0 first constructor kullanımı
    public class KategoriController(EnvanterDbContext context) : Controller
    {
        private readonly EnvanterDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        [HttpGet]
        public IActionResult GetKategoriAsJson()
        {
            var kategoriler = _context.Categories.ToList();
            var kategoriDTOs = MapToCategoryDTOs(kategoriler);
            return Ok(kategoriDTOs);
        }
        private List<CategoryDTO> MapToCategoryDTOs(IEnumerable<Category> categories)
        {
            // Category sınıfından CategoryDTO'ya dönüştürme işlemini gerçekleştirin.
            // Örnek bir dönüşüm kodu:
            return categories.Select(c => new CategoryDTO { 
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate,
                Type = c.Type, 
                Brand = c.Brand,
                Model = c.Model,
                Inventories = c.Inventories,
            }).ToList();

        }

        [HttpGet("{id}")]
        public IActionResult GetKategoriById(Guid id)
        {
            var kategori = _context.Categories.Find(id);
            if (kategori == null)
            {
                return NotFound();
            }

            var kategoriDTO = new CategoryDTO
            {
                Id = kategori.Id,
                CreatedDate = kategori.CreatedDate,
                UpdatedDate = kategori.UpdatedDate,
                Type = kategori.Type,
                Brand = kategori.Brand,
                Model = kategori.Model,
                Inventories = kategori.Inventories,
            };

            return Ok(kategoriDTO);
        }

        [HttpPost]
        public IActionResult PostKategori([FromBody] CategoryDTO kategoriDTO)
        {
            if (kategoriDTO == null)
            {
                return BadRequest();
            }

            var kategori = new Category
            {
                Id = kategoriDTO.Id,
                CreatedDate = kategoriDTO.CreatedDate,
                UpdatedDate = kategoriDTO.UpdatedDate,
                Type = kategoriDTO.Type,
                Brand = kategoriDTO.Brand,
                Model = kategoriDTO.Model,
                Inventories = kategoriDTO.Inventories,
            };

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
            var updatedKategori = _context.Categories.Find(id);
            if (updatedKategori == null)
            {
                return NotFound();
            }
            updatedKategori.Type = kategoriDTO.Type;
            updatedKategori.Brand = kategoriDTO.Brand;
            updatedKategori.Model = kategoriDTO.Model;
            updatedKategori.Inventories = kategoriDTO.Inventories;
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
