using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("CourseReviews")]
    public class CourseReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public int? Mark { set; get; }

        public string Content { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string UserId { set; get; }

        public int CourseId { set; get; }

        public DateTime CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
    }
}