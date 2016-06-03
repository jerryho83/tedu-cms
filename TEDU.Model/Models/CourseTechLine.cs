using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("CourseTechLines")]
    public class CourseTechLine
    {
        [Key]
        [Column(Order = 1)]
        public int CourseId { set; get; }

        [StringLength(50)]
        [Column(TypeName = "varchar", Order = 2)]
        public string TechLineId { set; get; }
    }
}