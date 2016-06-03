using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("TechLines")]
    public class TechLine
    {
        [Key]
        public int ID { set; get; }

        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }

        public virtual IEnumerable<CourseTechLine> CourseTechLines { set; get; }

    }
}