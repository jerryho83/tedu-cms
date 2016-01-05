namespace Tedu.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Visitor : IEntityBase
    {
        public int ID { get; set; }

        public DateTime? VisitedDate { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string Brower { get; set; }

        [StringLength(50)]
        public string Platform { get; set; }
    }
}