using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class LoginModels
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public VD_USERS Login(string UserName, string Password)
        {
            VD_USERS info = new VD_USERS();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.Login("WEB_VD_LOGIN", UserName, Password);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"]);
                    info.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                    info.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    info.UserTypeID = Convert.ToString(ds.Tables[0].Rows[0]["UserTypeID"]);
                    info.UserTypeName = Convert.ToString(ds.Tables[0].Rows[0]["UserTypeName"]);
                }
            }

            return info;
        }
    }
}