using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("CourseUsers")]
    public class CourseUser
    {
        [Key]
        [Column(Order = 1, TypeName = "nvarchar")]
        [StringLength(128)]
        public string UserId { set; get; }

        [Key]
        [Column(Order = 2)]
        public int CourseId { set; get; }

        public int Price { set; get; }

        public int PaymentMethodId { set; get; }

        public DateTime CreatedDate { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string CreatedBy { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { set; get; }

        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
    }
}