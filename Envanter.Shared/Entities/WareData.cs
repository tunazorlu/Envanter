using Envanter.Shared.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envanter.Shared.Entities
{
    public class WareData : BaseEntity
    {
        public string Name { get; set; }
        public char? Ip { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? WebAddress { get; set; }
        public string? Source { get; set; }
        public string? Description { get; set; }
    }
}
