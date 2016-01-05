namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserActivity")]
    public partial class UserActivity : IEntityBase
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ActionName { get; set; }

        public DateTime? ActionDate { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        public int? UserID { get; set; }

        public virtual User User { get; set; }
    }
}
