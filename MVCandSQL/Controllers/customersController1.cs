using CRUDWithAdoNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static CRUDWithAdoNet.Models.CustomerDAL;

namespace MVCandSQL.Controllers
{
    public class customersController1 : Controller
    {
        public readonly IConfiguration configuration;
        CustomersDAL customersDAL;

        public customersController1(IConfiguration configuration)
        {
            this.configuration = configuration;
            customersDAL = new CustomersDAL(this.configuration);
        }
        [HttpGet]

        public IActionResult CustomerList()
        {
            var model = customersDAL.GetAllCustomers();
            return View(model);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(customers cust)
        {
            try
            {
                int result = customersDAL.AddCustomer(cust);
                if(result == 1)
                {
                    return RedirectToAction("CustomerList");

                }
                else
                {
                    return View(cust);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cust = customersDAL.GetCustomerById(id);
            return View(cust);
        }
        [HttpPost]

        public IActionResult Edit(customers cust)
        {
            try
            {
                int result = customersDAL.UpdateCustomer(cust);
                if (result == 1)
                {
                    return RedirectToAction("CustomerList");

                }
                else
                {
                    return View(cust);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var cust = customersDAL.GetCustomerById(id);
            return View(cust);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cust = customersDAL.GetCustomerById(id);
            return View(cust);
        }
        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = customersDAL.DeleteCustomer(id);
                if (result == 1)
                {
                    return RedirectToAction("CustomerList");

                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
