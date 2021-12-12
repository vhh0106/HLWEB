using System.Web;
using System.Text;
using System.Threading.Tasks;
using HLWEB.Models;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HLWEB.DAO
{
    public class OrderDAO
    {
        ApplicationDbContext db = null;
        public OrderDAO()
        {
            db = new ApplicationDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }

        public IEnumerable<Order> ListAllPage(int page, int pageSize)
        {
            return db.Orders.OrderByDescending(p => p.OrderID).ToPagedList(page, pageSize);
        }
    }
}