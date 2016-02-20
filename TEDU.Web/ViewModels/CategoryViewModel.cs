using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    [Serializable]
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}