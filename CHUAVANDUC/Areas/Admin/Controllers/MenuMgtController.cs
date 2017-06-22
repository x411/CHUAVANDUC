using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Areas.Admin.Controllers
{
    public class MenuMgtController : Controller
    {
        ResultResponse _rr;
        // GET: Admin/MenuMgt
        public MenuMgtController()
        {
            _rr = new ResultResponse();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getListMainmenu()
        {
            return PartialView();
        }

        public ActionResult EditMainmenu(long ID)
        {
            return View();
        }

        public ActionResult InsertUpdateMainmenu(VD_MainMenu mainMenu)
        {
            _rr = new ResultResponse();
            return Json(_rr);
        }

        public ActionResult DeleteMainmenu(long ID)
        {
            _rr = new ResultResponse();

            return Json(_rr);
        }

        public ActionResult getSubmenuDetails(long ID)
        {
            return View();
        }

        public ActionResult InsertUpdateSubmenu(VD_SubMenu subMenu)
        {
            _rr = new ResultResponse();
            return Json(_rr);
        }

        public ActionResult DeleteSubmenu(long ID)
        {
            _rr = new ResultResponse();

            return Json(_rr);
        }


    }
}