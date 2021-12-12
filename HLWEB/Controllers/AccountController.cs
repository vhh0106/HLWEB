using HLWEB.DAO;
using HLWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using HLWEB.Common;
using BotDetect.Web.Mvc;
using Facebook;
using System.Configuration;

namespace HLWEB.Controllers
{
    public class AccountController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
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
        [CaptchaValidationActionFilter("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
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
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSec"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type="code",
                scope ="email,"
            });
            return Redirect(loginUrl.AbsoluteUri); 
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
        {
            client_id = ConfigurationManager.AppSettings["FbAppId"],
            client_secret = ConfigurationManager.AppSettings["FbAppSec"],
            redirect_uri = RedirectUri.AbsoluteUri,
            code = code
            
        });
            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_nam,last_name,i d,email");
                string email = me.email;
                string username = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                var account = new Register();
                account.Email = email;
                account.UserName = email;
                account.Name = firstname + " " + middlename + " " + lastname;
                var resultInsert = new AccountDAO().insertForFacebook(account);
                if (resultInsert >0) {
                    var accountSession = new AccountLogin();
                    accountSession.UserName = account.UserName;
                    accountSession.AccountID = account.ID;
                    Session.Add(CommonConstant.ACCOUNT_SESSION, accountSession);
                    
                }
            }
            return Redirect("/");

        }
        public ActionResult Logout()
        {
            Session[CommonConstant.ACCOUNT_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDAO();
                var result = DAO.Login(model.UserName, Encryption.MD5Hash(model.Password));
                if (Convert.ToInt32(result) == 1)
                {
                    var account = DAO.GetById(model.UserName);
                    var accountSession = new AccountLogin();
                    accountSession.UserName = account.UserName;
                    accountSession.AccountID = account.ID;  
                    Session.Add(CommonConstant.ACCOUNT_SESSION, accountSession);
                    ModelState.AddModelError("", "Đăng nhập thành công");
                    return RedirectToAction("Index", "Home");
                }
            
            else if (Convert.ToInt32(result) == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại.");
            }
            else if (Convert.ToInt32(result) == -1)
            {
                ModelState.AddModelError("", "Tài khoản đang bị khoá.");
            }
            else if (Convert.ToInt32(result) == -2)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng.");
            }
            else
            {
                ModelState.AddModelError("", "đăng nhập không đúng.");
            }
        }
            return View(model);
    }



}
}