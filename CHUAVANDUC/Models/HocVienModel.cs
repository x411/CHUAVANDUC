using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class HocVienModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_HOCVIEN> getListHocVien()
        {
            List<VD_HOCVIEN> lst = new List<VD_HOCVIEN>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_HOCVIEN");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_HOCVIEN
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            FullName = Convert.ToString(row["FullName"]),
                            CMND = Convert.ToString(row["CMND"]),
                            PhapDanh = Convert.ToString(row["PhapDanh"]),
                            Birthday = Convert.ToDateTime(row["Birthday"]),
                            Phone1 = Convert.ToString(row["Phone1"]),
                            Phone2 = Convert.ToString(row["Phone2"]),
                            Address = Convert.ToString(row["Address"]),
                            zIndex = Convert.ToInt32(row["zIndex"]),
                            AreasID = Convert.ToInt64(row["AreasID"]),
                            AreasName = Convert.ToString(row["AreasName"]),
                            CourseID = Convert.ToInt64(row["CourseID"]),
                            CourseName = Convert.ToString(row["CourseName"]),
                            UserTypeID = Convert.ToString(row["UserTypeID"]),
                            UserTypeName = Convert.ToString(row["UserTypeName"]),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                            IsApproval = Convert.ToBoolean(row["IsApproval"])
                        });
                    }
                }
            }

            return lst;
        }

        public VD_HOCVIEN getDetailsHocVien(string ID)
        {
            VD_HOCVIEN info = new VD_HOCVIEN();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_HOCVIEN", ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    info.FullName = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
                    info.CMND = Convert.ToString(ds.Tables[0].Rows[0]["CMND"]);
                    info.PhapDanh = Convert.ToString(ds.Tables[0].Rows[0]["PhapDanh"]);
                    info.Birthday = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"]);
                    info.Phone1 = Convert.ToString(ds.Tables[0].Rows[0]["Phone1"]);
                    info.Phone2 = Convert.ToString(ds.Tables[0].Rows[0]["Phone2"]);
                    info.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                    info.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                    info.AreasID = Convert.ToInt64(ds.Tables[0].Rows[0]["AreasID"]);
                    info.AreasName = Convert.ToString(ds.Tables[0].Rows[0]["AreasName"]);
                    info.CourseID = Convert.ToInt64(ds.Tables[0].Rows[0]["CourseID"]);
                    info.CourseName = Convert.ToString(ds.Tables[0].Rows[0]["CourseName"]);
                    info.UserTypeID = Convert.ToString(ds.Tables[0].Rows[0]["UserTypeID"]);
                    info.UserTypeName = Convert.ToString(ds.Tables[0].Rows[0]["UserTypeName"]);
                    info.CreatedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                    info.IsApproval = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApproval"]);
                }
            }

            return info;
        }

        public ResultResponse insertUpdateHocVien(VD_HOCVIEN _tusinh)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            string _XMLContent = string.Empty;
            _XMLContent = "<root>";
            _XMLContent += "<HOCVIEN>";
            _XMLContent += "<ID>" + _tusinh.ID + "</ID>";
            _XMLContent += "<FullName>" + _tusinh.FullName + "</FullName>";
            _XMLContent += "<CMND>" + _tusinh.CMND + "</CMND>";
            _XMLContent += "<PhapDanh>" + _tusinh.PhapDanh + "</PhapDanh>";
            _XMLContent += "<Birthday>" + _tusinh.Birthday + "</Birthday>";
            _XMLContent += "<Phone1>" + _tusinh.Phone1 + "</Phone1>";
            _XMLContent += "<Phone2>" + _tusinh.Phone2 + "</Phone2>";
            _XMLContent += "<Address>" + _tusinh.Address + "</Address>";
            _XMLContent += "<zIndex>" + _tusinh.zIndex + "</zIndex>";
            _XMLContent += "<AreasID>" + _tusinh.AreasID + "</AreasID>";
            _XMLContent += "<CourseID>" + _tusinh.CourseID + "</CourseID>";
            _XMLContent += "<UserTypeID>" + _tusinh.UserTypeID + "</UserTypeID>";
            _XMLContent += "<IsApproval>" + _tusinh.IsApproval + "</IsApproval>";
            _XMLContent += "</HOCVIEN>";
            _XMLContent += "</root>";


            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Insert("WEB_VD_INSERT_HOCVIEN", _XMLContent, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteHocVien(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;

            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_HOCVIEN", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}