using HLWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace HLWEB.DAO
{
    public class OrderDetailDAO
    {
        public ApplicationDbContext db;
        public OrderDetailDAO()
        {
            db = new ApplicationDbContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public OrderDetail ViewDetail(long id)
        {
            return db.OrderDetails.Find(id);
        }
        public List<OrderDetail> ListByOrderId(int id)
        {
            return db.OrderDetails.Where(p => p.OrderID == id).OrderByDescending(p => p.OrderID).ToList();
        }
    }
}