using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("AppGroups")]
    public class AppGroup
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<AppRoleGroup> RoleGroups { get; set; }

        public virtual IEnumerable<AppUserGroup> UserGroups { get; set; }
    }
}