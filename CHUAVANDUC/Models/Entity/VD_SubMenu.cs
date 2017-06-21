using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_SubMenu
    {
        [Required]
        public long ID { get; set; }

        [Required]
        public string MainMenuID { get; set; }

        public string MainMenuName { get; set; }

        [Required]
        public string SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public string M_alias { get; set; }

        [Required]
        public string S_alias { get; set; }

        public bool IsActive { get; set; }
        public int zIndex { get; set; }
    }
}