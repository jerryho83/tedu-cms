using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("TechLines")]
    public class TechLine
    {
        [Key]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string ID { set; get; }

        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Name { set; get; }
    }
}