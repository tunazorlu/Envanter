using Envanter.Shared.DTOs;
using Envanter.Shared.Entities;

namespace Envanter.Server.Service
{
    public class KategoriDtoConverter
    {
        public CategoryDTO MapToCategoryDTO(Category kategory)
        {
            if (kategory == null)
                return null;

            return new CategoryDTO
            {
                Id = kategory.Id,
                CreatedDate = kategory.CreatedDate,
                UpdatedDate = kategory.UpdatedDate,
                Type = kategory.Type,
                Brand = kategory.Brand,
                Model = kategory.Model,
                Inventories = kategory.Inventories,
            };
        }
        public Category MapToCategory(CategoryDTO kategoryDTO)
        {
            if (kategoryDTO == null)
                return null;

            return new Category
            {
                Id = kategoryDTO.Id,
                CreatedDate = kategoryDTO.CreatedDate,
                UpdatedDate = kategoryDTO.UpdatedDate,
                Type = kategoryDTO.Type,
                Brand = kategoryDTO.Brand,
                Model = kategoryDTO.Model,
                Inventories = kategoryDTO.Inventories,
            };
        }
    }

}
