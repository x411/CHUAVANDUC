using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class Comment
    {
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public bool IsApproved { get; set; }
        public long PostID { get; set; }
        public DateTime CreatedDate { get; set; }
        public VD_USERS UserInfo { get; set; }
    }
}