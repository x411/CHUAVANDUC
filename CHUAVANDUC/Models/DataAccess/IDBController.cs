using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Models.DataAccess
{
    public interface IDBController
    {
        DataSet GetEntityList(string DataTitle);
        DataSet GetEntityDetails(string DataTitle, string ID);
        DataSet GetEntityDetails(string DataTitle, string ID, string IDDetails);
        
        void Insert(string DataTitle, string XmlContent, ref string outputMsg, ref long outputResult);
        void Update(string DataTitle, string ID, string XmlContent, ref string outputMsg, ref long outputResult);
        void Update(string DataTitle, string ID, string XmlContent, string XmlContentDetail, ref string outputMsg, ref long outputResult);
        void UpdateWithDetail(string DataTitle, string ID, string IDDetail, string XmlContent, ref string outputMsg, ref long outputResult);

        void Delete(string DataTitle, string ID, ref string outputMsg, ref long outputResult);
        void Delete(string DataTitle, string ID,string IDDetail, ref string outputMsg, ref long outputResult);

        //Category
        void insertUpdateCategory(string DataTitle, VD_Category category, ref string outputMsg, ref long outputResult);

        //mainMenu
        DataSet getMainMenuDetails(string DataTitle, string mainID, string subID);
        void insertUpdateMainMenu(string DataTitle, VD_MainMenu mainMenu, ref string outputMsg, ref long outputResult);

        //subMenu
        void insertUpdateSubMenu(string DataTitle, VD_SubMenu subMenu, ref string outputMsg, ref long outputResult);

        //Areas
        void insertUpdateAreas(string DataTitle, VD_AREAS areas, ref string outputMsg, ref long outputResult);
        int countPersonOnAreas(string DataTitle, long AreasID);

        //Couser
        void insertUpdateCourse(string DataTitle, VD_COURSE course, ref string outputMsg, ref long outputResult);

        //CouserType
        void insertUpdateCourseType(string DataTitle, VD_COURSE_TYPE courseType, ref string outputMsg, ref long outputResult);

        //USERS
        DataSet Login(string DataTitle, string UserName, string Password);

        //UserType
        void insertUpdateUserType(string DataTitle, VD_USERSTYPE userType, ref string outputMsg, ref long outputResult);

        //ABOUT
        void insertUpdateAbout(string DataTitle, VD_About about, ref string outputMsg, ref long outputResult);

        //Post
        void InsertPost(string DataTitle, VD_POST _post, ref string outputMsg, ref long outputResult);
        DataSet GetListPostByDate(string DataTitle, DateTime fromDate, DateTime toDate, string categoryID);
        void CountPostInCategory(string DataTitle, string CategoryID, ref long QtyPost);
        DataSet getListPostByMenu(string DataTitle, string MainID, string SubID);
        DataSet getPostByID(string DataTitle, long ID);
    }
}