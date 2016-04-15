using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    public class Tag
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string ID { set; get; }

        [Column(TypeName = "nvarchar")]
        [StringLength(250)]
        public string Name { set; get; }

        public virtual ICollection<PostTag> PostTags { set; get; }
    }
}