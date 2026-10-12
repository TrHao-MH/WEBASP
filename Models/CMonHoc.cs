using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WEBASP.Models
{
    public class CMonHoc
    {
        [Display (Name="Mã số môn học") ]
        [Required(ErrorMessage = "Bạn chưa nhập mã môn học")]
        public string Msmh { get; set; }
        [Display(Name = "Tên môn học")]
        [Required(ErrorMessage = "Bạn chưa nhập tên môn học")]
        public string Tenmh { get; set; }
        [Display(Name = "Số tiết")]
        [Required(ErrorMessage = "Bạn chưa nhập số tiết")]
        public int? Sotiet { get; set; }
        public static Monhoc Convert(CMonHoc mon)
        {
            return new Monhoc
            {
                Msmh= mon.Msmh,
                Tenmh= mon.Tenmh,
                Sotiet= mon.Sotiet,
            };
        }
        public static CMonHoc Convert(Monhoc mon)
        {
            return new CMonHoc
            {
                Msmh = mon.Msmh,
                Tenmh = mon.Tenmh,
                Sotiet = mon.Sotiet,
            };
        }

    }
}
