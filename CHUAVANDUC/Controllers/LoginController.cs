using CHUAVANDUC.Models;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CHUAVANDUC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        LoginModels _model;
        ResultResponse rr;

        public LoginController()
        {
            _model = new LoginModels();
            rr = new ResultResponse();
        }

        private ActionResult RedirectToLocal(string redirectUrl)
        {
            if (Url.IsLocalUrl(redirectUrl))
            {
                return Redirect(redirectUrl);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName = "", string Password = "", bool Remember = false, string returnUrl = "")
        {
            VD_USERS _user = new VD_USERS();
            _user = _model.Login(UserName, Password);

            if (_user != null && !string.IsNullOrEmpty(_user.UserName))
            {
                Session["Roles"] = _user.UserTypeID;
                FormsAuthentication.SetAuthCookie(_user.UserTypeID, Remember);

                if (_user.UserTypeID == "0")
                {
                    //admin
                    returnUrl = "/Admin/Index";
                }
            }

            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "/Login/Index";
            }

            return RedirectToLocal(returnUrl);
        }

        [Route("~/Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}