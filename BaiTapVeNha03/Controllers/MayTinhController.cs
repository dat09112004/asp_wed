using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha03.Controllers
{
    public class MayTinhController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MayTinh(int a = 0, int b = 0, string pheptinh = "")
        {
            int  ketqua = 0;
            string message = "";

            // Sử dụng câu lệnh if để thực hiện phép toán
            if (pheptinh == "cong")
            {
                ketqua = a + b;
            }
            else if (pheptinh == "tru")
            {
                ketqua = a - b;
            }
            else if (pheptinh == "nhan")
            {
                ketqua = a * b;
            }
            else if (pheptinh == "chia")
            {
                if (b != 0)
                {
                    ketqua = a / b;
                }
                else
                {
                    message = "Không thể chia cho 0";
                }
            }
            else
            {
                message = "Phép tính không hợp lệ";
            }

            // Lưu kết quả vào ViewBag
            ViewBag.KetQua = (message == "") ? $"Kết quả của {pheptinh} là: {ketqua}" : message;

            // Trả về View
            return View();
        }

    }
}
