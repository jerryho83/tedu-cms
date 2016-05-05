using System;

namespace TEDU.Web.ViewModels
{
    [Serializable]
    public class PageViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public string Content { set; get; }

        public DateTime CreatedDate { set; get; }

        public string CreateBy { set; get; }

        public bool Status { set; get; }

        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
    }
}