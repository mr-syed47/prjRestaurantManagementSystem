using Microsoft.AspNetCore.Mvc;
using prjRestaurantManagementSystem.Models;

namespace prjRestaurantManagementSystem.Controllers
{
    public class OrderDetailController : Controller
    {
        DBContext dBContext = new DBContext();

        public IActionResult Index()
        {
            var orderDetails = dBContext.OrderDetails.ToList();

            return View(orderDetails);
        }


        public IActionResult Edit(int id)
        {
            OrderDetail orderDetail;

            if (id == 0)
            {
                orderDetail = new OrderDetail();
            }
            else
            {
                orderDetail = dBContext.OrderDetails.Find(id);
            }

            ViewBag.Orders = dBContext.Orders.ToList();

            return View(orderDetail);
        }


        [HttpPost]
        public IActionResult Save(OrderDetail orderDetail)
        {
            dBContext.OrderDetails.Add(orderDetail);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Update(OrderDetail orderDetail)
        {
            dBContext.OrderDetails.Update(orderDetail);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            OrderDetail orderDetail = dBContext.OrderDetails.Find(id);

            dBContext.OrderDetails.Remove(orderDetail);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}