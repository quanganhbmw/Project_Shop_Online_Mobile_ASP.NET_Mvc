using MobileShopV.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShopV.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        // phan trang
        public ActionResult Index(int page=1, int pageSize =10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaing(page, pageSize);

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encrytedMp5 = Encrytor.MD5Hash(user.Password);
                user.Password = encrytedMp5;
                long id = dao.Insert(user);
                if(id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add sucessfully");
                }
            }
            return View("Index");
        }
    }
}