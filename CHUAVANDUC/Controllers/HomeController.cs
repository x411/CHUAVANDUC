using CHUAVANDUC.Models;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHUAVANDUC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        MainMenuModel _mainModel;
        SubMenuModel _subModel;
        PostModel _postModel;

        public HomeController()
        {
            _mainModel = new MainMenuModel();
            _subModel = new SubMenuModel();
            _postModel = new PostModel();
        }

        [Route("~/")]
        [Route("~/trang-chu")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            //lấy hình banner

            //lấy data menu
            List<VD_MainMenu> _main = new List<VD_MainMenu>();
            _main = _mainModel.getListMainMenu();

            return PartialView(_main);
        }

        public ActionResult ColsRightBody()
        {
            return PartialView();
        }

        [Route("~/{categoryCode}", Name = "PostInCategory")]
        public ActionResult PostInCategory(string categoryCode)
        {
            return PartialView("~/Views/Home/PostInCategory.cshtml");
        }

        [Route("~/{mainMenu}", Name = "PostInMenu")]
        public ActionResult PostInMenu(string mainMenu)
        {
            return PartialView();
        }

        [Route("~/{mainMenu}/{subMenu}", Name = "PostInSubMenu")]
        public ActionResult PostInSubMenu(string mainMenu, string subMenu)
        {
            return PartialView();
        }

        public ActionResult PostInfo(long ID)
        {
            VD_POST _post = new VD_POST();
            _post = _postModel.getDetailsPost(ID);

            return PartialView(_post);
        }

        //[Route("{alias}.html", Name = "PostInCategory")]
        //public ActionResult PostInCategory(string CategoryCode, string SubCategoryCode, string alias)
        //{
        //    return View();
        //}
    }
}