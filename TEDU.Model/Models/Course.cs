using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        [Required]
        public string Alias { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        public string Description { set; get; }

        [Required]
        public int CategoryId { set; get; }

        [StringLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Image { set; get; }

        [DefaultValue(0)]
        public int? Duration { set; get; }

        [Required]
        [DefaultValue(0)]
        public int Price { set; get; }

        public int? PromotionPrice { set; get; }

        public string Content { set; get; }

        [Required]
        [DefaultValue(0)]
        public int Level { set; get; }

        [Required]
        public int DisplayOrder { set; get; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Status { set; get; }

        [DefaultValue(0)]
        public int? ViewCount { set; get; }

        public int TrainerId { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(50)]
        public string CreateBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }
     
        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaKeyword { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaDescription { set; get; }

        public bool? HotFlag { set; get; }

        public bool? SlideFlag { set; get; }

        [StringLength(50)]
        public string LastModifiedBy { set; get; }

        [ForeignKey("CategoryId")]
        public virtual CourseCategory CourseCategory { set; get; }

        [ForeignKey("TrainerId")]
        public virtual Trainer Trainer { set; get; }

        public virtual IEnumerable<CourseUser> CourseUsers { set; get; }
        public virtual IEnumerable<CourseTechLine> CourseTechLines { set; get; }
    }
}