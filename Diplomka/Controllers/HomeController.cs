using Microsoft.AspNetCore.Mvc;
using SqlData;
using SqlData.SqlGenerator;
using System;
using WebSiteCkEditor.Models;

namespace WebSiteCkEditor.Controllers
{

    public class HomeController : Controller
    {
        ISqlData data;
        public HomeController()
        {
            data = new SqlGenerator();
        }
        public ActionResult Index()
        {
            ClientModel m = new ClientModel();
            m.lst_newsv = data.SqlQuery<News>("select * from News where IsShow = 1");
            return View(m);
        }

        public ActionResult News(int id)
        {
            ClientModel m = new ClientModel();
            m.lst_newsv = data.SqlQuery<News>("select * from News where Id = @idd", new { idd = id });
            return View(m);
        }

        public ActionResult allNews()
        {
            ClientModel m = new ClientModel();
            m.lst_newsv = data.GetAll<News>();
            return View(m);
        }
        public ActionResult kafedra()
        {
            return View();
        }
        private ActionResult Autorize()
        {
            return View();
        }
    }
}