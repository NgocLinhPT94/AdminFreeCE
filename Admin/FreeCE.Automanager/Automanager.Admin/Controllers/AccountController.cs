using Automanager.Libraries.RepoImpl;
using Automanager.RepoInterface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Automanager.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepository _loginRepo = EngineContext.Current.Resolve<ILoginRepository>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Test ket noi he thong cac phuong thuc lam chua chặt chẽ
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public ActionResult TestLogin(string username,string pass)
        {
            var user = _loginRepo.Login(username, pass);
            if(user > 0)
            {
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("TestLogin");
            }
        }
    }
}