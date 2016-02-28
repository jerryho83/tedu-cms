using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model
{
    public class Category
    {
        [Key]
        public int ID { set; get; }

        public string Name { set; get; }

        public string Alias { set; get; }

        public int? ParentID { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public string LastModifiedBy { set; get; }

        public DateTime? LastModifiedDate { set; get; }

        public string Status { set; get; }

        public virtual ICollection<Post> Posts { set; get; }
    }
}