namespace HouseholdServices.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Service : IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            OrderServices = new List<OrderService>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int ServiceTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderService> OrderServices { get; set; }

        public virtual ServiceType ServiceType { get; set; }
    }
}
