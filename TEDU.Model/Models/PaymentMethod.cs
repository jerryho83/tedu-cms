using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        public int ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        [Required]
        public string Name { set; get; }

        [Required]
        public double Fee { set; get; }

        public virtual IEnumerable<CourseUser> CourseUsers { set; get; }
    }
}