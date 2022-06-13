using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_HoMinhTuan.Models;

namespace KiemTra_HoMinhTuan.Controllers
{
    public class HocPhanController : Controller
    {

        MyDataDataContext data = new MyDataDataContext();
        // GET: HocPhan
        public ActionResult ListHocPhan()
        {
            var all_HocPhan = from hp in data.HocPhans select hp;
            return View(all_HocPhan);
        }
    }
}