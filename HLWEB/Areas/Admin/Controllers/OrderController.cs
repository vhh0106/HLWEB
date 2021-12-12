using HLWEB.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace HLWEB.Areas.Admin.Controllers
{
    public class OrderController : SessionController
    {
        // GET: Admin/Order
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var orderDAO = new OrderDAO();
            var model = orderDAO.ListAllPage(page, pageSize);
            return View(model);
        }

        
        public ActionResult Detail(int id)
        {
            var orderDT = new OrderDetailDAO();
            var modell = orderDT.ListByOrderId(id);
            return View(modell);
        }
    }
}