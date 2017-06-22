using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Areas.Admin.Controllers
{
    public class PostsMgtController : Controller
    {
        ResultResponse _rr;
        // GET: Admin/PostsMgt
        public PostsMgtController()
        {
            _rr = new ResultResponse();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getListPosts()
        {
            return PartialView();
        }

        public ActionResult EditPosts(long PostsID)
        {
            return View();
        }

        public ActionResult InsertUpdatePosts(VD_POST posts)
        {
            _rr = new ResultResponse();
            return Json(_rr);
        }

        public ActionResult DeletePosts(long PostsID)
        {
            _rr = new ResultResponse();

            return Json(_rr);
        }
    }
}