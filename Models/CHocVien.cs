using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WEBASP.Models
{
    public class CHocVien 
    {
        [Display(Name = "Mã số học viên")]
        [Required(ErrorMessage ="Bạn chưa nhập mã sinh viên")]
        public string Mshv { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Bạn chưa nhập tên sinh viên")]
        public string Tenhv { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Bạn chưa nhập ngày sinh")]
        public DateTime? Ngaysinh { get; set; }

        [Display(Name = "Phái")]
        [Required(ErrorMessage = "Bạn chưa nhập phái")]
        public bool? Phai { get; set; }

        [Display(Name = "Mã Lớp")]
        [Required(ErrorMessage = "Bạn chưa nhập mã lớp")]
        public string Malop { get; set; }

        public static Lylich convert(CHocVien chocVien)
        {
            return new Lylich
            {
                Mshv = chocVien.Mshv,
                Tenhv = chocVien.Tenhv,
                Ngaysinh = chocVien.Ngaysinh,
                Phai = chocVien.Phai,
                Malop = chocVien.Malop,
            };
        }
        public static CHocVien convert(Lylich lylich)
        {
            return new CHocVien
            {
                Mshv = lylich.Mshv,
                Tenhv = lylich.Tenhv,
                Ngaysinh = lylich.Ngaysinh,
                Phai = lylich.Phai,
                Malop = lylich.Malop,
            };
        }
    }
}
