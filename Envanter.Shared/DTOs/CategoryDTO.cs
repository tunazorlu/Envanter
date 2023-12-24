using Envanter.Shared.Entities;

namespace Envanter.Shared.DTOs
{
    public class CategoryDTO : Common.BaseEntityDTO
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Inventory Inventories { get; set; }

    }
}
