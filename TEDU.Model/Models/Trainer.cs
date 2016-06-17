using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("Trainers")]
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [StringLength(128)]
        public string Name { set; get; }

        public string Portfolio { set; get; }

        [StringLength(128)]
        public string JobTitle { set; get; }

        [StringLength(250)]
        public string Image { set; get; }

        public virtual IEnumerable<Course> Courses { set; get; }
    }
}