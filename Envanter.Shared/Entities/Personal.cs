﻿using Envanter.Shared.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envanter.Shared.Entities
{
    public class Personal : BaseEntity
    {
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Giriş Tarihi")]
        public DateTime JoinDate { get; set; }
        [Display(Name = "Çıkış Tarihi")]
        public DateTime? QuitDate { get; set; }
        [Display(Name = "TC Kimlik No")]
        public string IdentityNo { get; set; }
        [Display(Name = "Sicil No")]
        public string? RegisterNo { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "E-posta")]
        public string? Email { get; set; }
        [Display(Name = "Birim")]
        public string? Unit { get; set; }
        [Display(Name = "Ünvan")]
        public string? Title { get; set; }
        [Display(Name = "Cep Telefonu")]
        public string? MobilePhone { get; set; }
        [Display(Name = "Ev Telefonu")]
        public string? WorkPhone { get; set; }
        [Display(Name = "Firma")]
        public string? Firm { get; set; }
        public virtual List<Inventory>? Inventories { get; set; } = new List<Inventory>();
        public virtual List<WareData>? WareDatas { get; set; } = new List<WareData>();
    }
}
