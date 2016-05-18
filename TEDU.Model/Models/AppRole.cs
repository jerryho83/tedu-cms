using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    [Table("AppRoles", Schema = "dbo")]
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}