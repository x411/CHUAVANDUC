using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class SubMenuModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public VD_SubMenu getDetailsSubMenu(string _mainMenuID, string _subID)
        {
            VD_SubMenu info = new VD_SubMenu();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.getMainMenuDetails("WEB_VD_GET_DETAILS_SUBMENU", _mainMenuID, _subID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.MainMenuID = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuID"]);
                    info.MainMenuName = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuName"]);
                    info.SubMenuID = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuID"]);
                    info.SubMenuName = Convert.ToString(ds.Tables[0].Rows[0]["SubMenuName"]);
                    info.MetaTitleMainMenu = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitleMainMenu"]);
                    info.MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);
                    info.MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                    info.MetaTitle = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitle"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                }
            }

            return info;
        }

        public ResultResponse insertUpdateSubMenu(VD_SubMenu _subMenu)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateSubMenu("WEB_VD_INSERT_UPDATE_SUBMENU", _subMenu, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteSubMenu(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_SUBMENU", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}