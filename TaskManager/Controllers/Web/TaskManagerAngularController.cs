using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers.Web
{
    public class TaskManagerAngularController : Controller
    {
        // GET: TaskManagerAngular
        public ActionResult Index()
        {
            return View();
        }
    }
}