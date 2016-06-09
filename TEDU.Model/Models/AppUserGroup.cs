using System.ComponentModel.DataAnnotations;

namespace TEDU.Model.Models
{
    public class AppUserGroup
    {
        [Required]
        public virtual string UserId { get; set; }

        [Required]
        public virtual int GroupId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual AppGroup AppGroup { get; set; }
    }
}