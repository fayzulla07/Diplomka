using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteCkEditor;
using WebSiteCkEditor.Models;
using SqlData;
using System.Data.SqlClient;

using System.Threading;
using System.Threading.Tasks;
using System.Net;
using SqlData.SqlGenerator;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace WebSiteCkEditor.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        ISqlData data;
        public AdminController()
        {
            data = new SqlGenerator();

        }
        // GET: Admin
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string Login, string Pass)
        {
            if (Login == "admin" && Pass == "admin")
            {
                var claims = new List<Claim>
                {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, "admin"),
                };
                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                // установка аутентификационных куки
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(id));
                await HttpContext.AuthenticateAsync();

                return RedirectToAction("news", "admin");
            }
            else
            {
                return RedirectToAction("Login", "admin");
            }

        }
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
        public ActionResult News()
        {
            AdminNewModel n = new AdminNewModel();
            n.lst_news = data.GetAll<News>();
            return View(n);
        }
        public ActionResult CkEditorNews(int id)
        {
            AdminNewModel n = new AdminNewModel();
            if(id != 0)
            {
                n.news = data.GetById<News>(id);
            }
            return View(n);
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult CkEditorNews(News item)
        {
            News val = item;
            if(val.Id != 0)
            {
                data.Update<News>(val);
            }
            else
            {
                data.Add<News>(item);
            }
            return Redirect("/admin/News");
        }
        [HttpPost]
        public ActionResult DeleteNews(int Id)
        {
            if(Id != 0)
            {
                data.Remove<News>(Id);
            }
           
            return Redirect("/admin/News");
        }

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

    }
}