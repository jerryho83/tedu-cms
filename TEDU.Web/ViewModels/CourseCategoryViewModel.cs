using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class CourseCategoryViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        [Required]
        public int DisplayOrder { set; get; }


        public string MetaKeyword { set; get; }


        public string MetaDescription { set; get; }

        public bool? ShowHome { set; get; }
        [Required]
        public bool Status { set; get; }
    }
}