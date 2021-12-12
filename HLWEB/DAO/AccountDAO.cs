using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using HLWEB.Models;
using Model.EF;
using PagedList;


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

        public long insertForFacebook(Register entity)
        {
            var account = db.Registers.SingleOrDefault(x => x.UserName == entity.UserName);
            if (account ==null)
            {
                db.Registers.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return account.ID;
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
        public bool Update(Register entity)
        {
            try
            {
                var account = db.Registers.Find(entity.ID);
                account.UserName = entity.UserName;
                account.Password = entity.Password;
                account.Name = entity.Name;
                account.Email = entity.Email;
                account.Address = entity.Address;
                account.PhoneNumber = entity.PhoneNumber;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var account = db.Registers.Find(id);
                db.Registers.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Register> ListAllPage(int page, int pageSize)
        {
            return db.Registers.OrderByDescending(p => p.ID).ToPagedList(page, pageSize);   
        }

        public Register ViewDetail(int id)
        {
            return db.Registers.Find(id);
        }
    }
}
