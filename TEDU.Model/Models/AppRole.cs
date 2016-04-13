using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    [Table("AppRoles",Schema ="dbo")]
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
