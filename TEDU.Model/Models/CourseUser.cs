using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("CourseUsers")]
    public class CourseUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string UserId { set; get; }

        public int CourseId { set; get; }

        [Required]
        public int Price { set; get; }

        [Required]
        public int PaymentMethodId { set; get; }

        public DateTime CreatedDate { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string CreatedBy { set; get; }

        public bool Status { set; get; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { set; get; }

        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod PaymentMethod { set; get; }

        [ForeignKey("CourseId")]
        public virtual Course Course { set; get; }
    }
}