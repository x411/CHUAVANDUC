using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CHUAVANDUC.Models.Entity;

namespace CHUAVANDUC.Models.DataAccess
{
    public class DataAccess : BaseDataAccess
    {
        private static ReadConnectInfo ConnectInfo = new ReadConnectInfo();
        public DataAccess(BaseBusiness basebusiness)
            : base(basebusiness)
        {
        }

        public DataSet GetEntityList(string DataTitle)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);

            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        public DataSet GetEntityDetails(string DataTitle, string ID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        public DataSet GetEntityDetails(string DataTitle, string ID, string IDDetails)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);
            DataManager.AddParameterWithValue(command, "@IDDetails", IDDetails);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        public void Update(string DataTitle, string ID, string XmlContent, string XmlContentDetail, ref string outputMsg, ref long outputResult)
        {

            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);

            DataManager.AddParameterWithValue(command, "@XMLOrder", XmlContent);
            DataManager.AddParameterWithValue(command, "@XMLOrderDetail", XmlContentDetail);

            

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        public void Update(string DataTitle, string XmlContent, ref string outputMsg, ref long outputResult)
        {

            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@XMLContent", XmlContent);
            

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        
        public void Insert(string DataTitle, string XmlContent, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@XMLContent", XmlContent);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        public void Update(string DataTitle, string ID, string XmlContent, ref string outputMsg, ref long outputResult)
        {

            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);
            DataManager.AddParameterWithValue(command, "@XMLContent", XmlContent);

            

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }

        }
        public void UpdateWithDetail(string DataTitle, string ID, string IDDetail, string XmlContent, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);

            DataManager.AddParameterWithValue(command, "@ID", ID);
            DataManager.AddParameterWithValue(command, "@IDDetail", IDDetail);

