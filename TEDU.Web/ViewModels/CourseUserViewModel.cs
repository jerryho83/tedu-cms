using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class CourseUserViewModel
    {
        public int ID { set; get; }

        [MaxLength(128)]
        public string UserId { set; get; }

        public int CourseId { set; get; }

        [Required]
        public int Price { set; get; }

        [Required]
        public int PaymentMethodId { set; get; }

        public DateTime CreatedDate { set; get; }

        [MaxLength(128)]
        public string CreatedBy { set; get; }

        public bool Status { set; get; }
    }
}