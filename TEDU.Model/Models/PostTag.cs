using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEDU.Model.Models
{
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int PostID { set; get; }

        [Column(TypeName = "varchar", Order = 2)]
        [StringLength(250)]
        [Key]
        public string TagID { set; get; } 

        public virtual Post Post { set; get; }

        public virtual Tag Tag { set; get; }
    }
}