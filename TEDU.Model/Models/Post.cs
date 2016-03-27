using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model
{
    public class Post
    {
        [Key]
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

        public string Image { set; get; }

        public string Content { set; get; }

        public string PostType { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Source { set; get; }

        public string Status { set; get; }

        public int? ViewCount { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Tags { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        public string LastModifiedBy { set; get; }

        public string OtherStatus { set; get; }

        public virtual Category Category { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaKeyword { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaDescription { set; get; }
    }
}