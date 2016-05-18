using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("Ebooks")]
    public class Ebook
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
        [StringLength(500)]
        public string Image { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Description { set; get; }

        public string Content { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string DownloadLink { set; get; }

        public int DownloadCount { set; get; }
        public int? DisplayOrder { set; get; }
        public DateTime CreatedDate { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string CreatedBy { set; get; }

        public bool Status { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaKeyword { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaDescription { set; get; }
    }
}