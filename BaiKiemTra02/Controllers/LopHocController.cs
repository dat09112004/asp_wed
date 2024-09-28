using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var lophoc = _db.LopHoc.ToList();
            ViewBag.LopHoc = lophoc;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng LopHoc
                _db.LopHoc.Add(lopHoc);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            return View(lophoc);
        }
        [HttpPost]
        public IActionResult Edit(LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng LopHoc
                _db.LopHoc.Update(lopHoc);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            return View(lophoc);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var lopHoc = _db.LopHoc.Find(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            _db.LopHoc.Remove(lopHoc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.LopHoc.Find(id);
            return View(lophoc);
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // sử dụng linq
                var lophoc = _db.LopHoc.
                Where(tl => tl.TenLopHoc.Contains(searchString)).ToList();

                ViewBag.SearchString = searchString;
                ViewBag.LopHoc = lophoc;
            }
            else
            {
                var lophoc = _db.LopHoc.ToList();
                ViewBag.LopHoc = lophoc;
            }
            return View("Index");
        }
    }
}
