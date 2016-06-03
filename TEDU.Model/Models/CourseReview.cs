using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    [Table("CourseReviews")]
    public class CourseReview
    {
        public int ID { set; get; }

        public int Mark { set; get; }

        public string Content { set; get; }

        public string UserId { set; get; }

        public int CourseId { set; get; }

        public DateTime CreatedDate { set; get; }

        public string CreatedBy { set; get; }
    }
}
