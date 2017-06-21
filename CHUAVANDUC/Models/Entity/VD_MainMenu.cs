using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_MainMenu
    {
        [Required]
        public long ID { get; set; }

        [Required]
        public string MainMenuID { get; set; }

        [Required]
        public string MainMenuName { get; set; }

        public bool IsActive { get; set; }
        public int zIndex { get; set; }
        public List<VD_SubMenu> lstSubMenu { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
    }
}