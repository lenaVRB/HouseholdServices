namespace HouseholdServices.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderService : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ServiceID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Order Order { get; set; }

        public virtual Service Service { get; set; }
    }
}
