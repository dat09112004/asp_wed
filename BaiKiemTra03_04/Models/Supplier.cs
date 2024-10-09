using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_04.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage =" Không được để trống tên nhà cung cấp")]
        [StringLength(20,ErrorMessage ="{0} Phải có độ dài phải từ {2} đến {1} ký tự", MinimumLength =5)]
        [Display(Name="Supplier")]
        public string Name { get; set; }
        [Required(ErrorMessage = " Không được để trống địa chỉ")]
        [StringLength(20, ErrorMessage = "{0} Phải có độ dài phải từ {2} đến {1} ký tự", MinimumLength = 5)]
        [Display(Name="Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = " Không được để trống Phone Number")]
        [StringLength(20, ErrorMessage = "{0} Phải có độ dài phải từ {2} đến {1} ký tự", MinimumLength = 5)]
        [Display(Name="Số điện thoại")]
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
