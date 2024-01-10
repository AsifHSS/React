using CRM_Portal.Interfaces;
using CRM_Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Portal.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsers entity;
        private readonly IConfiguration configuration;
       public UsersController(IUsers _entitty, IConfiguration _configuration)
        {
            entity = _entitty;
            configuration = _configuration;
        }

        // GET: UsersController
        public ActionResult Login()
        {
            Users user = new Users();
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            try
            {
               // string connString =configuration.GetConnectionString("Crm_PortalEntities"); //ConfigurationManager.ConnectionStrings["Crm_PortalEntities"].ConnectionString.;
             //   var abc = entity.GetAll();
                //using (var entities=new CRM_PortalDbContext())
                //{

                //        var _log = entities.tblUsers.Where(t => t.Username == model.Username && t.Password == model.Password).FirstOrDefault();
                //        if (_log != null)
                //        {
                //            return RedirectToAction("Index", "Home");
                //        }
                //        else
                //        {
                //            return RedirectToAction("Login", "Users",model);
                //        }

                //}
                string connString = this.configuration.GetConnectionString("Crm_PortalEntities");
             
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = "select * from tblUsers where Username=@username and Password=@password";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("username", model.Username);
                            command.Parameters.AddWithValue("password", model.Password);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    if (reader.GetInt32(0) > 0)
                                    {
                                        return RedirectToAction("Index", "Home");
                                    }
                                }
                            }
                        }
                    }
              

                Users user = new Users();
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Users", model);
                //throw ex;
            }

        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View(entity.GetAll());
        }
        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
