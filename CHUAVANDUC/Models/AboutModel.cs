using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class AboutModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_About> getListAbout()
        {
            List<VD_About> lst = new List<VD_About>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GET_LIST_ABOUT");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_About
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["Name"]),
                            URL = Convert.ToString(row["URL"]),
                            ShortDescription = Convert.ToString(row["ShortDescription"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                        });
                    }
                }
            }

            return lst;
        }

        public VD_About getDetailsAbout(string ID)
        {
            VD_About info = new VD_About();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_ABOUT", ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    info.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    info.URL = Convert.ToString(ds.Tables[0].Rows[0]["URL"]);
                    info.ShortDescription = Convert.ToString(ds.Tables[0].Rows[0]["ShortDescription"]);
                    info.MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);
                    info.MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                    info.MetaTitle = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitle"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                }
            }

            return info;
        }

        public ResultResponse insertUpdateAbout(VD_About _about)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateAbout("WEB_VD_INSERT_UPDATE_ABOUT", _about, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteAbout(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_ABOUT", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}