            SqlParameter paramXMLContent = new SqlParameter("@XMLContent", SqlDbType.NVarChar, -1);
            paramXMLContent.Direction = ParameterDirection.Input;
            paramXMLContent.Value = XmlContent;
            DataManager.AddParameter(command, paramXMLContent);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        public void Delete(string DataTitle, string ID, ref string outputMsg, ref long outputResult)
        {
            StringBuilder outMsg = new StringBuilder(255);
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);
            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }

        }
        public void Delete(string DataTitle, string ID,string IDDetail, ref string outputMsg, ref long outputResult)
        {
            StringBuilder outMsg = new StringBuilder(255);
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);

            DataManager.AddParameterWithValue(command, "@ID", ID);
            DataManager.AddParameterWithValue(command, "@IDDetail", IDDetail);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }

        }

        //Category
        public void insertUpdateCategory(string DataTitle, VD_Category category, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@CategoryID", category.CategoryID);
            DataManager.AddParameterWithValue(command, "@CategoryName", category.CategoryName);
            DataManager.AddParameterWithValue(command, "@IsActive", category.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", category.zIndex);
            DataManager.AddParameterWithValue(command, "@IsHomeIndex", category.IsHomeIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //mainMenu
        public void insertUpdateMainMenu(string DataTitle, VD_MainMenu mainMenu, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@MainMenuID", mainMenu.MainMenuID);
            DataManager.AddParameterWithValue(command, "@MainMenuName", mainMenu.MainMenuName);
            DataManager.AddParameterWithValue(command, "@IsActive", mainMenu.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", mainMenu.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        public DataSet getMainMenuDetails(string DataTitle, string MainMenuID, string SubMenuID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@MainMenuID", MainMenuID);
            DataManager.AddParameterWithValue(command, "@SubMenuID", SubMenuID);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        //subMenu
        public void insertUpdateSubMenu(string DataTitle, VD_SubMenu subMenu, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@MainMenuID", subMenu.MainMenuID);
            DataManager.AddParameterWithValue(command, "@SubMenuID", subMenu.SubMenuID);
            DataManager.AddParameterWithValue(command, "@SubMenuName", subMenu.SubMenuName);
            DataManager.AddParameterWithValue(command, "@IsActive", subMenu.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", subMenu.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //Areas
        public void insertUpdateAreas(string DataTitle, VD_AREAS areas, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", areas.ID);
            DataManager.AddParameterWithValue(command, "@Name", areas.Name);
            DataManager.AddParameterWithValue(command, "@Descriptions", areas.Descriptions);
            DataManager.AddParameterWithValue(command, "@Quantity", areas.Quantity);
            DataManager.AddParameterWithValue(command, "@IsActive", areas.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", areas.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        public int countPersonOnAreas(string DataTitle, long AreasID)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@AreasID", AreasID);

            SqlParameter paramOutputPerson = new SqlParameter("@outputPerson", SqlDbType.BigInt);
            paramOutputPerson.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputPerson);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputPerson.Value != null)
            {
                return int.Parse(paramOutputPerson.Value.ToString());
            }
            else
            {
                return 0;
            }
        }

        //Couser
        public void insertUpdateCourse(string DataTitle, VD_COURSE course, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", course.ID);
            DataManager.AddParameterWithValue(command, "@Name", course.Name);
            DataManager.AddParameterWithValue(command, "@Descriptions", course.Descriptions);
            DataManager.AddParameterWithValue(command, "@CourseType", course.CourseType);
            DataManager.AddParameterWithValue(command, "@FromDate", course.FromDate);
            DataManager.AddParameterWithValue(command, "@ToDate", course.ToDate);
            DataManager.AddParameterWithValue(command, "@IsActive", course.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", course.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //CouserType
        public void insertUpdateCourseType(string DataTitle, VD_COURSE_TYPE courseType, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", courseType.ID);
            DataManager.AddParameterWithValue(command, "@Name", courseType.Name);
            DataManager.AddParameterWithValue(command, "@Descriptions", courseType.Descriptions);
            DataManager.AddParameterWithValue(command, "@IsActive", courseType.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", courseType.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //users
        public DataSet Login(string DataTitle, string UserName, string Password)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@UserName", UserName);
            DataManager.AddParameterWithValue(command, "@Password", Password);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        //UserType
        public void insertUpdateUserType(string DataTitle, VD_USERSTYPE userType, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@UserTypeID", userType.UserTypeID);
            DataManager.AddParameterWithValue(command, "@UserTypeName", userType.UserTypeName);
            DataManager.AddParameterWithValue(command, "@IsActive", userType.IsActive);
            DataManager.AddParameterWithValue(command, "@zIndex", userType.zIndex);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //ABOUT
        public void insertUpdateAbout(string DataTitle, VD_About about, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", about.ID);
            DataManager.AddParameterWithValue(command, "@Name", about.Name);
            DataManager.AddParameterWithValue(command, "@URL", about.URL);
            DataManager.AddParameterWithValue(command, "@IsActive", about.IsActive);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }

        //POST
        public void InsertPost(string DataTitle, VD_POST _post, ref string outputMsg, ref long outputResult)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", _post.ID);
            DataManager.AddParameterWithValue(command, "@CategoryID", _post.CategoryID);
            DataManager.AddParameterWithValue(command, "@MainMenuID", _post.MainMenuID);
            DataManager.AddParameterWithValue(command, "@SubMenuID", _post.SubMenuID);
            DataManager.AddParameterWithValue(command, "@TitlePost", _post.TitlePost);
            DataManager.AddParameterWithValue(command, "@ContentPost", _post.ContentPost);
            DataManager.AddParameterWithValue(command, "@CreatedBy", _post.CreatedBy);
            DataManager.AddParameterWithValue(command, "@ChangeBy", _post.ChangeBy);
            DataManager.AddParameterWithValue(command, "@IsPublish", _post.IsPublish);
            DataManager.AddParameterWithValue(command, "@IsSlide", _post.IsSlide);
            DataManager.AddParameterWithValue(command, "@IsHome", _post.IsHome);
            DataManager.AddParameterWithValue(command, "@IsActive", _post.IsActive);
            DataManager.AddParameterWithValue(command, "@Comment", _post.Comment);
            DataManager.AddParameterWithValue(command, "@ImagesDisplay", _post.ImagesDisplay);

            SqlParameter paramOutputMsg = new SqlParameter("@outputMsg", SqlDbType.NVarChar, 1000);
            paramOutputMsg.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputMsg);

            SqlParameter paramOutputResult = new SqlParameter("@outputResult", SqlDbType.BigInt);
            paramOutputResult.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputResult);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputResult.Value != null)
            {
                outputResult = (long)paramOutputResult.Value;
                outputMsg = paramOutputMsg.Value.ToString();
            }
            else
            {
                outputResult = -1;
                outputMsg = string.Empty;
            }
        }
        public DataSet GetListPostByDate(string DataTitle, DateTime fromDate, DateTime toDate, string categoryID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@fromDate", fromDate);
            DataManager.AddParameterWithValue(command, "@toDate", toDate);
            DataManager.AddParameterWithValue(command, "@categoryID", categoryID);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        public void CountPostInCategory(string DataTitle, string CategoryID, ref long QtyPost)
        {
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", CategoryID);

            SqlParameter paramOutputQtyPost = new SqlParameter("@QtyPost", SqlDbType.BigInt);
            paramOutputQtyPost.Direction = ParameterDirection.Output;
            DataManager.AddParameter(command, paramOutputQtyPost);

            DataManager.ExecuteNonQuery(command);
            if (paramOutputQtyPost.Value != null)
            {
                QtyPost = (long)paramOutputQtyPost.Value;
            }
            else
            {
                QtyPost = 0;
            }
        }
        public DataSet getListPostByMenu(string DataTitle, string MainID, string SubID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@MainID", MainID);
            DataManager.AddParameterWithValue(command, "@SubID", SubID);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }

        public DataSet getPostByID(string DataTitle, long ID)
        {
            DataSet ds = new DataSet();
            SqlCommand command = this.DataManager.CreateCommand(DataTitle, CommandType.StoredProcedure);
            DataManager.AddParameterWithValue(command, "@ID", ID);
            ds = DataManager.ExcuteQuery(command);
            return ds;
        }
    }
}