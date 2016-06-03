using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    [Table("CourseVideos")]
    public class CourseVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [Column(TypeName ="nvarchar")]
        [StringLength(250)]
        public string Name { set; get; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Alias { set; get; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Path { set; get; }

        [Required]
        [DefaultValue(0)]
        public int Duration { set; get; }

        public string SlidePath { set; get; }

        public string SourceCodePath { set; get; }

        public string Reference { set; get; }

        public int CourseId { set; get; }

        public string Chapter { set; get; }

        public int DisplayOrder { set; get; }

        public bool AllowTrialView { set; get; }

        public int TrialViewTime { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public string LastModifiedBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        public bool Status { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
    }
}
