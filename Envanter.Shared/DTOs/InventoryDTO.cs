using Envanter.Shared.Entities;

namespace Envanter.Shared.DTOs
{
    public class InventoryDTO : Common.BaseEntityDTO
    {
        public string? Location { get; set; }
        public string? SeriNo { get; set; }
        public string? DebitNo { get; set; }
        public string? Description { get; set; }
        public string? Source { get; set; }
        public string? Status { get; set; }
        public DateTime? DebitStart { get; set; }
        public DateTime? DebitEnd { get; set; }
        public Guid? PersonalId { get; set; }
        public virtual Personal? Personals { get; set; }
        public Guid? CategoryId { get; set; }
        public Category? Categories { get; set; }
    }
}
