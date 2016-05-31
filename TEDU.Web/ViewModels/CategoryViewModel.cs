using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEDU.Web.ViewModels
{
    [Serializable]
    public class CategoryViewModel
    {
        public int ID { set; get; }

        [MaxLength(250, ErrorMessage = "Tên không được vượt quá 250 ký tự.")]
        public string Name { set; get; }

        [MaxLength(250, ErrorMessage = "Alias không được vượt quá 250 ký tự.")]
        public string Alias { set; get; }

        public int? ParentID { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public string LastModifiedBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        public bool Status { set; get; }

        [MaxLength(250, ErrorMessage = "MetaKeyword được vượt quá 250 ký tự.")]
        public string MetaKeyword { set; get; }

        [MaxLength(250, ErrorMessage = "MetaDescription được vượt quá 250 ký tự.")]
        public string MetaDescription { set; get; }

        public bool? ShowHome { set; get; }

        public List<PostViewModel> Posts { set; get; }
    }
}