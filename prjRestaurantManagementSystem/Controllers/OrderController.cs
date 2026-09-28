using Microsoft.AspNetCore.Mvc;
using prjRestaurantManagementSystem.Models;

namespace prjRestaurantManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        DBContext dBContext = new DBContext();

        public IActionResult Index()
        {
            var orders = dBContext.Orders.ToList();

            return View(orders);
        }


        public IActionResult Edit(int id)
        {
            Order order;

            if (id == 0)
            {
                order = new Order();
            }
            else
            {
                order = dBContext.Orders.Find(id);
            }

            ViewBag.Customers = dBContext.Customers.ToList();

            return View(order);
        }


        [HttpPost]
        public IActionResult Save(Order order)
        {
            dBContext.Orders.Add(order);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Update(Order order)
        {
            dBContext.Orders.Update(order);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            Order order = dBContext.Orders.Find(id);

            dBContext.Orders.Remove(order);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}