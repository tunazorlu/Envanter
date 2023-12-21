using Envanter.Shared.Entities.Common;

namespace Envanter.Shared.Entities
{
    public class Category : BaseEntity
    {
        public Guid InventoryId { get; set; }
        public string CategoryType { get; set; }
        public string CategoryBrand { get; set; }
        public string CategoryModel { get; set; }
        public Inventory Inventories { get; set; }

    }
}
