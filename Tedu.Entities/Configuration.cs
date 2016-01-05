namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Configuration : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public bool MaintainanceMode { get; set; }

        [StringLength(250)]
        public string HomeTitle { get; set; }

        [StringLength(250)]
        public string HomeKeyword { get; set; }

        [StringLength(250)]
        public string HomeDescription { get; set; }

        public int AdminPageSize { get; set; }

        public int FrontEndPageSize { get; set; }

        public bool? RequiredActiveUser { get; set; }

        [Column(TypeName = "ntext")]
        public string ContactInfo { get; set; }

        [Column(TypeName = "ntext")]
        public string FooterInfo { get; set; }

        [StringLength(50)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Twitter { get; set; }

        [StringLength(50)]
        public string Youtube { get; set; }

        [StringLength(50)]
        public string Skype { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
    }
}
