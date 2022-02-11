using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Reservation
    {
        //primary key to Reservation
        public int Id { get; set; }

        //name of reservation
        [Required]
        [Display(Name = "Name of reservation")]
        [StringLength(50)]
        public string NameReservation { get; set; }

        //secondary key to Guest
        public int GuestId { get; set; }
        [Display(Name = "Guest Name")]
        public virtual Guest Guest { get; set; }

        //secondary key to Table
        public int TableId { get; set; }
        [Display(Name = "Table Number")]
        public virtual Table Table { get; set; }

        //date of reservation
        [Required]
        [Display(Name = "Date")]
        public DateTime DateReservation { get; set; }

        //time of reservation
        [Required]
        [Display(Name = "Duration")]
        [StringLength(5, MinimumLength = 1)]
        public string DurationReservation { get; set; }

        //number of people, for whom is the reservation
        [Display(Name = "Table For")]
        public int TableFor { get; set; }

        //status of reservation. Example: missed, now, payed for, etc...
        [Required]
        [Display(Name = "Status")]
        [StringLength(25)]
        public string Status { get; set; }

    }
}
