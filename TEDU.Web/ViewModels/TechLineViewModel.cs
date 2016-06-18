using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class TechLineViewModel
    {
        public int ID { set; get; }

        [MaxLength(250)]
        public string Name { set; get; }
    }
}