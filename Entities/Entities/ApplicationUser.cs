using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {

        [Column("USR_NAME")]
        public string Name { get; set; }

        [Column("USR_AGE")]
        public int Age { get; set; }


        public TypeUser? Type { get; set; }




    }
}
