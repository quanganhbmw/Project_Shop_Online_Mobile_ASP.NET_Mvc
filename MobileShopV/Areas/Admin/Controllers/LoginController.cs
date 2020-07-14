using MobileShopV.Areas.Admin.Models;
using MobileShopV.Common;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShopV.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
              {
                var dao = new UserDao();
                var result = dao.Login(model.UserNamee, Encrytor.MD5Hash(model.PassWordd));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserNamee);
                    var userSession = new UserLogin();
                    userSession.UseerName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "tai khoan khong ton tai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "tai khoan dang bi khoa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "mat khau khong dung");
                }
                else 
                {
                    ModelState.AddModelError("", "dang nhap khong dung ");
                }
            }
            return View("Index");
        }
    }
}