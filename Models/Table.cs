using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Table
    {
        //primary key to Table
        public int Id { get; set; }

        //table number
        [Required]
        [Display(Name = "Table Number")]
        public int TableNumber { get; set; }

        //number of seats at table
        [Required]
        [Display(Name = "Number of seats")]
        public int SeatsNumber { get; set; }

        //placement of table in restaurant. Example: inside, garden, balcony
        [Required]
        [StringLength(10)]
        [Display(Name = "Placement of table")]
        public string PlacementTable { get; set; }

        //secondary key to Reservation
        public ICollection<Reservation> Reservations { get; set; }

        //secondary key to Waiter
        public int WaiterId { get; set; }
        [Display(Name = "Waiter")]
        public virtual Waiter Waiter { get; set; }

    }
}
