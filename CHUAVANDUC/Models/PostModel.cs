using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class PostModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_POST> getListPost()
        {
            List<VD_POST> lst = new List<VD_POST>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_POST");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_POST
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            CategoryID = Convert.ToString(row["CategoryID"]),
                            CategoryName = Convert.ToString(row["CategoryName"]),
                            MetaTitleCategory = Convert.ToString(row["MetaTitleCategory"]),
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(row["MainMenuName"]),
                            MetaTitleMainMenu = Convert.ToString(row["MetaTitleMainMenu"]),
                            SubMenuID = Convert.ToString(row["SubMenuID"]),
                            SubMenuName = Convert.ToString(row["SubMenuName"]),
                            MetaTitleSubMenu = Convert.ToString(row["MetaTitleSubMenu"]),
                            TitlePost = Convert.ToString(row["TitlePost"]),
                            ContentPost = Convert.ToString(row["ContentPost"]),
                            CreatedBy = Convert.ToString(row["CreatedBy"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            ChangeBy = Convert.ToString(row["ChangeBy"]),
                            ChangeDate = Convert.ToDateTime(row["ChangeDate"]),
                            IsPublish = Convert.ToBoolean(row["IsPublish"]),
                            IsSlide = Convert.ToBoolean(row["IsSlide"]),
                            IsHome = Convert.ToBoolean(row["IsHome"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Comment = Convert.ToString(row["Comment"]),
                            ImagesDisplay = Convert.ToString(row["ImagesDisplay"]),
                            ShortDescription = Convert.ToString(row["ShortDescription"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            AdminComment = Convert.ToString(row["AdminComment"])
                        });
                    }
                }
            }

            return lst;
        }

        public List<VD_POST> getListPostByDate(DateTime fromDate, DateTime toDate, string categoryID)
        {
            List<VD_POST> lst = new List<VD_POST>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetListPostByDate("WEB_VD_GETLIST_POST_BY_CATEGORY_BY_DATE", fromDate, toDate, categoryID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_POST
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            CategoryID = Convert.ToString(row["CategoryID"]),
                            CategoryName = Convert.ToString(row["CategoryName"]),
                            MetaTitleCategory = Convert.ToString(row["MetaTitleCategory"]),
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(row["MainMenuName"]),
                            MetaTitleMainMenu = Convert.ToString(row["MetaTitleMainMenu"]),
                            SubMenuID = Convert.ToString(row["SubMenuID"]),
                            SubMenuName = Convert.ToString(row["SubMenuName"]),
                            MetaTitleSubMenu = Convert.ToString(row["MetaTitleSubMenu"]),
                            TitlePost = Convert.ToString(row["TitlePost"]),
                            ContentPost = Convert.ToString(row["ContentPost"]),
                            CreatedBy = Convert.ToString(row["CreatedBy"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            ChangeBy = Convert.ToString(row["ChangeBy"]),
                            ChangeDate = Convert.ToDateTime(row["ChangeDate"]),
                            IsPublish = Convert.ToBoolean(row["IsPublish"]),
                            IsSlide = Convert.ToBoolean(row["IsSlide"]),
                            IsHome = Convert.ToBoolean(row["IsHome"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Comment = Convert.ToString(row["Comment"]),
                            ImagesDisplay = Convert.ToString(row["ImagesDisplay"]),
                            ShortDescription = Convert.ToString(row["ShortDescription"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            AdminComment = Convert.ToString(row["AdminComment"])
                        });
                    }
                }
            }

            return lst;
        }

        public VD_POST getDetailsPost(long ID)
        {
            VD_POST info = new VD_POST();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.getPostByID("WEB_VD_GET_DETAILS_POST", ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    info.CategoryID = Convert.ToString(ds.Tables[0].Rows[0]["CategoryID"]);
                    info.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    info.MetaTitleCategory = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleCategory"]);
                    info.MainMenuID = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuID"]);
                    info.MainMenuName = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuName"]);
                    info.MetaTitleMainMenu = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleMainMenu"]);
                    info.SubMenuID = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuID"]);
                    info.SubMenuName = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuName"]);
                    info.MetaTitleSubMenu = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleSubMenu"]);
                    info.TitlePost = Convert.ToString(ds.Tables[0].Rows[0]["TitlePost"]);
                    info.ContentPost = Convert.ToString(ds.Tables[0].Rows[0]["ContentPost"]);
                    info.CreatedBy = Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
                    info.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                    info.ChangeBy = Convert.ToString(ds.Tables[0].Rows[0]["ChangeBy"]);
                    info.ChangeDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChangeDate"]);
                    info.IsPublish = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPublish"]);
                    info.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"]);
                    info.IsHome = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHome"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.Comment = Convert.ToString(ds.Tables[0].Rows[0]["Comment"]);
                    info.ImagesDisplay = Convert.ToString(ds.Tables[0].Rows[0]["ImagesDisplay"]);
                    info.ShortDescription = Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription"]);
                    info.MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);
                    info.MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                    info.MetaTitle = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitle"]);
                    info.AdminComment = Convert.ToString(ds.Tables[0].Rows[0]["AdminComment"]);
                }
            }

            return info;
        }

        public List<VD_POST> getAllPostByCategory(string CategoryCode)
        {
            List<VD_POST> lst = new List<VD_POST>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GETLIST_POST_BY_CATEGORY", CategoryCode);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_POST
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            CategoryID = Convert.ToString(row["CategoryID"]),
                            CategoryName = Convert.ToString(row["CategoryName"]),
                            MetaTitleCategory = Convert.ToString(row["MetaTitleCategory"]),
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(row["MainMenuName"]),
                            MetaTitleMainMenu = Convert.ToString(row["MetaTitleMainMenu"]),
                            SubMenuID = Convert.ToString(row["SubMenuID"]),
                            SubMenuName = Convert.ToString(row["SubMenuName"]),
                            MetaTitleSubMenu = Convert.ToString(row["MetaTitleSubMenu"]),
                            TitlePost = Convert.ToString(row["TitlePost"]),
                            ContentPost = Convert.ToString(row["ContentPost"]),
                            CreatedBy = Convert.ToString(row["CreatedBy"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            ChangeBy = Convert.ToString(row["ChangeBy"]),
                            ChangeDate = Convert.ToDateTime(row["ChangeDate"]),
                            IsPublish = Convert.ToBoolean(row["IsPublish"]),
                            IsSlide = Convert.ToBoolean(row["IsSlide"]),
                            IsHome = Convert.ToBoolean(row["IsHome"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Comment = Convert.ToString(row["Comment"]),
                            ImagesDisplay = Convert.ToString(row["ImagesDisplay"]),
                            ShortDescription = Convert.ToString(row["ShortDescription"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            AdminComment = Convert.ToString(row["AdminComment"])
                        });
                    }
                }
            }

            return lst;
        }

        public List<VD_POST> getListPostByMenu(string MainID, string SubID)
        {
            List<VD_POST> lst = new List<VD_POST>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.getListPostByMenu("WEB_VD_GETLIST_POST_BY_MENU", MainID, SubID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_POST
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            CategoryID = Convert.ToString(row["CategoryID"]),
                            CategoryName = Convert.ToString(row["CategoryName"]),
                            MetaTitleCategory = Convert.ToString(row["MetaTitleCategory"]),
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(row["MainMenuName"]),
                            MetaTitleMainMenu = Convert.ToString(row["MetaTitleMainMenu"]),
                            SubMenuID = Convert.ToString(row["SubMenuID"]),
                            SubMenuName = Convert.ToString(row["SubMenuName"]),
                            MetaTitleSubMenu = Convert.ToString(row["MetaTitleSubMenu"]),
                            TitlePost = Convert.ToString(row["TitlePost"]),
                            ContentPost = Convert.ToString(row["ContentPost"]),
                            CreatedBy = Convert.ToString(row["CreatedBy"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            ChangeBy = Convert.ToString(row["ChangeBy"]),
                            ChangeDate = Convert.ToDateTime(row["ChangeDate"]),
                            IsPublish = Convert.ToBoolean(row["IsPublish"]),
                            IsSlide = Convert.ToBoolean(row["IsSlide"]),
                            IsHome = Convert.ToBoolean(row["IsHome"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            Comment = Convert.ToString(row["Comment"]),
                            ImagesDisplay = Convert.ToString(row["ImagesDisplay"]),
                            ShortDescription = Convert.ToString(row["ShortDescription"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            AdminComment = Convert.ToString(row["AdminComment"])
                        });
                    }
                }
            }

            return lst;
        }

        public VD_POST getPostIndexByCategory(string CateID)
        {
            VD_POST info = new VD_POST();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_POST_INDEX_BY_CATEGORY", CateID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    info.CategoryID = Convert.ToString(ds.Tables[0].Rows[0]["CategoryID"]);
                    info.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    info.MetaTitleCategory = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleCategory"]);
                    info.MainMenuID = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuID"]);
                    info.MainMenuName = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuName"]);
                    info.MetaTitleMainMenu = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleMainMenu"]);
                    info.SubMenuID = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuID"]);
                    info.SubMenuName = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuName"]);
                    info.MetaTitleSubMenu = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleSubMenu"]);
                    info.TitlePost = Convert.ToString(ds.Tables[0].Rows[0]["TitlePost"]);
                    info.ContentPost = Convert.ToString(ds.Tables[0].Rows[0]["ContentPost"]);
                    info.CreatedBy = Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
                    info.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                    info.ChangeBy = Convert.ToString(ds.Tables[0].Rows[0]["ChangeBy"]);
                    info.ChangeDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChangeDate"]);
                    info.IsPublish = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsPublish"]);
                    info.IsSlide = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSlide"]);
                    info.IsHome = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHome"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.Comment = Convert.ToString(ds.Tables[0].Rows[0]["Comment"]);
                    info.ImagesDisplay = Convert.ToString(ds.Tables[0].Rows[0]["ImagesDisplay"]);
                    info.ShortDescription = Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription"]);
                    info.MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);
                    info.MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                    info.MetaTitle = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitle"]);
                    info.AdminComment = Convert.ToString(ds.Tables[0].Rows[0]["AdminComment"]);
                }
            }

            return info;
        }

        public long CountPostInCategory(string CategoryID)
        {
            _DBAccess = new DBController();

            long QtyPost = 0;
            _DBAccess.CountPostInCategory("VD_CHECK_POSTS_IN_CATEGORY", CategoryID, ref QtyPost);

            return QtyPost;
        }

        public ResultResponse insertUpdatePost(VD_POST _post)
        {
            string _Msg = string.Empty;
            long _Result = 0;

            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.InsertPost("WEB_VD_INSERT_POST", _post, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deletePost(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;

            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_POST", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}