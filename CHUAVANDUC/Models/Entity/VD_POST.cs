using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_POST
    {
        public long ID { get; set; }
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string C_alias { get; set; }
        public string MainMenuID { get; set; }
        public string MainMenuName { get; set; }
        public string SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public string M_alias { get; set; }
        public string S_alias { get; set; }
        public string TitlePost { get; set; }
        public string ImagesDisplay { get; set; }
        public string ContentPost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ChangeBy { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool IsPublish { get; set; }
        public bool IsSlide { get; set; }
        public bool IsHome { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }
    }
}