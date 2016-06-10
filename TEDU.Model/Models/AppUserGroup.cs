using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("AppUserGroups")]
    public class AppUserGroup
    {
        [Required]
        [Key]
        [Column(Order = 1)]
        public virtual string UserId { get; set; }

        [Required]
        [Key]
        [Column(Order = 2)]
        public virtual int GroupId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("GroupId")]
        public virtual AppGroup Group { get; set; }
    }
}