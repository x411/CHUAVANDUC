using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class CategoryModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_Category> getListCategory()
        {
            List<VD_Category> lst = new List<VD_Category>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_CATEGORY");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_Category
                        {
                            CategoryID = Convert.ToString(row["CategoryID"]),
                            CategoryName = Convert.ToString(row["CategoryName"]),
                            C_alias = Convert.ToString(row["C_alias"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"]),
                            IsHomeIndex = Convert.ToBoolean(row["IsHomeIndex"])
                        });
                    }
                }
            }

            return lst;
        }

        public VD_Category getDetailsCategory(string ID)
        {
            VD_Category info = new VD_Category();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_CATEGORY", ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.CategoryID = Convert.ToString(ds.Tables[0].Rows[0]["CategoryID"]);
                    info.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);
                    info.C_alias = Convert.ToString(ds.Tables[0].Rows[0]["C_alias"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                    info.IsHomeIndex = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHomeIndex"]);
                }
            }

            return info;
        }

        public ResultResponse insertUpdateCategory(VD_Category _category)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateCategory("WEB_VD_INSERT_UPDATE_CATEGORY", _category, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteCategory(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_CATEGORY", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}