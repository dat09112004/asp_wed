using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_04.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Order> order = _db.Order.Include("Supplier").ToList();
            return View(order);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Order order = new Order();
            IEnumerable<SelectListItem> dssupplier = _db.Supplier.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                }
                );
            ViewBag.DSSUPPLIER = dssupplier;

            if (id == 0)
            {
                return View(order);
            }
            else
            {
                order = _db.Order.Include("Supplier").FirstOrDefault(sp => sp.Id == id);
                return View(order);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Id == 0)
                {
                    _db.Order.Add(order);
                }
                else
                {
                    _db.Order.Update(order);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _db.Order.FirstOrDefault(sp => sp.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            _db.Order.Remove(order);
            _db.SaveChanges();
            return Json(new { success = true });
        }

    }
}