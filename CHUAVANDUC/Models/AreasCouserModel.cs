using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class AreasCouserModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_AREAS> getListAreas()
        {
            List<VD_AREAS> lstAreas = new List<VD_AREAS>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_AREAS");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstAreas.Add(new VD_AREAS
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["Name"]),
                            Descriptions = Convert.ToString(row["Descriptions"]),
                            Quantity = Convert.ToInt32(row["Quantity"]),
                            PersonRegister = _DBAccess.countPersonOnAreas("WEB_VD_COUNT_PERSON_AREAS", Convert.ToInt64(row["ID"])),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"])
                        });
                    }
                }
            }

            return lstAreas;
        }

        public VD_AREAS getDetailsAreas(string AreasID)
        {
            VD_AREAS areas = new VD_AREAS();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_AREAS", AreasID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    areas.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    areas.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    areas.Descriptions = Convert.ToString(ds.Tables[0].Rows[0]["Descriptions"]);
                    areas.Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["Quantity"]);
                    areas.PersonRegister = _DBAccess.countPersonOnAreas("WEB_VD_COUNT_PERSON_AREAS", Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]));
                    areas.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    areas.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                }
            }

            return areas;
        }

        public ResultResponse insertUpdateAreas(VD_AREAS _areas)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateAreas("WEB_VD_INSERT_UPDATE_AREAS", _areas, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteAreas(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_AREAS", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public List<VD_COURSE> getListCourse()
        {
            List<VD_COURSE> lstCourse = new List<VD_COURSE>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_COURSE");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstCourse.Add(new VD_COURSE
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["Name"]),
                            Descriptions = Convert.ToString(row["Descriptions"]),
                            CourseType = Convert.ToInt32(row["CourseType"]),
                            CourseTypeName = Convert.ToString(row["CourseTypeName"]),
                            FromDate = Convert.ToDateTime(row["FromDate"]),
                            ToDate = Convert.ToDateTime(row["ToDate"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"])
                        });
                    }
                }
            }

            return lstCourse;
        }

        public VD_COURSE getDetailsCourse(string CourseID)
        {
            VD_COURSE course = new VD_COURSE();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_COURSE", CourseID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    course.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    course.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    course.Descriptions = Convert.ToString(ds.Tables[0].Rows[0]["Descriptions"]);
                    course.CourseType = Convert.ToInt32(ds.Tables[0].Rows[0]["CourseType"]);
                    course.CourseTypeName = Convert.ToString(ds.Tables[0].Rows[0]["CourseTypeName"]);
                    course.FromDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["FromDate"]);
                    course.ToDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ToDate"]);
                    course.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    course.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                }
            }

            return course;
        }

        public ResultResponse insertUpdateCourse(VD_COURSE _course)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateCourse("WEB_VD_INSERT_UPDATE_COURSE", _course, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteCourse(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_COURSE", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public List<VD_COURSE_TYPE> getListCourseType()
        {
            List<VD_COURSE_TYPE> lstCourseType = new List<VD_COURSE_TYPE>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_COURSE_TYPE");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstCourseType.Add(new VD_COURSE_TYPE
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            Name = Convert.ToString(row["Name"]),
                            Descriptions = Convert.ToString(row["Descriptions"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"])
                        });
                    }
                }
            }

            return lstCourseType;
        }

        public VD_COURSE_TYPE getDetailsCourseType(string CourseTypeID)
        {
            VD_COURSE_TYPE course = new VD_COURSE_TYPE();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_COURSE_TYPE", CourseTypeID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    course.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    course.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    course.Descriptions = Convert.ToString(ds.Tables[0].Rows[0]["Descriptions"]);
                    course.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    course.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                }
            }

            return course;
        }

        public ResultResponse insertUpdateCourseType(VD_COURSE_TYPE _course)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateCourseType("WEB_VD_INSERT_UPDATE_COURSE_TYPE", _course, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteCourseType(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_COURSE_TYPE", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}