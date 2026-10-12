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
    }
}
