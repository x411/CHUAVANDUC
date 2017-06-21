using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class Helper
    {
        public static bool CheckSession()
        {
            if (HttpContext.Current.Session["UserType"] == null)
            {
                HttpContext.Current.Session["RolesError"] = "Sorry session timeout! Please login again.";

                return true;
            }
            else
            {
                HttpContext.Current.Session["RolesError"] = "";
                return false;
            }
        }

        public static string GenerateCoupon(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }

    public class ResultResponse
    {
        public long Result { get; set; }
        public string Msg { get; set; }
    }
}