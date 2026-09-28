using Microsoft.AspNetCore.Mvc;
using prjRestaurantManagementSystem.Models;

namespace prjRestaurantManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        DBContext dBContext = new DBContext();

        public IActionResult Index()
        {
            var customers = dBContext.Customers.ToList();

            return View(customers);
        }


        public IActionResult Edit(int id)
        {
            Customer customer;

            if (id == 0)
            {
                customer = new Customer();
            }
            else
            {
                customer = dBContext.Customers.Find(id);
            }

            return View(customer);
        }


        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            dBContext.Customers.Add(customer);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            dBContext.Customers.Update(customer);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Customer customer = dBContext.Customers.Find(id);

            dBContext.Customers.Remove(customer);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}