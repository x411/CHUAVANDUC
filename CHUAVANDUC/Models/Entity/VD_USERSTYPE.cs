using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_USERS
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class VD_USERSTYPE
    {
        public long ID { get; set; }
        public string UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public bool IsActive { get; set; }
        public int zIndex { get; set; }
    }
}