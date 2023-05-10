using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_CAR")]
    public class Car : Notifies
    {
        [Column("CAR_ID")]
        public int Id { get; set; }

        [Column("CAR_NAME")]
        public string Name { get; set; }


        [Column("CAR_MODEL")]
        public string Model { get; set; }


        [Column("CAR_YEAR")]
        public int Year { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
