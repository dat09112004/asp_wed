using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DonHangController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();
            return View(hoadon);
        }
        public IActionResult Sua(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var hoadon = _db.HoaDon.Find(id);
            return View(hoadon);
        }

        [HttpPost]
        public IActionResult Sua(HoaDon hoadon)
        {
            if (ModelState.IsValid)
            {
                _db.HoaDon.Update(hoadon);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var hoadon = _db.HoaDon.Find(id);
            return View(hoadon);
        }

        [HttpPost]
        public IActionResult RemoveConform(int id)
        {
            var hoadon = _db.HoaDon.Find(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            _db.HoaDon.Remove(hoadon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
