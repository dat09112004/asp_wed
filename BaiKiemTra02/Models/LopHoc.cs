using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TenLopHoc { get; set; }
        public DateTime NgayNhapHoc { get; set; } = DateTime.Now;
        public DateTime NgayRaTruong { get; set;} = DateTime.Now;
        public int SoLuongSinhVien { get; set; }
    }
}
