using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphaEventViewer.Models
{
    [Table("Salutations")]
    public class SalutationEntity
    {
        public string Salutation { get; set; }
    }
}
