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

        [Key]
        [Column(Order = 2)]
        public int TechLineId { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
        [ForeignKey("TechLineId")]
        public virtual TechLine TechLine { set; get; }
    }
}