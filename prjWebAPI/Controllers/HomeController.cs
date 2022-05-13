using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjWebAPI.Controllers
{
    // 可以假裝這是另一台電腦設計前端頁面，然後用AJAX非同步存取WebAPI的資料
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}