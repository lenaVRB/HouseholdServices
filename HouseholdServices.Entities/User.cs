namespace HouseholdServices.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User : IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UserRoles = new List<UserRole>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string HashedPassword { get; set; }

        public bool IsLocked { get; set; }

        public DateTime? DateCreated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
