using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public string Description { set; get; }

        [Required]
        public int CategoryID { set; get; }

        public string Image { set; get; }

        public string Content { set; get; }

        [Required]
        public string PostType { set; get; }

        public string Source { set; get; }

        [Required]
        public string Status { set; get; }

        public int? ViewCount { set; get; }

        public string Tags { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        public string LastModifiedBy { set; get; }

        public string OtherStatus { set; get; }

        public virtual Category Category { set; get; }
    }
}