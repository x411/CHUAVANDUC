using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHUAVANDUC.Models.Entity
{
    public class VD_Category
    {
        [Required]
        public long ID { get; set; }

        [Required]
        public string CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string C_alias { get; set; }
        public bool IsActive { get; set; }
        public int zIndex { get; set; }
        public bool IsHomeIndex { get; set; }
    }
}