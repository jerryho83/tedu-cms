using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Model.Models
{
    public class VideoComment
    {
        public int ID { set; get; }

        public string Content { set; get; }

        public string UserId { set; get; }

        public int? ParentId { set; get; }

        public string AttachImage { set; get; }

        public int VideoId { set; get; }

        public DateTime CreatedDate { set; get; }

        public string CreatedBy { set; get; }
    }
}
