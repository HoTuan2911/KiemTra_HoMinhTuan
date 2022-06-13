using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_HoMinhTuan.Models;


namespace KiemTra_HoMinhTuan.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: NguoiDung

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var MaSV = collection["MaSV"];
            SinhVien sv = data.SinhViens.SingleOrDefault(m => m.MaSV == MaSV);
            if(sv != null)
            {
                ViewBag.ThongBao =  "Chuc mung ban da dang nhap thanh cong";
                Session["Taikhoan"] = sv;
            }
            else
            {
                ViewBag.ThongBao = "Mã SV bạn đã nhập sai hoặc không tồn tại";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}