using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Alias { set; get; }

        public int? ParentID { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }

        public string LastModifiedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }

        [Required]
        public string Status { set; get; }

        public virtual ICollection<Post> Posts { set; get; }
    }
}