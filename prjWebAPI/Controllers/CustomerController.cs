using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using prjWebAPI.Models;

namespace prjWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // 建立dbCustomerEntities類別物件db，可以來存取dbCustomerEntities資料庫
        dbCustomerEntities db = new dbCustomerEntities();

        // GET: api/Customer
        public List<tCustomer> Get()
        {
            // 取得指定URL中tCustomer資料的每個詳細資料
            var customers = db.tCustomer.OrderBy(x => x.fId).ToList();
            return customers;
        }

        // GET: api/Customer/5
        public tCustomer Get(int id)
        {
            // 尋找tCustomer中id符合參數的資料
            var theCustomer = db.tCustomer.FirstOrDefault(x => x.fId == id);
            return theCustomer;
        }

        // POST: api/Customer
        public int Post(tCustomer customer) // 新增
        {
            int num = 0;
            try
            {
                tCustomer newCustomer = new tCustomer();
                newCustomer.fName = customer.fName;
                newCustomer.fPhone = customer.fPhone;
                newCustomer.fEmail = customer.fEmail;
                newCustomer.fAddress = customer.fAddress;
                db.tCustomer.Add(newCustomer);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                num = 0;
                throw;
            }
            return num;
        }

        // PUT: api/Customer/5
        public int Put(tCustomer customer)
        {
            int num = 0;
            try
            {
                var customerToEdit = db.tCustomer.Where(x => x.fId == customer.fId).FirstOrDefault();
                customerToEdit.fName = customer.fName;
                customerToEdit.fPhone = customer.fPhone;
                customerToEdit.fEmail = customer.fEmail;
                customerToEdit.fAddress = customer.fAddress;
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                num = 0;
                throw;
            }
            return num;
        }

        // DELETE: api/Customer/5
        public int Delete(int id)
        {
            int num = 0;
            try
            {
                var customerToDelete = db.tCustomer.Where(x => x.fId == id).FirstOrDefault();
                db.tCustomer.Remove(customerToDelete);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                num = 0;
                throw;
            }
            return num;
        }
    }
}
