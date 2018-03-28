namespace HouseholdServices.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserRole : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
