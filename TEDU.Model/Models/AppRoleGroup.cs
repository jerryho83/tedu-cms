using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    public class AppRoleGroup
    {
        public virtual string RoleId { get; set; }
        public virtual int GroupId { get; set; }

        public virtual AppRole Role { get; set; }
        public virtual AppGroup Group { get; set; }
    }
}
