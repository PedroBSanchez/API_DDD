using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Notifies
    {

        public Notifies()
        {
            Notifications = new List<Notifies>();
        }

        [NotMapped]
        public string propertyName { get; set; }

        [NotMapped]
        public string message { get; set; }

        [NotMapped]
        public List<Notifies> Notifications { get; set; }


        public bool isValidStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    message = "Required field",
                    propertyName = propertyName
                });

                return false;
            }

            return true;
        }


        public bool isValidIntProperty(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notifies
                {
                    message = "Campo obrigatório",
                    propertyName = propertyName
                });

                return false;
            }

            return true;
        }

    }
}
