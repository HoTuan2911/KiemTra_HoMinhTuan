using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_HoMinhTuan.Models;

namespace KiemTra_HoMinhTuan.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }


        //Details
        public ActionResult Details(string id)
        {
            var D_Sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_Sinhvien);
        }

        //Create
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_MaSV = collection["MaSV"];
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.MaSV = E_MaSV;
                sv.HoTen = E_HoTen.ToString();
                sv.GioiTinh = E_GioiTinh.ToString();
                sv.NgaySinh = E_NgaySinh;
                sv.Hinh = E_Hinh.ToString();
                sv.MaNganh = E_MaNganh.ToString();
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        //Edit
        public ActionResult Edit(string id)
        {
            var E_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_SinhVien);
        }

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];

            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_SinhVien.HoTen = E_HoTen;
                E_SinhVien.GioiTinh = E_GioiTinh;
                E_SinhVien.NgaySinh = E_NgaySinh;
                E_SinhVien.Hinh = E_Hinh;
                E_SinhVien.MaNganh = E_MaNganh;
                UpdateModel(E_SinhVien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }


        //Delete
        public ActionResult Delete(string id)
        {
            var D_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_SinhVien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_SinhVien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_SinhVien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}