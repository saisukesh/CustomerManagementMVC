using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Dal;
using WebApplication2.ViewModel;
using System.Threading;


namespace WebApplication2.Controllers
{
  
    public class CustoController : Controller
    {
        // GET: Custo
        public ActionResult Load()
        {
            Custi obj = new Custi { CustomerCode = "40", CustomerName="Sukesh" };
            return View("Custome",obj);
        }
        public ActionResult Enter()
        {
            //View mOdel object
            CustomerViewModel obj = new CustomerViewModel();
            //single object is fresh
            obj.customer = new Custi();
            return View("EnterCustome", obj);
        }
        public ActionResult EnterSearch()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.customers = new List<Custi>();
            return View("SearchCustomer", obj);
        }
        public ActionResult getCustomers()//gives  JSON collection
        {
            CustomerDal dal = new CustomerDal();
            List<Custi> customerscoll = dal.Customers.ToList<Custi>();
            Thread.Sleep(1000);
            return Json(customerscoll, JsonRequestBehavior.AllowGet);// Req behaviour allows to get called by http func  
        }
        
        public ActionResult SearchCustomer()
        {
            
            CustomerViewModel obj = new CustomerViewModel();
            CustomerDal dal = new CustomerDal();
            string str= Request.Form["txtCustomerName"].ToString();
            List<Custi> customerscoll
                = (from x in dal.Customers
                   where x.CustomerName == str select x).ToList<Custi>();
            obj.customers = customerscoll;
            return View("SearchCustomer", obj);
        }
        public ActionResult Submit()//validation runs and errors ar send to obj called as model state 
        {
            
            Custi obj = new Custi();
            obj.CustomerName = Request.Form["customer.CustomerName"];
            obj.CustomerCode = Request.Form["customer.CustomerCode"];
            if (ModelState.IsValid)
            {
                //insert the customer object to database
                //EF DAL
                
                    CustomerDal Dal = new CustomerDal();
                    Dal.Customers.Add(obj);//in memory updation
                    Dal.SaveChanges();//physical commit 
            }

            CustomerDal dal = new CustomerDal();
            List<Custi> customerscoll= dal.Customers.ToList<Custi>();
            return Json(customerscoll, JsonRequestBehavior.AllowGet);
         }
    }


}