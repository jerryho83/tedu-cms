using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class AppGroupViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AppRoleViewModel> Roles { set; get; }
    }
}