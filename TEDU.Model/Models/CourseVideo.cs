using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    [Table("CourseVideos")]
    public class CourseVideo
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Path { set; get; }
        public int Duration { set; get; }
        public string SlidePath { set; get; }
        public string SourceCodePath { set; get; }
        public string Reference { set; get; }
        public int CourseId { set; get; }
        public string Chapter { set; get; }
        public int DisplayOrder { set; get; }
        public bool AllowTrialView { set; get; }
        public int TrialViewTime { set; get; }
        public DateTime? CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string LastModifiedBy { set; get; }
        public DateTime? LastModifiedDate { set; get; }
        public bool Status { set; get; }
    }
}
