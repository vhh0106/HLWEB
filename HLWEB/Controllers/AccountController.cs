using HLWEB.DAO;
using HLWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using HLWEB.Common;

namespace HLWEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {
            return View(); 
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDAO();
                if (DAO.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại"); 
                }
                else
                {
                    var account = new Register();
                    account.UserName = model.UserName;
                    account.Password = Encryption.MD5Hash(model.Password);
                    account.ConfirmPassword = Encryption.MD5Hash(model.ConfirmPassword);
                    account.Name = model.Name;                   
                    account.Email = model.Email;
                    account.Address = model.Address;
                    account.PhoneNumber = model.PhoneNumber;
                    var result = DAO.Insert(account);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new Register();     
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }    
                }    
            }
            return View(model); 
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {     
                var DAO = new AccountDAO();
            var result = DAO.Login(model.UserName, Encryption.MD5Hash(model.Password));
            if (result)
            {
                var account = DAO.GetById(model.UserName);
                var accountSession = new AccountLogin();
                accountSession.UserName = account.UserName;
                accountSession.AccountID = account.ID;
                Session.Add(CommonConstant.ACCOUNT_SESSION, accountSession);
                ModelState.AddModelError("", "Đăng nhập thành công");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Sai thông tin đăng nhập!");
            }
            }
            return View(model);
        }
        


    }
}