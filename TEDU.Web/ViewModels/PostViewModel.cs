using System;
using System.ComponentModel.DataAnnotations;

namespace TEDU.Web.ViewModels
{
    [Serializable]
    public class PostViewModel
    {
        public int ID { set; get; }

        [MaxLength(250, ErrorMessage = "Tiêu đề không được quá 250 ký tự")]
        public string Name { set; get; }

        [MaxLength(250, ErrorMessage = "Alias không được quá 250 ký tự")]
        public string Alias { set; get; }

        [MaxLength(250, ErrorMessage = "Mô tả không được quá 250 ký tự")]
        public string Description { set; get; }

        public int CategoryID { set; get; }

        [MaxLength(250, ErrorMessage = "Hình ảnh không được quá 250 ký tự")]
        public string Image { set; get; }

        public string Content { set; get; }

        public string PostType { set; get; }

        [MaxLength(250, ErrorMessage = "Nguồn không được quá 250 ký tự")]
        public string Source { set; get; }

        public string Status { set; get; }
        public int? ViewCount { set; get; }
        public string Tags { set; get; }

        public DateTime? CreatedDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }

        public string OtherStatus { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool? HotFlag { set; get; }

        public bool? SlideFlag { set; get; }

        public CategoryViewModel Category { set; get; }
    }
}