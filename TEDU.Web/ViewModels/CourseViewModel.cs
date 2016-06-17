using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEDU.Web.ViewModels
{
    public class CourseViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        public int CategoryId { set; get; }

        [MaxLength(250)]
        public string Image { set; get; }

        public int? Duration { set; get; }

        [Required]
        public int Price { set; get; }

        public int? PromotionPrice { set; get; }

        public string Content { set; get; }

        [Required]
        public int Level { set; get; }

        [Required]
        public int DisplayOrder { set; get; }

        [MaxLength(10)]
        public string Status { set; get; }

        public int? ViewCount { set; get; }

        public int TrainerId { set; get; }

        public DateTime CreatedDate { set; get; }

        [MaxLength(50)]
        public string CreateBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        [MaxLength(250)]
        public string MetaKeyword { set; get; }

        [MaxLength(250)]
        public string MetaDescription { set; get; }

        public bool? HotFlag { set; get; }

        public bool? SlideFlag { set; get; }

        [MaxLength(50)]
        public string LastModifiedBy { set; get; }
    }
}