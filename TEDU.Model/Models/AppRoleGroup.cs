using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("AppRoleGroups")]
    public class AppRoleGroup
    {
        [Key]
        [Column(Order = 1)]
        public virtual string RoleId { get; set; }

        [Key]
        [Column(Order = 2)]
        public virtual int GroupId { get; set; }

        [ForeignKey("RoleId")]
        public virtual AppRole Role { get; set; }

        [ForeignKey("GroupId")]
        public virtual AppGroup Group { get; set; }
    }
}