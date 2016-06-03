using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    public class VideoComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string Content { set; get; }

        [Required]
        [StringLength(128)]
        [Column(TypeName = "nvarchar")]
        public string UserId { set; get; }


        public int? ParentId { set; get; }

        [StringLength(250)]
        public string AttachImage { set; get; }

        [Required]
        public int VideoId { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(128)]
        [Column(TypeName = "nvarchar")]
        public string CreatedBy { set; get; }

        public bool Status { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { set; get; }

        [ForeignKey("VideoId")]
        public virtual CourseVideo CourseVideo { set; get; }

        [ForeignKey("ParentId")]
        public virtual VideoComment Parent { set; get; }

    }
}
