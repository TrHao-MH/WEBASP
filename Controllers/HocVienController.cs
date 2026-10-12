using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using WEBASP.Models;

namespace WEBASP.Controllers
{
    public class HocVienController : Controller
    {
        private qlhvContext db = new qlhvContext();
        public async Task<IActionResult> Index()
        {
            List<Lylich> ds = await db.Lyliches.ToListAsync();
            return View(ds);
        }
        public async Task<IActionResult> Add()
        {
            List < Lop > ds = await db.Lops.ToListAsync();
            ViewBag.DSLop = new SelectList(ds,"Malop","Malop");
            return View(new CHocVien());
        }
        public async Task<IActionResult> aAdd(CHocVien x)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Lyliches.AddAsync(CHocVien.convert(x));
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", "Lỗi khi thêm");
                }
                
            }
            List<Lop> ds = await db.Lops.ToListAsync();
            ViewBag.DSLop = new SelectList(ds, "Malop", "Malop");
            return View("Add");
        }
        public async Task<IActionResult> Edit(string id)
        {
            Lylich hocVien = await db.Lyliches.FindAsync(id);
            List<Lop> dsl = await db.Lops.ToListAsync();
            ViewBag.DSLop = new SelectList(dsl, "Malop", "Malop");
                if(hocVien != null)
                    return View(CHocVien.convert(hocVien));
                return RedirectToAction("Index");
            
        }
        public async Task<IActionResult> aEdit(CHocVien x)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Lyliches.Update(CHocVien.convert(x));
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Lỗi khi sửa");
                }

            }
            List<Lop> ds = await db.Lops.ToListAsync();
            ViewBag.DSLop = new SelectList(ds, "Malop", "Malop");
            return View("Add");
        }
        public async Task<IActionResult> Delete(string id)
        {
            Lylich hocVien = await db.Lyliches.FindAsync(id);
            if (hocVien != null)
                return View(hocVien);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> aDelete(string id) {
            Lylich hv = await db.Lyliches.FindAsync(id);
            if (hv != null)
                try
                {
                    db.Lyliches.Remove(hv);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception e) {  }
            ModelState.AddModelError("", "Không xóa được học viên này");
            return RedirectToAction("Index");
        }
    }

}
