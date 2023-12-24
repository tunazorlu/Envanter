using Envanter.Shared.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envanter.Shared.DTOs
{
    public class WareDataDTO : Common.BaseEntityDTO
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "IP")]
        public char? Ip { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }
        [Display(Name = "Şifre")]
        public string? Password { get; set; }
        [Display(Name = "Web Adresi")]
        public string? WebAddress { get; set; }
        [Display(Name = "Kaynak")]
        public string? Source { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        public Guid? PersonalId { get; set; }
        public virtual PersonalDTO? Personals { get; set; }
    }
}
