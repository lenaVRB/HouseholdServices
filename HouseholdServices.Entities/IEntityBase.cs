using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdServices.Entities
{
    public interface IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int ID { get; set; }
    }
}
