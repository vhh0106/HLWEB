using HLWEB.Areas.Admin.Model;
using HLWEB.Common;
using HLWEB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLWEB.Areas.Admin.Controllers
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
            if (ModelState.IsValid)
            {
                var dao =new  UserDAO();
                var result = dao.Login(model.userName, Encryption.MD5Hash(model.passWord));
                if (result)
                {
                    var user = dao.GetById(model.userName);
                    var userSession = new UserLogin();
                    userSession.userName = user.userName;
                    userSession.userID = user.id;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai thong tin dang nhap!");
                }
                
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }
    }
    
}