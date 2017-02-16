using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models; 


namespace WebApplication2.ViewModel
{
    public class CustomerViewModel
    {
        //Customer
        public Custi customer{ get; set; }
        //List of Customers
        public List<Custi> customers { get; set; }
    }
}