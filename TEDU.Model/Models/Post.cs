using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TEDU.Model.Models;

namespace TEDU.Model
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Name { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Alias { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Description { set; get; }

        public int CategoryID { set; get; }

        [StringLength(250)]
        public string Image { set; get; }

        public string Content { set; get; }

        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string PostType { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Source { set; get; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Status { set; get; }

        public int? ViewCount { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Tags { set; get; }

        public DateTime? CreatedDate { set; get; }

        [StringLength(50)]
        public string CreateBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        [StringLength(50)]
        public string LastModifiedBy { set; get; }

        [StringLength(50)]
        public string OtherStatus { set; get; }
        
        [ForeignKey("CategoryID")]
        public virtual Category Category { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaKeyword { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaDescription { set; get; }

        public bool? HotFlag { set; get; }

        public bool? SlideFlag { set; get; }

        public virtual IEnumerable<PostTag> PostTags { set; get; }
    }
}