﻿using Envanter.Shared.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Envanter.Shared.Entities
{
    public class Category : BaseEntity
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Inventory Inventories { get; set; }

    }
}
