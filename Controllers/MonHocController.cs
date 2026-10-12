using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBASP.Models;

namespace WEBASP.Controllers
{
    public class MonHocController : Controller
    {
        private qlhvContext db=new qlhvContext();
        public async Task<IActionResult> Index()
        {
            List<Monhoc> ds= await db.Monhocs.ToListAsync();
            return View(ds);
        }
        public async Task<IActionResult> Add() {
            return View(new CMonHoc());
        }
        public async Task<IActionResult> aAdd(CMonHoc x)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Monhocs.AddAsync(CMonHoc.Convert(x));
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Lỗi khi thêm");
                }

            }
            return View("Add");
        }
    }
}
