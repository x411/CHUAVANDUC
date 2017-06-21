using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework;
using System.Data;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Models.DataAccess
{
    public class DBController : BaseBusiness, IDBController
    {
        private DataAccess _DB;
        public DBController()
        {
            this._DB = new DataAccess(this);
        }

        public DataSet GetEntityList(string DataTitle)
        {
            return _DB.GetEntityList(DataTitle);
        }

        public DataSet GetEntityDetails(string DataTitle, string ID)
        {
            return _DB.GetEntityDetails(DataTitle, ID);
        }

        public DataSet GetEntityDetails(string DataTitle, string ID, string IDDetails)
        {
            return _DB.GetEntityDetails(DataTitle, ID, IDDetails);
        }

        public void Insert(string DataTitle, string XmlContent, ref string outputMsg, ref long outputResult)
        {
            _DB.Insert(DataTitle, XmlContent, ref outputMsg, ref outputResult);
        }

        public void Update(string DataTitle, string ID, string XmlContent, ref string outputMsg, ref long outputResult)
        {
            _DB.Update(DataTitle, ID, XmlContent, ref outputMsg, ref outputResult);
        }

        public void Update(string DataTitle, string ID, string XmlContent, string XmlContentDetail, ref string outputMsg, ref long outputResult)
        {
            _DB.Update(DataTitle, ID, XmlContent, XmlContentDetail, ref outputMsg, ref outputResult);
        }

        public void UpdateWithDetail(string DataTitle, string ID, string IDDetail, string XmlContent, ref string outputMsg, ref long outputResult)
        {
            _DB.UpdateWithDetail(DataTitle, ID, IDDetail, XmlContent, ref outputMsg, ref outputResult);
        }

        public void Delete(string DataTitle, string ID, ref string outputMsg, ref long outputResult)
        {
            _DB.Delete(DataTitle, ID, ref outputMsg, ref outputResult);
        }
        public void Delete(string DataTitle, string ID,string IDDetail, ref string outputMsg, ref long outputResult)
        {
            _DB.Delete(DataTitle, ID,IDDetail, ref outputMsg, ref outputResult);
        }

        public void insertUpdateCategory(string DataTitle, VD_Category category, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateCategory(DataTitle, category, ref outputMsg, ref outputResult);
        }

        #region MENU
        public DataSet getMainMenuDetails(string DataTitle, string mainID, string subID)
        {
            return _DB.getMainMenuDetails(DataTitle, mainID, subID);
        }

        public void insertUpdateMainMenu(string DataTitle, VD_MainMenu mainMenu, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateMainMenu(DataTitle, mainMenu, ref outputMsg, ref outputResult);
        }

        public void insertUpdateSubMenu(string DataTitle, VD_SubMenu subMenu, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateSubMenu(DataTitle, subMenu, ref outputMsg, ref outputResult);
        } 

        #endregion

        #region AREAS - COURSE
        public void insertUpdateAreas(string DataTitle, VD_AREAS areas, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateAreas(DataTitle, areas, ref outputMsg, ref outputResult);
        }

        public int countPersonOnAreas(string DataTitle, long AreasID)
        {
            return _DB.countPersonOnAreas(DataTitle, AreasID);
        }

        public void insertUpdateCourse(string DataTitle, VD_COURSE course, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateCourse(DataTitle, course, ref outputMsg, ref outputResult);
        }

        public void insertUpdateCourseType(string DataTitle, VD_COURSE_TYPE courseType, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateCourseType(DataTitle, courseType, ref outputMsg, ref outputResult);
        } 
        #endregion

        #region Users
        public DataSet Login(string DataTitle, string UserName, string Password)
        {
            return _DB.Login(DataTitle, UserName, Password);
        }

        public void insertUpdateUserType(string DataTitle, VD_USERSTYPE userType, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateUserType(DataTitle, userType, ref outputMsg, ref outputResult);
        } 
        #endregion

        #region ABOUT
        public void insertUpdateAbout(string DataTitle, VD_About about, ref string outputMsg, ref long outputResult)
        {
            _DB.insertUpdateAbout(DataTitle, about, ref outputMsg, ref outputResult);
        } 
        #endregion

        #region POST
        public void InsertPost(string DataTitle, VD_POST _post, ref string outputMsg, ref long outputResult)
        {
            _DB.InsertPost(DataTitle, _post, ref outputMsg, ref outputResult);
        }

        public DataSet GetListPostByDate(string DataTitle, DateTime fromDate, DateTime toDate, string categoryID)
        {
            return _DB.GetListPostByDate(DataTitle, fromDate, toDate, categoryID);
        }

        public void CountPostInCategory(string DataTitle, string CategoryID, ref long QtyPost)
        {
            _DB.CountPostInCategory(DataTitle, CategoryID, ref QtyPost);
        }

        public DataSet getListPostByMenu(string DataTitle, string MainID, string SubID)
        {
            return _DB.getListPostByMenu(DataTitle, MainID, SubID);
        }

        public DataSet getPostByID(string DataTitle, long ID)
        {
            return _DB.getPostByID(DataTitle, ID);
        }

        #endregion
    }
}