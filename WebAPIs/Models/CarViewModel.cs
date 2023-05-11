using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class CarViewModel
    {

     
        public int Id { get; set; }
 
        public string Name { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string UserId { get; set; }

     

    }
}
