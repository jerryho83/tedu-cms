using System;

namespace TEDU.Web.ViewModels
{
    public class EbookViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public string Image { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public string DownloadLink { set; get; }

        public int DownloadCount { set; get; }

        public int? DisplayOrder { set; get; }

        public DateTime CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public bool Status { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}