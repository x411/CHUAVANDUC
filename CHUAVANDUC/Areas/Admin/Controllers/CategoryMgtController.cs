using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHUAVANDUC.Models;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Areas.Admin.Controllers
{
    public class CategoryMgtController : Controller
    {
        CategoryModel _cateModel;
        ResultResponse _rr;

        // GET: Admin/CategoryMgt
        public CategoryMgtController()
        {
            _rr = new ResultResponse();
            _cateModel = new CategoryModel();
        }

        public ActionResult Index()
        {
            List<VD_Category> _lst = new List<VD_Category>();
            _lst = _cateModel.getListCategory();

            return View(_lst);
        }
        public ActionResult getListCategory()
        {
            List<VD_Category> _lst = new List<VD_Category>();
            _lst = _cateModel.getListCategory();

            return PartialView(_lst);
        }

        public ActionResult EditCategory(string cateCode = "")
        {
            VD_Category _info = new VD_Category();
            if(!string.IsNullOrEmpty(cateCode))
            {
                _info = _cateModel.getDetailsCategory(cateCode);
            }
            else
            {
                _info.CategoryID = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("hhmmss");
            }

            return View(_info);
        }

        [HttpPost]
        public ActionResult InsertUpdateCategory(VD_Category category)
        {
            _rr = new ResultResponse();
            _rr = _cateModel.insertUpdateCategory(category);

            return Json(_rr);
        }

        [HttpPost]
        public ActionResult DeleteCategory(string cateCode)
        {
            _rr = new ResultResponse();
            _rr = _cateModel.deleteCategory(cateCode);

            return Json(_rr);
        }
    }
}