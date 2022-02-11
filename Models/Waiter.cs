using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Waiter
    {
        //primary key to Waiter
        public int Id { get; set; }

        //first name to the waiter
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //last name to the waiter
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //full name of waiter
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //hire date of waiter
        [Required]
        [Display(Name = "Hiring date")]
        public DateTime HireDate { get; set; }

        //position where the waiter tends tables. Example: inside, garden, balcony
        [Required]
        [StringLength(10)]
        [Display(Name = "Serving position")]
        public string ServingPosition { get; set; }

        //secondary key to Table
        public virtual ICollection<Table> Tables { get; set; }
    }
}
