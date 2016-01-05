namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseConsumed")]
    public partial class CourseConsumed : IEntityBase
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int CourseID { get; set; }

        public DateTime BoughtDate { get; set; }

        public decimal Value { get; set; }

        public bool Status { get; set; }

        public virtual Course Cours { get; set; }

        public virtual User User { get; set; }
    }
}
