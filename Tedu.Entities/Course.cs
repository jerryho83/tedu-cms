namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course : IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseConsumeds = new HashSet<CourseConsumed>();
            Videos = new HashSet<Video>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        [Required]
        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Poster { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int VisibleIndex { get; set; }

        [Required]
        public string Outline { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool IsReleased { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ReleasedDate { get; set; }

        public int TrainerID { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseConsumed> CourseConsumeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
    }
}
