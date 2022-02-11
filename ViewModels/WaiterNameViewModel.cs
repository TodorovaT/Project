using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class WaiterNameViewModel
    {
        //search waiters by first and last name
        public IList<Waiter> Waiters { get; set; }
        public string WaiterFirstName { get; set; }
        public string WaiterLastName { get; set; }
    }
}
