namespace Tedu.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video : IEntityBase
    {
        public Video()
        {
            UserPractices = new HashSet<UserPractice>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Poster { get; set; }

        public int GenreID { get; set; }

        [Required]
        [StringLength(500)]
        public string Path { get; set; }

        [Required]
        [StringLength(8)]
        public string Duration { get; set; }

        public int UserID { get; set; }

        public int ViewCount { get; set; }

        public int? VisibleIndex { get; set; }

        public int CourseID { get; set; }

        [StringLength(500)]
        public string Attachment { get; set; }

        [StringLength(500)]
        public string EngSub { get; set; }

        [StringLength(500)]
        public string VnSub { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [StringLength(100)]
        public string LastModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [StringLength(500)]
        public string UserLiked { get; set; }

        public bool Status { get; set; }

        public virtual Course Cours { get; set; }

        public virtual Genre Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPractice> UserPractices { get; set; }
    }
}
