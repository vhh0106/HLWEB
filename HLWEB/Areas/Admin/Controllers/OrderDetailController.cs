using HLWEB.DAO;
using HLWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HLWEB.Areas.Admin.Controllers
{
    public class OrderDetailController : SessionController
    {
        // GET: Admin/OrderDetail
        public ActionResult Index()
        //public ActionResult Index(int page = 1, int pageSize = 10)
        {
            
            /*var orderDAO = new OrderDetailDAO();
            var model = orderDAO.ListAllPage(page, pageSize);
            return View(model);*/
            return View();
        }
        

    }
}