using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Guest
    {
        //primary key for Guest
        public int Id { get; set; }

        //first name of guest
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //last name of guest
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //full name of guest
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //phone number of guest, posible formats: +389 7x xxx xxx or 07x xxx xxx 
        [Required]
        [StringLength(12, MinimumLength = 9)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //acquired points (by dining in the restaurant) that the guest can later use to pay the bill
        [Required]
        [Display(Name = "Points")]
        public int? Points { get; set; }

        //secondary key to Reservation. A guest can make MANY reservations, but a reservation belongs to ONE guest
        public ICollection<Reservation> Reservations { get; set; }

    }
}
