using BookingTicket.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingTicket.Helper;
using BookingTicket.Models;

namespace BookingTicket.Controllers
{
    public class KhachHangsController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: KhachHangs
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection login)
        {
            string username = login["username"];
            string pass = HelperString.toMD5(login["password"]);
            KhachHang kh = db.KhachHangs.FirstOrDefault(x => x.SDT == username || x.SDT == username && x.Password != null);
            if (kh == null)
            {
                TempData["error"] = "Đăng nhập sai!";
                TempData["suberror"] = "Tài khoản không được tồn tại";
            }
            else
            {
                if (kh.Password.Equals(pass))
                {
                    // đăng nhập đúng
                    string cus = JsonConvert.SerializeObject(kh); //json object->string
                    Session[ConstSession.CustomerSession] = cus;
                    Session[ConstSession.CustomerIdSession] = kh.Id;
                    TempData["success"] = "Đăng nhập thành công!";
                    return Redirect("~/");
                }
                else
                {
                    TempData["error"] = "Đăng nhập sai!";
                    TempData["suberror"] = "Mật khẩu không chính xác";
                }
            }
            return Redirect("~/");
        }
        public ActionResult Logout()
        {
            Session[ConstSession.CustomerSession] = "";
            Session[ConstSession.CustomerIdSession] = "";
            return Redirect("~/");
        }
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            var name = form["name"];
            var phone = form["phone"];
            var email = form["email"];
            var pass = HelperString.toMD5(form["password"]);
            var repass = HelperString.toMD5(form["repassword"]);
            var check = db.KhachHangs.FirstOrDefault(x => x.SDT == phone && x.Password != null);
            if (pass != repass)
            {
                ViewBag.Error = "Mật khẩu không khớp!";
                return Redirect("~/");
            }
            if (check != null)
            {
                ViewBag.Error = "Số điện thoại đã được đăng ký!";
                return Redirect("~/");
            }
            else
            {
                KhachHang cus = new KhachHang()
                {
                    TenKH = name,
                    SDT = phone,
                    Email = email,
                    Password = pass
                };
                db.KhachHangs.Add(cus);
                db.SaveChanges();
                TempData["success"] = "Đăng ký thành công!";
                return Redirect("~/");
            }
        }

    }


}