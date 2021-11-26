using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using HLWEB.Models;
using Model.EF;

namespace HLWEB.DAO
{
    public class AccountDAO
    {
        private ApplicationDbContext db = null;
        public AccountDAO()
        {
            db = new ApplicationDbContext();
        }
        public bool CheckUserName(string UserName)
        {
            return db.Registers.Count(x => x.UserName == UserName) > 0;
        }
        public bool Login(string UserName, string PassWord)
        {
            var result = db.Registers.Count(p => p.UserName == UserName && p.Password == PassWord);
            if (result > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public Register GetById(string userName)
        {
            return db.Registers.SingleOrDefault(p => p.UserName == userName);
        }
        public long Insert(Register entity)
        {
            try
            {
                db.Registers.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }
    }
}
