using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<PostViewModel> Gadgets { get; set; }
    }
}