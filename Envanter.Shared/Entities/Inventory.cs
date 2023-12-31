﻿using Envanter.Shared.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envanter.Shared.Entities
{
    public class Inventory : BaseEntity
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
