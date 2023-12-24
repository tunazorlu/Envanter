using Envanter.Server.Data;
using Envanter.Shared.DTOs;
using Envanter.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

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
    }
}
