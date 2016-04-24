using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    public class Page
    {
        [Key]
        public int ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Name { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Alias { set; get; }

        public string Content { set; get; }

        public DateTime CreatedDate { set; get; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string CreateBy { set; get; }

        public bool Status { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaKeyword { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string MetaDescription { set; get; }
    }
}