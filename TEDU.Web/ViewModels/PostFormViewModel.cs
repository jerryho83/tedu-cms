using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class PostFormViewModel
    {
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public HttpPostedFile Image { set; get; }
        public int CategoryID { set; get; }
    }
}