using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class GuestNameViewModel
    {
        //search guests by first and last name
        public IList<Guest> Guests { get; set; }
        public string GuestFirstName { get; set; }
        public string GuestLastName { get; set; }
    }
}
