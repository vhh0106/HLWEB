using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HLWEB.DAO;
using Model.EF;

namespace HLWEB.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Founder
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var DAO = new AccountDAO();
            var model = DAO.ListAllPage(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Register account)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDAO();
                var id = DAO.Insert(account);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm dữ liệu không thành công!");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var account = new AccountDAO().ViewDetail(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(Register account)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDAO();
                var result = DAO.Update(account);
                if (result)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dữ liệu không thành công!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var DAO = new AccountDAO();
                var result = DAO.Delete(id);
                if (result)
                {
                    return RedirectToAction("Index", "Founder");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa dữ liệu không thành công!");
                }
            }
            return View("Index");
        }
    }
}