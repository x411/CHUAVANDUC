using CHUAVANDUC.Models.DataAccess;
using CHUAVANDUC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models
{
    public class MainMenuModel
    {
        IDBController _DBAccess;
        ResultResponse _rr;

        public List<VD_MainMenu> getListMainMenu()
        {
            List<VD_MainMenu> lst = new List<VD_MainMenu>();
            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityList("WEB_VD_GETLIST_MAINMENU");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lst.Add(new VD_MainMenu
                        {
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(row["MainMenuName"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"]),
                            lstSubMenu = getDetailsMainMenu(row["MainMenuID"].ToString()).lstSubMenu
                        });
                    }
                }
            }

            return lst;
        }

        public VD_MainMenu getDetailsMainMenu(string ID)
        {
            VD_MainMenu info = new VD_MainMenu();
            List<VD_SubMenu> lstSub = new List<VD_SubMenu>();

            _DBAccess = new DBController();
            DataSet ds = new DataSet();
            ds = _DBAccess.GetEntityDetails("WEB_VD_GET_DETAILS_MAINMENU", ID);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    info.MainMenuID = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuID"]);
                    info.MainMenuName = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuName"]);
                    info.MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);
                    info.MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                    info.MetaTitle = Convert.ToString(ds.Tables[0].Rows[0]["MetaTitle"]);
                    info.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                    info.zIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["zIndex"]);
                }
                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        lstSub.Add(new VD_SubMenu
                        {
                            ID = Convert.ToInt64(row["ID"]),
                            MainMenuID = Convert.ToString(row["MainMenuID"]),
                            MainMenuName = Convert.ToString(ds.Tables[0].Rows[0]["MainMenuName"]),
                            SubMenuID = Convert.ToString(row["SubMenuID"]),
                            SubMenuName = Convert.ToString(row["SubMenuName"]),
                            MetaTitleMainMenu = Convert.ToString(row["MetaTitleMainMenu"]),
                            MetaDescription = Convert.ToString(row["MetaDescription"]),
                            MetaKeywords = Convert.ToString(row["MetaKeywords"]),
                            MetaTitle = Convert.ToString(row["MetaTitle"]),
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            zIndex = Convert.ToInt32(row["zIndex"])
                        });
                    }
                }
            }

            info.lstSubMenu = lstSub;

            return info;
        }

        public ResultResponse insertUpdateMainMenu(VD_MainMenu _mainMenu)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.insertUpdateMainMenu("WEB_VD_INSERT_UPDATE_MAINMENU", _mainMenu, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }

        public ResultResponse deleteMainMenu(string ID)
        {
            string _Msg = string.Empty;
            long _Result = 0;
            _rr = new ResultResponse();
            _DBAccess = new DBController();
            _DBAccess.Delete("WEB_VD_DELETE_MAINMENU", ID, ref _Msg, ref _Result);
            _rr.Msg = _Msg;
            _rr.Result = _Result;

            return _rr;
        }
    }
}