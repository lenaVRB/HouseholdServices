namespace HouseholdServices.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Error")]
    public partial class Error : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Message { get; set; }

        [Column(TypeName = "text")]
        public string StackTrace { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
