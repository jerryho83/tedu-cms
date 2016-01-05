namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPractice")]
    public partial class UserPractice : IEntityBase
    {
        public int ID { get; set; }

        public int VideoID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        public DateTime UploadedDate { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        public int? Mark { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        public bool Status { get; set; }

        public virtual User User { get; set; }

        public virtual Video Video { get; set; }
    }
}
