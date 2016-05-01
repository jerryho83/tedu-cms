using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    [Table("SystemParams")]
    public class SystemParam
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Value { set; get; }
    }
}
