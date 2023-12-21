using Envanter.Shared.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envanter.Shared.Entities
{
    public class Personal : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public string IdentityNo { get; set; }
        public string? RegisterNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string? Unit { get; set; }
        public string Title { get; set; }
        public string MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string Firm { get; set; }
        public AppUser User { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<WareData> WareDatas { get; set; }

    }
}
