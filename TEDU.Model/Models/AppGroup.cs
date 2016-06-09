using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("AppGroups")]
    public class AppGroup
    {
        public AppGroup()
        {
        }

        public AppGroup(string name) : this()
        {
            this.Roles = new List<AppRoleGroup>();
            this.Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<AppRoleGroup> Roles { get; set; }
    }
}