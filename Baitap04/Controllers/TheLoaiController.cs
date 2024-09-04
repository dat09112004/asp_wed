using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Baitap04.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit( int id)
        {
            return Ok("id: " + id);
        }
        public IActionResult Detail(int id, string ten)
        {
            //return Content("id: " + id + "; ten: "+ ten);
            return Content(string.Format("id: {0}; ten: {1}", id, ten));
        }
        public IActionResult Show(List<string> categories)
        {
            string content = " Danh sach the loai: ";
            foreach (var category in categories)
            {
                content = content +" " + category + ", ";                      
            }
            return Content(content);
        }

    }
}
